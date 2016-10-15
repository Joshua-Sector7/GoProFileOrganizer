using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GoProFileOrganizer
{
    public partial class Form1 : Form
    {
        private List<string> errors = new List<string>();

        Args processingArguments = new Args();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxRootFolder_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (folders.Length == 1 && Directory.Exists(folders[0]))
                {
                    e.Effect = DragDropEffects.All;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }  
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxDestination_DragDrop(object sender, DragEventArgs e)
        {
            string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if(folders.Length == 1 && Directory.Exists(folders[0]))
            {
                textBoxDestination.Text = folders[0];
            }
        }

        private void textBoxDestination_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (folders.Length == 1 && Directory.Exists(folders[0]))
                {
                    e.Effect = DragDropEffects.All;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxRootFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (folders.Length == 1 && Directory.Exists(folders[0]))
            {
                textBoxRootFolder.Text = folders[0];
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                // new run reset arguments maintainer
                processingArguments = new Args();

                //dataGridViewMetrics.DataSource = null;

                // fetch and set source path
                AddFeedbackText("Your Source Directory:");
                AddFeedbackText(textBoxRootFolder.Text);
                processingArguments.sourcePath = textBoxRootFolder.Text;

                // fetch and set destination path
                AddFeedbackText("Your Destination Directory:");
                AddFeedbackText(textBoxDestination.Text);
                processingArguments.destination = textBoxDestination.Text;
                
                // scan source directory for all the gopro file types that we organize
                foreach (string fileToProcessFullPath in Directory.EnumerateFiles(processingArguments.sourcePath, "*.*",
                      SearchOption.AllDirectories)
                      .Where(s => s.EndsWith(".MP4") || s.EndsWith(".JPG")))
                {
                    processingArguments.files.Add(new FileEntry(fileToProcessFullPath));
                }

                AddFeedbackText("Total files found in the source directory: " + processingArguments.files.Count().ToString());

                // Practice run check...
                // A practice run goes through the whole program but excludes an actual copy command.
                if (checkBoxPractiveRun.CheckState == CheckState.Checked)
                {
                    processingArguments.dryrun = true;
                    AddFeedbackText("Practice run is checked -> no files will be copied.");
                }
                else
                {
                    processingArguments.dryrun = false;
                    AddFeedbackText("Practice run is not checked -> files will be copied to destination.");
                }

                try
                {
                    if (!Directory.Exists(processingArguments.destination + "\\logs"))
                    {
                        AddFeedbackText("Destination log folder doesn't exist, trying to create.");
                        Directory.CreateDirectory(processingArguments.destination + "\\logs");
                        AddFeedbackText("Destination logs folder create did not throw an exception.");
                    }

                    if (!Directory.Exists(processingArguments.destination + "\\photo"))
                    {
                        AddFeedbackText("Destination photo folder doesn't exist, trying to create.");
                        Directory.CreateDirectory(processingArguments.destination + "\\photo");
                        AddFeedbackText("Destination photo folder create did not throw an exception.");
                    }

                    if (!Directory.Exists(processingArguments.destination + "\\video"))
                    {
                        AddFeedbackText("Destination video folder doesn't exist, trying to create.");
                        Directory.CreateDirectory(processingArguments.destination + "\\video");
                        AddFeedbackText("Destination video folder create did not throw an exception.");
                    }

                    if (!Directory.Exists(processingArguments.destination + "\\grouping"))
                    {
                        AddFeedbackText("Destination grouping folder doesn't exist, trying to create.");
                        Directory.CreateDirectory(processingArguments.destination + "\\grouping");
                        AddFeedbackText("Destination grouping folder create did not throw an exception.");
                    }

                    AddFeedbackText("Everything looks good, launching processing thread.");
                    backgroundWorker1.RunWorkerAsync(processingArguments);
                }
                catch (Exception ex)
                {
                    processingArguments.exceptionInformation = ex.ToString();
                    AddFeedbackText("Something went wrong when trying to create destination folders.");
                }
            }
        }

        private bool ValidateOrMakeDirectory(string dir, out string exception)
        {
            bool result = false;
            exception = "";

            if (Directory.Exists(dir))
            {
                result = true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    result = true;
                }
                catch (Exception ex)
                {
                    exception = ex.ToString();
                    result = false;
                }
            }
            return result;
        }

        private FileEntry.FailureType FileMoveOperations(Args argContainer, string fullDestination, string sourceFile, out string exceptionInformation)
        {
            FileEntry.FailureType error = FileEntry.FailureType.NULL;
            exceptionInformation = "";

            //fullDestinationPath -> remove ending!
            string justDirectory = fullDestination.Substring(0, fullDestination.LastIndexOf('\\'));

            // first validate or create destination directory for file.
            if (!ValidateOrMakeDirectory(justDirectory, out exceptionInformation))
            {
                // well crap something went wrong when trying to get the destination folder validated or created
                error = FileEntry.FailureType.DESTINATION_DIRECTORY_VALIDATION_OR_CREATION;
            }
            else
            {


                if (File.Exists(fullDestination))
                {
                    // looks like we have a duplicate file... ut oh
                    error = FileEntry.FailureType.FILE_DUPLICATE;
                }
                else if (argContainer.dryrun)
                {
                    // this is just a practice run, note that we just skipped the copy attempt
                    error = FileEntry.FailureType.PRACTICE_RUN;
                }
                else
                {
                    // attempt file copy
                    try
                    {
                        // copy
                        //File.Create(destDir + "\\" + fileName);
                        File.Copy(sourceFile, fullDestination);
                        error = FileEntry.FailureType.SUCCESSFUL_COPY;
                    }
                    catch (Exception ex)
                    {
                        //argContainer.errorLogs.Add(destDir + "\\" + fileName + " -> " + ex.ToString());
                        exceptionInformation = ex.ToString();
                        error = FileEntry.FailureType.COPY_FAILURE;
                    }
                }
            }
            return error;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Args args = e.Argument as Args;

            // iterate through every file from the source directory
            foreach(FileEntry file in args.files)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    e.Result = args;
                    break;
                }

                ++args.iterations;
                string fileMoveExceptionInformation = "";

                switch(file.goProFileType)
                {
                    case FileEntry.GoProFileType.PHOTO:
                        file.finalDestination = args.destination + "\\photo\\" + file.datedDestinationFolder + "\\" + file.updatedFileName;
                        file.failureType = FileMoveOperations(args, file.finalDestination, file.fullFilePath, out fileMoveExceptionInformation);
                        break;

                    case FileEntry.GoProFileType.VIDEO:
                        file.finalDestination = args.destination + "\\video\\" + file.datedDestinationFolder + "\\" + file.updatedFileName;
                        file.failureType = FileMoveOperations(args, file.finalDestination, file.fullFilePath, out fileMoveExceptionInformation);
                        break;

                    case FileEntry.GoProFileType.PHOTO_GROUP:
                        file.finalDestination = args.destination + "\\grouping\\" + file.datedDestinationFolder + "\\" + file.groupId + "\\" + file.updatedFileName;
                        file.failureType = FileMoveOperations(args, file.finalDestination, file.fullFilePath, out fileMoveExceptionInformation);
                        break;
                        
                    default:
                        // something went wrong when attempting file tupe determination.
                        // this has to do with a strange/unecpected file naming.
                        file.failureType = FileEntry.FailureType.FILE_TYPE_DETERMINATION;
                        break;
                }
                file.exceptionData = fileMoveExceptionInformation;

                // build up log file
                args.logText.AppendLine(file.ReportCSV());

                backgroundWorker1.ReportProgress(0, args);
            }
            e.Result = args;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBoxProcessingStatus.Text = processingArguments.Status();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                AddFeedbackText("cancelled");
            }
            else
            {
                AddFeedbackText("done");
            }

            string logFileNameAndPath = processingArguments.destination + "\\logs\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt";

            StreamWriter logFileWrite = new StreamWriter(logFileNameAndPath);
            logFileWrite.WriteLine(processingArguments.logText.ToString());
            logFileWrite.Close();

            AddFeedbackText("Report file generated: " + logFileNameAndPath);
        }

        private void AddFeedbackText(string text)
        {
            richTextBoxFeedback.SelectionStart = richTextBoxFeedback.TextLength;
            richTextBoxFeedback.SelectedText = text + "\r\n";
        }
    }
}
