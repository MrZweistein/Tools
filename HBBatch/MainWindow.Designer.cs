namespace HBBatch
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.startAt = new System.Windows.Forms.NumericUpDown();
            this.digits = new System.Windows.Forms.NumericUpDown();
            this.searchSubfolders = new System.Windows.Forms.CheckBox();
            this.sortDescending = new System.Windows.Forms.CheckBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpenFileHandbrakeCLI = new System.Windows.Forms.Button();
            this.pathHandbrakeCLI = new System.Windows.Forms.TextBox();
            this.pathInputFolder = new System.Windows.Forms.TextBox();
            this.pathOutputFolder = new System.Windows.Forms.TextBox();
            this.btnOpenInputFolder = new System.Windows.Forms.Button();
            this.btnOpenOutputFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.prefix = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.sortByDate = new System.Windows.Forms.RadioButton();
            this.sortByName = new System.Windows.Forms.RadioButton();
            this.groupSort = new System.Windows.Forms.GroupBox();
            this.renameOutputFiles = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupHandbrake = new System.Windows.Forms.GroupBox();
            this.groupInput = new System.Windows.Forms.GroupBox();
            this.sortInput = new System.Windows.Forms.CheckBox();
            this.groupOutput = new System.Windows.Forms.GroupBox();
            this.groupFilename = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lastStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.startAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digits)).BeginInit();
            this.groupSort.SuspendLayout();
            this.groupHandbrake.SuspendLayout();
            this.groupInput.SuspendLayout();
            this.groupOutput.SuspendLayout();
            this.groupFilename.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startAt
            // 
            this.startAt.Location = new System.Drawing.Point(260, 38);
            this.startAt.Name = "startAt";
            this.startAt.Size = new System.Drawing.Size(54, 20);
            this.startAt.TabIndex = 0;
            // 
            // digits
            // 
            this.digits.Location = new System.Drawing.Point(334, 38);
            this.digits.Name = "digits";
            this.digits.Size = new System.Drawing.Size(54, 20);
            this.digits.TabIndex = 1;
            // 
            // searchSubfolders
            // 
            this.searchSubfolders.AutoSize = true;
            this.searchSubfolders.Location = new System.Drawing.Point(13, 65);
            this.searchSubfolders.Name = "searchSubfolders";
            this.searchSubfolders.Size = new System.Drawing.Size(120, 17);
            this.searchSubfolders.TabIndex = 2;
            this.searchSubfolders.Text = "Include Sub Folders";
            this.searchSubfolders.UseVisualStyleBackColor = true;
            // 
            // sortDescending
            // 
            this.sortDescending.AutoSize = true;
            this.sortDescending.Location = new System.Drawing.Point(233, 22);
            this.sortDescending.Name = "sortDescending";
            this.sortDescending.Size = new System.Drawing.Size(112, 17);
            this.sortDescending.TabIndex = 3;
            this.sortDescending.Text = "Descending Order";
            this.sortDescending.UseVisualStyleBackColor = true;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(12, 466);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(100, 23);
            this.btnEncode.TabIndex = 4;
            this.btnEncode.Text = "Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(118, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOpenFileHandbrakeCLI
            // 
            this.btnOpenFileHandbrakeCLI.Location = new System.Drawing.Point(390, 40);
            this.btnOpenFileHandbrakeCLI.Name = "btnOpenFileHandbrakeCLI";
            this.btnOpenFileHandbrakeCLI.Size = new System.Drawing.Size(24, 23);
            this.btnOpenFileHandbrakeCLI.TabIndex = 6;
            this.btnOpenFileHandbrakeCLI.Text = "...";
            this.btnOpenFileHandbrakeCLI.UseVisualStyleBackColor = true;
            // 
            // pathHandbrakeCLI
            // 
            this.pathHandbrakeCLI.Location = new System.Drawing.Point(13, 41);
            this.pathHandbrakeCLI.Name = "pathHandbrakeCLI";
            this.pathHandbrakeCLI.Size = new System.Drawing.Size(371, 20);
            this.pathHandbrakeCLI.TabIndex = 7;
            // 
            // pathInputFolder
            // 
            this.pathInputFolder.Location = new System.Drawing.Point(13, 39);
            this.pathInputFolder.Name = "pathInputFolder";
            this.pathInputFolder.Size = new System.Drawing.Size(371, 20);
            this.pathInputFolder.TabIndex = 8;
            // 
            // pathOutputFolder
            // 
            this.pathOutputFolder.Location = new System.Drawing.Point(13, 41);
            this.pathOutputFolder.Name = "pathOutputFolder";
            this.pathOutputFolder.Size = new System.Drawing.Size(371, 20);
            this.pathOutputFolder.TabIndex = 9;
            // 
            // btnOpenInputFolder
            // 
            this.btnOpenInputFolder.Location = new System.Drawing.Point(390, 37);
            this.btnOpenInputFolder.Name = "btnOpenInputFolder";
            this.btnOpenInputFolder.Size = new System.Drawing.Size(24, 23);
            this.btnOpenInputFolder.TabIndex = 11;
            this.btnOpenInputFolder.Text = "...";
            this.btnOpenInputFolder.UseVisualStyleBackColor = true;
            // 
            // btnOpenOutputFolder
            // 
            this.btnOpenOutputFolder.Location = new System.Drawing.Point(390, 39);
            this.btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            this.btnOpenOutputFolder.Size = new System.Drawing.Size(24, 23);
            this.btnOpenOutputFolder.TabIndex = 12;
            this.btnOpenOutputFolder.Text = "...";
            this.btnOpenOutputFolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "HandbrakeCLI location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Input Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Output folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Output file prefix:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Start at:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Digits:";
            // 
            // prefix
            // 
            this.prefix.Location = new System.Drawing.Point(10, 37);
            this.prefix.Name = "prefix";
            this.prefix.Size = new System.Drawing.Size(162, 20);
            this.prefix.TabIndex = 25;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(343, 466);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // sortByDate
            // 
            this.sortByDate.AutoSize = true;
            this.sortByDate.Location = new System.Drawing.Point(23, 21);
            this.sortByDate.Name = "sortByDate";
            this.sortByDate.Size = new System.Drawing.Size(60, 17);
            this.sortByDate.TabIndex = 28;
            this.sortByDate.TabStop = true;
            this.sortByDate.Text = "by date";
            this.sortByDate.UseVisualStyleBackColor = true;
            // 
            // sortByName
            // 
            this.sortByName.AutoSize = true;
            this.sortByName.Location = new System.Drawing.Point(124, 21);
            this.sortByName.Name = "sortByName";
            this.sortByName.Size = new System.Drawing.Size(65, 17);
            this.sortByName.TabIndex = 29;
            this.sortByName.TabStop = true;
            this.sortByName.Text = "by name";
            this.sortByName.UseVisualStyleBackColor = true;
            // 
            // groupSort
            // 
            this.groupSort.Controls.Add(this.sortByDate);
            this.groupSort.Controls.Add(this.sortByName);
            this.groupSort.Controls.Add(this.sortDescending);
            this.groupSort.Location = new System.Drawing.Point(13, 109);
            this.groupSort.Name = "groupSort";
            this.groupSort.Size = new System.Drawing.Size(401, 51);
            this.groupSort.TabIndex = 30;
            this.groupSort.TabStop = false;
            this.groupSort.Text = "Order input";
            // 
            // renameOutputFiles
            // 
            this.renameOutputFiles.AutoSize = true;
            this.renameOutputFiles.Location = new System.Drawing.Point(13, 72);
            this.renameOutputFiles.Name = "renameOutputFiles";
            this.renameOutputFiles.Size = new System.Drawing.Size(120, 17);
            this.renameOutputFiles.TabIndex = 33;
            this.renameOutputFiles.Text = "Rename output files";
            this.renameOutputFiles.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Suffix-Counter:";
            // 
            // groupHandbrake
            // 
            this.groupHandbrake.Controls.Add(this.pathHandbrakeCLI);
            this.groupHandbrake.Controls.Add(this.btnOpenFileHandbrakeCLI);
            this.groupHandbrake.Controls.Add(this.label1);
            this.groupHandbrake.Location = new System.Drawing.Point(13, 13);
            this.groupHandbrake.Name = "groupHandbrake";
            this.groupHandbrake.Size = new System.Drawing.Size(430, 78);
            this.groupHandbrake.TabIndex = 35;
            this.groupHandbrake.TabStop = false;
            this.groupHandbrake.Text = "Handbrake CLI";
            // 
            // groupInput
            // 
            this.groupInput.Controls.Add(this.sortInput);
            this.groupInput.Controls.Add(this.pathInputFolder);
            this.groupInput.Controls.Add(this.searchSubfolders);
            this.groupInput.Controls.Add(this.btnOpenInputFolder);
            this.groupInput.Controls.Add(this.label2);
            this.groupInput.Controls.Add(this.groupSort);
            this.groupInput.Location = new System.Drawing.Point(13, 98);
            this.groupInput.Name = "groupInput";
            this.groupInput.Size = new System.Drawing.Size(430, 176);
            this.groupInput.TabIndex = 36;
            this.groupInput.TabStop = false;
            this.groupInput.Text = "Input settings";
            // 
            // sortInput
            // 
            this.sortInput.AutoSize = true;
            this.sortInput.Location = new System.Drawing.Point(13, 86);
            this.sortInput.Name = "sortInput";
            this.sortInput.Size = new System.Drawing.Size(71, 17);
            this.sortInput.TabIndex = 31;
            this.sortInput.Text = "Sort input";
            this.sortInput.UseVisualStyleBackColor = true;
            // 
            // groupOutput
            // 
            this.groupOutput.Controls.Add(this.groupFilename);
            this.groupOutput.Controls.Add(this.pathOutputFolder);
            this.groupOutput.Controls.Add(this.btnOpenOutputFolder);
            this.groupOutput.Controls.Add(this.renameOutputFiles);
            this.groupOutput.Controls.Add(this.label3);
            this.groupOutput.Location = new System.Drawing.Point(13, 280);
            this.groupOutput.Name = "groupOutput";
            this.groupOutput.Size = new System.Drawing.Size(430, 180);
            this.groupOutput.TabIndex = 37;
            this.groupOutput.TabStop = false;
            this.groupOutput.Text = "Output settings";
            // 
            // groupFilename
            // 
            this.groupFilename.Controls.Add(this.prefix);
            this.groupFilename.Controls.Add(this.startAt);
            this.groupFilename.Controls.Add(this.label7);
            this.groupFilename.Controls.Add(this.label6);
            this.groupFilename.Controls.Add(this.digits);
            this.groupFilename.Controls.Add(this.label4);
            this.groupFilename.Controls.Add(this.label5);
            this.groupFilename.Location = new System.Drawing.Point(13, 96);
            this.groupFilename.Name = "groupFilename";
            this.groupFilename.Size = new System.Drawing.Size(401, 71);
            this.groupFilename.TabIndex = 34;
            this.groupFilename.TabStop = false;
            this.groupFilename.Text = "Filename settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.progressBar,
            this.lastStatus,
            this.currentStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(460, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 19);
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.progressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // lastStatus
            // 
            this.lastStatus.AutoSize = false;
            this.lastStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lastStatus.Name = "lastStatus";
            this.lastStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.lastStatus.Size = new System.Drawing.Size(115, 19);
            this.lastStatus.Text = "Last run: successful";
            this.lastStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentStatus
            // 
            this.currentStatus.AutoSize = false;
            this.currentStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.currentStatus.Size = new System.Drawing.Size(230, 19);
            this.currentStatus.Text = "Ready";
            this.currentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 528);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupOutput);
            this.Controls.Add(this.groupInput);
            this.Controls.Add(this.groupHandbrake);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEncode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "HBBatch 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.startAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digits)).EndInit();
            this.groupSort.ResumeLayout(false);
            this.groupSort.PerformLayout();
            this.groupHandbrake.ResumeLayout(false);
            this.groupHandbrake.PerformLayout();
            this.groupInput.ResumeLayout(false);
            this.groupInput.PerformLayout();
            this.groupOutput.ResumeLayout(false);
            this.groupOutput.PerformLayout();
            this.groupFilename.ResumeLayout(false);
            this.groupFilename.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown startAt;
        private System.Windows.Forms.NumericUpDown digits;
        private System.Windows.Forms.CheckBox searchSubfolders;
        private System.Windows.Forms.CheckBox sortDescending;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpenFileHandbrakeCLI;
        private System.Windows.Forms.TextBox pathHandbrakeCLI;
        private System.Windows.Forms.TextBox pathInputFolder;
        private System.Windows.Forms.TextBox pathOutputFolder;
        private System.Windows.Forms.Button btnOpenInputFolder;
        private System.Windows.Forms.Button btnOpenOutputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox prefix;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton sortByDate;
        private System.Windows.Forms.RadioButton sortByName;
        private System.Windows.Forms.GroupBox groupSort;
        private System.Windows.Forms.CheckBox renameOutputFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupHandbrake;
        private System.Windows.Forms.GroupBox groupInput;
        private System.Windows.Forms.GroupBox groupOutput;
        private System.Windows.Forms.CheckBox sortInput;
        private System.Windows.Forms.GroupBox groupFilename;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lastStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel currentStatus;
    }
}

