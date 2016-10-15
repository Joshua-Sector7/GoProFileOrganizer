using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoProFileOrganizer
{
    public class FileEntry
    {
        public enum GoProFileType
        {
            INVALID,
            PHOTO,
            VIDEO,
            PHOTO_GROUP
        };

        public enum FailureType
        {
            NULL,
            FILE_TYPE_DETERMINATION,
            DESTINATION_DIRECTORY_VALIDATION_OR_CREATION,
            FILE_DUPLICATE,
            PRACTICE_RUN,
            SUCCESSFUL_COPY,
            COPY_FAILURE
        };

        public string fullFilePath { get; }
        public string fileNameWithFormat { get; }
        public string datedDestinationFolder { get; set; }
        public string updatedFileName { get; set; }
        public string groupId { get; set; }
        public GoProFileType goProFileType { get; set; }
        public FailureType failureType { get; set; }
        public string exceptionData { get; set; }
        public string finalDestination { get; set; }

        static public string[] ReportHeaders()
        {
            return new string[] {
                "fullFilePath",
                "fileNameWithFormat",
                "datedDestinationFolder",
                "updatedFileName",
                "groupId",
                "goProFileType.ToString()",
                "failureType.ToString()",
                "exceptionData",
                "finalDestination"
            };
        }

        public string[] Report()
        {
            return new string[] {
                fullFilePath,
                fileNameWithFormat,
                datedDestinationFolder,
                updatedFileName,
                groupId,
                goProFileType.ToString(),
                failureType.ToString(),
                exceptionData,
                finalDestination
            };
        }

        public string ReportCSV()
        {
            return fullFilePath + "," +
                fileNameWithFormat + "," +
                datedDestinationFolder + "," +
                updatedFileName + "," +
                groupId + "," +
                goProFileType.ToString() + "," +
                failureType.ToString() + "," +
                exceptionData + "," +
                finalDestination;
        }

        public FileEntry(string newFullFilePath)
        {
            exceptionData = "";
            failureType = FailureType.NULL;
            groupId = "";
            updatedFileName = "NOT_SET";
            finalDestination = "";

            fullFilePath = newFullFilePath;

            // save just the file name with format extension
            fileNameWithFormat = fullFilePath.Substring(fullFilePath.LastIndexOf('\\') + 1);

            // fetch file information
            FileInfo fileInformation = new FileInfo(fullFilePath);

            // save the day folder this file should go to
            datedDestinationFolder = fileInformation.LastWriteTime.ToString("yyyy_MM_dd");

            // our file names must start with a G and have a length of 12 characters
            if (!fileNameWithFormat.StartsWith("G") || fileNameWithFormat.Length != 12)
            {
                goProFileType = GoProFileType.INVALID;
            }
            else if (fileNameWithFormat.EndsWith(".MP4") || fileNameWithFormat.EndsWith(".mp4"))
            {
                goProFileType = GoProFileType.VIDEO;

                //// video... I forget exactly what I was doing here but think it was taking care of series files
                if (fileNameWithFormat.StartsWith("GOPR"))
                {
                    updatedFileName = fileNameWithFormat.Substring(4, 4) + "00" + fileNameWithFormat.Substring(8);
                }
                else
                {
                    updatedFileName = fileNameWithFormat.Substring(4, 4) + fileNameWithFormat.Substring(2, 2) + fileNameWithFormat.Substring(8);
                }
            }
            else if (fileNameWithFormat.EndsWith(".jpg") || fileNameWithFormat.EndsWith(".JPG"))
            {
                if (fileNameWithFormat.StartsWith("GOPR"))
                {
                    goProFileType = GoProFileType.PHOTO;

                    //single
                    updatedFileName = fileNameWithFormat.Substring(4);

                    //doSomething(args, 1, (args.destination + "\\photo\\" + timeStampFolder), newFileName, file);
                }
                else
                {
                    goProFileType = GoProFileType.PHOTO_GROUP;
                    //burst/timelapse

                    // need to pull out group number
                    groupId = fileNameWithFormat.Substring(1, 3);
                    updatedFileName = fileNameWithFormat.Substring(4);

                    //doSomething(args, 2, (args.destination + "\\grouping\\" + timeStampFolder + "\\" + groupName), newFileName, file);
                }
            }
        }
    }
}
