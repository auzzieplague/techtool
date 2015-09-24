namespace TechTool
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.outputPanel = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.DisableAll = new System.Windows.Forms.Button();
            this.EnableAll = new System.Windows.Forms.Button();
            this.PurgeStartups = new System.Windows.Forms.Button();
            this.DisabledStartupList = new System.Windows.Forms.ListBox();
            this.EnabledStartupList = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fullmalwarescan = new System.Windows.Forms.Button();
            this.malwarescanButton = new System.Windows.Forms.Button();
            this.SecurityOutput = new System.Windows.Forms.TextBox();
            this.PasswordButton = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.serviceNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(768, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Write File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(768, 397);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Read Reg";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(768, 426);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Write Reg";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(768, 248);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 30);
            this.button6.TabIndex = 5;
            this.button6.Text = "MessageBox";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(546, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(141, 31);
            this.button7.TabIndex = 6;
            this.button7.Text = "Open Recent Items";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 550);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.outputPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PC Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Observations";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 490);
            this.textBox1.TabIndex = 1;
            // 
            // outputPanel
            // 
            this.outputPanel.Location = new System.Drawing.Point(3, 6);
            this.outputPanel.Multiline = true;
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputPanel.Size = new System.Drawing.Size(332, 512);
            this.outputPanel.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.DisableAll);
            this.tabPage2.Controls.Add(this.EnableAll);
            this.tabPage2.Controls.Add(this.PurgeStartups);
            this.tabPage2.Controls.Add(this.DisabledStartupList);
            this.tabPage2.Controls.Add(this.EnabledStartupList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(713, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Startup";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DISABLE NORTON: - todo: Test running Shell registry tool ";
            // 
            // DisableAll
            // 
            this.DisableAll.Location = new System.Drawing.Point(237, 233);
            this.DisableAll.Name = "DisableAll";
            this.DisableAll.Size = new System.Drawing.Size(111, 25);
            this.DisableAll.TabIndex = 4;
            this.DisableAll.Text = "v Disable All";
            this.DisableAll.UseVisualStyleBackColor = true;
            this.DisableAll.Click += new System.EventHandler(this.DisableAll_Click);
            // 
            // EnableAll
            // 
            this.EnableAll.Location = new System.Drawing.Point(92, 233);
            this.EnableAll.Name = "EnableAll";
            this.EnableAll.Size = new System.Drawing.Size(122, 25);
            this.EnableAll.TabIndex = 3;
            this.EnableAll.Text = "^ Enable All";
            this.EnableAll.UseVisualStyleBackColor = true;
            this.EnableAll.Click += new System.EventHandler(this.EnableAll_Click);
            // 
            // PurgeStartups
            // 
            this.PurgeStartups.Location = new System.Drawing.Point(149, 495);
            this.PurgeStartups.Name = "PurgeStartups";
            this.PurgeStartups.Size = new System.Drawing.Size(155, 23);
            this.PurgeStartups.TabIndex = 2;
            this.PurgeStartups.Text = "x Purge Old Startups";
            this.PurgeStartups.UseVisualStyleBackColor = true;
            this.PurgeStartups.Click += new System.EventHandler(this.PurgeStartups_Click);
            // 
            // DisabledStartupList
            // 
            this.DisabledStartupList.FormattingEnabled = true;
            this.DisabledStartupList.Location = new System.Drawing.Point(22, 264);
            this.DisabledStartupList.Name = "DisabledStartupList";
            this.DisabledStartupList.Size = new System.Drawing.Size(434, 225);
            this.DisabledStartupList.TabIndex = 1;
            this.DisabledStartupList.SelectedIndexChanged += new System.EventHandler(this.DisabledStartupList_SelectedIndexChanged);
            // 
            // EnabledStartupList
            // 
            this.EnabledStartupList.FormattingEnabled = true;
            this.EnabledStartupList.Location = new System.Drawing.Point(22, 36);
            this.EnabledStartupList.Name = "EnabledStartupList";
            this.EnabledStartupList.Size = new System.Drawing.Size(434, 186);
            this.EnabledStartupList.TabIndex = 0;
            this.EnabledStartupList.SelectedIndexChanged += new System.EventHandler(this.EnabledStartupList_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fullmalwarescan);
            this.tabPage3.Controls.Add(this.malwarescanButton);
            this.tabPage3.Controls.Add(this.SecurityOutput);
            this.tabPage3.Controls.Add(this.PasswordButton);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(713, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Security";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fullmalwarescan
            // 
            this.fullmalwarescan.Location = new System.Drawing.Point(166, 17);
            this.fullmalwarescan.Name = "fullmalwarescan";
            this.fullmalwarescan.Size = new System.Drawing.Size(132, 31);
            this.fullmalwarescan.TabIndex = 8;
            this.fullmalwarescan.Text = "Full Malware Scan";
            this.fullmalwarescan.UseVisualStyleBackColor = true;
            this.fullmalwarescan.Click += new System.EventHandler(this.fullmalwarescan_Click);
            // 
            // malwarescanButton
            // 
            this.malwarescanButton.Location = new System.Drawing.Point(19, 17);
            this.malwarescanButton.Name = "malwarescanButton";
            this.malwarescanButton.Size = new System.Drawing.Size(132, 31);
            this.malwarescanButton.TabIndex = 7;
            this.malwarescanButton.Text = "Malware Scan";
            this.malwarescanButton.UseVisualStyleBackColor = true;
            this.malwarescanButton.Click += new System.EventHandler(this.malwarescanButton_Click);
            // 
            // SecurityOutput
            // 
            this.SecurityOutput.Location = new System.Drawing.Point(19, 59);
            this.SecurityOutput.Multiline = true;
            this.SecurityOutput.Name = "SecurityOutput";
            this.SecurityOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecurityOutput.Size = new System.Drawing.Size(668, 342);
            this.SecurityOutput.TabIndex = 1;
            // 
            // PasswordButton
            // 
            this.PasswordButton.Location = new System.Drawing.Point(401, 17);
            this.PasswordButton.Name = "PasswordButton";
            this.PasswordButton.Size = new System.Drawing.Size(139, 31);
            this.PasswordButton.TabIndex = 0;
            this.PasswordButton.Text = "Backup Passwords";
            this.PasswordButton.UseVisualStyleBackColor = true;
            this.PasswordButton.Click += new System.EventHandler(this.PasswordButton_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(713, 524);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Cleanup";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(713, 524);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Scripts";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(713, 524);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // serviceNumber
            // 
            this.serviceNumber.Location = new System.Drawing.Point(71, 12);
            this.serviceNumber.Name = "serviceNumber";
            this.serviceNumber.Size = new System.Drawing.Size(194, 20);
            this.serviceNumber.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Job ID";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(358, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 22);
            this.button8.TabIndex = 13;
            this.button8.Text = "Start";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(276, 12);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 14;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 599);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serviceNumber);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Tech Tool v0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox serviceNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputPanel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox DisabledStartupList;
        private System.Windows.Forms.ListBox EnabledStartupList;
        private System.Windows.Forms.Button PurgeStartups;
        private System.Windows.Forms.Button DisableAll;
        private System.Windows.Forms.Button EnableAll;
        private System.Windows.Forms.Button PasswordButton;
        private System.Windows.Forms.TextBox SecurityOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button malwarescanButton;
        private System.Windows.Forms.Button fullmalwarescan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button printButton;
    }
}

