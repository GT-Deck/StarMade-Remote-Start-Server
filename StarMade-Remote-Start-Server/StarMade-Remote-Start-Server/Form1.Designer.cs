namespace StarMade_Remote_Start_Server
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
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.batchFilebtn = new System.Windows.Forms.Button();
            this.batchFileLbl = new System.Windows.Forms.Label();
            this.connectionLog = new System.Windows.Forms.TextBox();
            this.whitelistBtn = new System.Windows.Forms.Button();
            this.whiteListLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // batchFilebtn
            // 
            this.batchFilebtn.Location = new System.Drawing.Point(6, 2);
            this.batchFilebtn.Name = "batchFilebtn";
            this.batchFilebtn.Size = new System.Drawing.Size(75, 23);
            this.batchFilebtn.TabIndex = 0;
            this.batchFilebtn.Text = "Set";
            this.toolTip1.SetToolTip(this.batchFilebtn, "Folder that contains the Server Batch File");
            this.batchFilebtn.UseVisualStyleBackColor = true;
            this.batchFilebtn.Click += new System.EventHandler(this.batchFilebtn_Click);
            // 
            // batchFileLbl
            // 
            this.batchFileLbl.AutoSize = true;
            this.batchFileLbl.Location = new System.Drawing.Point(87, 7);
            this.batchFileLbl.Name = "batchFileLbl";
            this.batchFileLbl.Size = new System.Drawing.Size(148, 13);
            this.batchFileLbl.TabIndex = 1;
            this.batchFileLbl.Text = "Set Server Batch file Location";
            // 
            // connectionLog
            // 
            this.connectionLog.Location = new System.Drawing.Point(6, 91);
            this.connectionLog.Multiline = true;
            this.connectionLog.Name = "connectionLog";
            this.connectionLog.ReadOnly = true;
            this.connectionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.connectionLog.Size = new System.Drawing.Size(362, 159);
            this.connectionLog.TabIndex = 2;
            this.toolTip1.SetToolTip(this.connectionLog, "Displays logs for accepted connections");
            // 
            // whitelistBtn
            // 
            this.whitelistBtn.Location = new System.Drawing.Point(6, 31);
            this.whitelistBtn.Name = "whitelistBtn";
            this.whitelistBtn.Size = new System.Drawing.Size(75, 23);
            this.whitelistBtn.TabIndex = 3;
            this.whitelistBtn.Text = "Set";
            this.toolTip1.SetToolTip(this.whitelistBtn, "Folder that contains your \"whitelist.txt\" with ip address per line\r\n");
            this.whitelistBtn.UseVisualStyleBackColor = true;
            this.whitelistBtn.Click += new System.EventHandler(this.whitelistBtn_Click);
            // 
            // whiteListLbl
            // 
            this.whiteListLbl.AutoSize = true;
            this.whiteListLbl.Location = new System.Drawing.Point(87, 36);
            this.whiteListLbl.Name = "whiteListLbl";
            this.whiteListLbl.Size = new System.Drawing.Size(114, 13);
            this.whiteListLbl.TabIndex = 4;
            this.whiteListLbl.Text = "Set WhiteList Location";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(6, 60);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start";
            this.toolTip1.SetToolTip(this.startBtn, "Starts the application listening for incoming commands");
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(293, 62);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 6;
            this.stopBtn.Text = "Quit";
            this.toolTip1.SetToolTip(this.stopBtn, "Ends the server listening for incoming commands and closes");
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 262);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.whiteListLbl);
            this.Controls.Add(this.whitelistBtn);
            this.Controls.Add(this.connectionLog);
            this.Controls.Add(this.batchFileLbl);
            this.Controls.Add(this.batchFilebtn);
            this.Name = "Form1";
            this.Text = "Starmade Remote Start Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button batchFilebtn;
        private System.Windows.Forms.Label batchFileLbl;
        private System.Windows.Forms.TextBox connectionLog;
        private System.Windows.Forms.Button whitelistBtn;
        private System.Windows.Forms.Label whiteListLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip toolTip1;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        #endregion
    }
}

