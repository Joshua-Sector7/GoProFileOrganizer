namespace GoProFileOrganizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxRootFolder = new System.Windows.Forms.TextBox();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.richTextBoxFeedback = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPractiveRun = new System.Windows.Forms.CheckBox();
            this.textBoxProcessingStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxRootFolder
            // 
            this.textBoxRootFolder.AllowDrop = true;
            this.textBoxRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRootFolder.Location = new System.Drawing.Point(11, 31);
            this.textBoxRootFolder.Name = "textBoxRootFolder";
            this.textBoxRootFolder.Size = new System.Drawing.Size(910, 20);
            this.textBoxRootFolder.TabIndex = 0;
            this.textBoxRootFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxRootFolder_DragDrop);
            this.textBoxRootFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxRootFolder_DragEnter);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.AllowDrop = true;
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(11, 77);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(910, 20);
            this.textBoxDestination.TabIndex = 1;
            this.textBoxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxDestination_DragDrop);
            this.textBoxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxDestination_DragEnter);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(12, 103);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 2;
            this.buttonGo.Text = "Go/Stop";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // richTextBoxFeedback
            // 
            this.richTextBoxFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxFeedback.Location = new System.Drawing.Point(12, 132);
            this.richTextBoxFeedback.Name = "richTextBoxFeedback";
            this.richTextBoxFeedback.Size = new System.Drawing.Size(910, 377);
            this.richTextBoxFeedback.TabIndex = 3;
            this.richTextBoxFeedback.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Source Folder - Drag Folder Into Box";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination Folder - Drag Folder Into Box";
            // 
            // checkBoxPractiveRun
            // 
            this.checkBoxPractiveRun.AutoSize = true;
            this.checkBoxPractiveRun.Checked = true;
            this.checkBoxPractiveRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPractiveRun.Location = new System.Drawing.Point(93, 107);
            this.checkBoxPractiveRun.Name = "checkBoxPractiveRun";
            this.checkBoxPractiveRun.Size = new System.Drawing.Size(88, 17);
            this.checkBoxPractiveRun.TabIndex = 9;
            this.checkBoxPractiveRun.Text = "Practice Run";
            this.checkBoxPractiveRun.UseVisualStyleBackColor = true;
            // 
            // textBoxProcessingStatus
            // 
            this.textBoxProcessingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProcessingStatus.Location = new System.Drawing.Point(187, 103);
            this.textBoxProcessingStatus.Name = "textBoxProcessingStatus";
            this.textBoxProcessingStatus.ReadOnly = true;
            this.textBoxProcessingStatus.Size = new System.Drawing.Size(735, 20);
            this.textBoxProcessingStatus.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 522);
            this.Controls.Add(this.textBoxProcessingStatus);
            this.Controls.Add(this.checkBoxPractiveRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxFeedback);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.textBoxRootFolder);
            this.Name = "Form1";
            this.Text = "GoProFileOrganizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRootFolder;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.RichTextBox richTextBoxFeedback;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxPractiveRun;
        private System.Windows.Forms.TextBox textBoxProcessingStatus;
    }
}

