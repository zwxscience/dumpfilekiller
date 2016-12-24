namespace dumpfilekiller
{
    partial class configForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fileCreateTimecheckBox = new System.Windows.Forms.CheckBox();
            this.fileModifiTimecheckBox = new System.Windows.Forms.CheckBox();
            this.fileSizecheckBox = new System.Windows.Forms.CheckBox();
            this.FileNamecheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "删除文件类型";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "所有文件";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "指定文件类型用；隔开";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = ".jpg;.txt;";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.fileCreateTimecheckBox);
            this.groupBox2.Controls.Add(this.fileModifiTimecheckBox);
            this.groupBox2.Controls.Add(this.fileSizecheckBox);
            this.groupBox2.Controls.Add(this.FileNamecheckBox);
            this.groupBox2.Location = new System.Drawing.Point(16, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "重复标准判断";
            // 
            // fileCreateTimecheckBox
            // 
            this.fileCreateTimecheckBox.AutoSize = true;
            this.fileCreateTimecheckBox.Location = new System.Drawing.Point(109, 20);
            this.fileCreateTimecheckBox.Name = "fileCreateTimecheckBox";
            this.fileCreateTimecheckBox.Size = new System.Drawing.Size(96, 16);
            this.fileCreateTimecheckBox.TabIndex = 7;
            this.fileCreateTimecheckBox.Text = "文件创建时间";
            this.fileCreateTimecheckBox.UseVisualStyleBackColor = true;
            // 
            // fileModifiTimecheckBox
            // 
            this.fileModifiTimecheckBox.AutoSize = true;
            this.fileModifiTimecheckBox.Location = new System.Drawing.Point(109, 45);
            this.fileModifiTimecheckBox.Name = "fileModifiTimecheckBox";
            this.fileModifiTimecheckBox.Size = new System.Drawing.Size(96, 16);
            this.fileModifiTimecheckBox.TabIndex = 6;
            this.fileModifiTimecheckBox.Text = "文件修改时间";
            this.fileModifiTimecheckBox.UseVisualStyleBackColor = true;
            // 
            // fileSizecheckBox
            // 
            this.fileSizecheckBox.AutoSize = true;
            this.fileSizecheckBox.Checked = true;
            this.fileSizecheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileSizecheckBox.Location = new System.Drawing.Point(6, 45);
            this.fileSizecheckBox.Name = "fileSizecheckBox";
            this.fileSizecheckBox.Size = new System.Drawing.Size(72, 16);
            this.fileSizecheckBox.TabIndex = 5;
            this.fileSizecheckBox.Text = "文件大小";
            this.fileSizecheckBox.UseVisualStyleBackColor = true;
            // 
            // FileNamecheckBox
            // 
            this.FileNamecheckBox.AutoSize = true;
            this.FileNamecheckBox.Checked = true;
            this.FileNamecheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FileNamecheckBox.Location = new System.Drawing.Point(6, 23);
            this.FileNamecheckBox.Name = "FileNamecheckBox";
            this.FileNamecheckBox.Size = new System.Drawing.Size(72, 16);
            this.FileNamecheckBox.TabIndex = 4;
            this.FileNamecheckBox.Text = "文件名称";
            this.FileNamecheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "如果都不选择会全部删除哦";
            // 
            // configForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "configForm";
            this.Text = "删除配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.configForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox fileCreateTimecheckBox;
        private System.Windows.Forms.CheckBox fileModifiTimecheckBox;
        private System.Windows.Forms.CheckBox fileSizecheckBox;
        private System.Windows.Forms.CheckBox FileNamecheckBox;
        private System.Windows.Forms.Label label2;
    }
}