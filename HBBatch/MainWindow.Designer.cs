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
            this.btnSimulate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sortInput = new System.Windows.Forms.CheckBox();
            this.groupFilename = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.startAt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digits)).BeginInit();
            this.groupSort.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupFilename.SuspendLayout();
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
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(224, 466);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(100, 23);
            this.btnSimulate.TabIndex = 17;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pathHandbrakeCLI);
            this.groupBox1.Controls.Add(this.btnOpenFileHandbrakeCLI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 78);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Handbrake CLI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.sortInput);
            this.groupBox2.Controls.Add(this.pathInputFolder);
            this.groupBox2.Controls.Add(this.searchSubfolders);
            this.groupBox2.Controls.Add(this.btnOpenInputFolder);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupSort);
            this.groupBox2.Location = new System.Drawing.Point(13, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 176);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupFilename);
            this.groupBox3.Controls.Add(this.pathOutputFolder);
            this.groupBox3.Controls.Add(this.btnOpenOutputFolder);
            this.groupBox3.Controls.Add(this.renameOutputFiles);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 180);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output settings";
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 546);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEncode);
            this.Name = "MainWindow";
            this.Text = "HBBatch 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.startAt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digits)).EndInit();
            this.groupSort.ResumeLayout(false);
            this.groupSort.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupFilename.ResumeLayout(false);
            this.groupFilename.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox sortInput;
        private System.Windows.Forms.GroupBox groupFilename;
    }
}

