namespace Goldberg_Profile_Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.steamIDTextBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.changeSettingsFolderButton = new System.Windows.Forms.Button();
            this.settingsFolderTextBox = new System.Windows.Forms.TextBox();
            this.revertSettingsFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // avatarPanel
            // 
            this.avatarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.avatarPanel.Location = new System.Drawing.Point(12, 31);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(184, 184);
            this.avatarPanel.TabIndex = 0;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(211, 113);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(195, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // steamIDTextBox
            // 
            this.steamIDTextBox.Location = new System.Drawing.Point(433, 113);
            this.steamIDTextBox.Name = "steamIDTextBox";
            this.steamIDTextBox.Size = new System.Drawing.Size(195, 20);
            this.steamIDTextBox.TabIndex = 2;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(208, 97);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(55, 13);
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(430, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Steam ID";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(489, 170);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(59, 25);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Click to Change Avatar";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(208, 154);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 7;
            this.languageLabel.Text = "Language";
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(211, 170);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(195, 21);
            this.languageComboBox.TabIndex = 8;
            // 
            // changeSettingsFolderButton
            // 
            this.changeSettingsFolderButton.Location = new System.Drawing.Point(323, 60);
            this.changeSettingsFolderButton.Name = "changeSettingsFolderButton";
            this.changeSettingsFolderButton.Size = new System.Drawing.Size(195, 25);
            this.changeSettingsFolderButton.TabIndex = 9;
            this.changeSettingsFolderButton.Text = "Open Settings Folder";
            this.changeSettingsFolderButton.UseVisualStyleBackColor = true;
            // 
            // settingsFolderTextBox
            // 
            this.settingsFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsFolderTextBox.Location = new System.Drawing.Point(265, 34);
            this.settingsFolderTextBox.Name = "settingsFolderTextBox";
            this.settingsFolderTextBox.ReadOnly = false;
            this.settingsFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.settingsFolderTextBox.Size = new System.Drawing.Size(300, 20);
            this.settingsFolderTextBox.TabIndex = 10;
            this.settingsFolderTextBox.TabStop = false;
            this.settingsFolderTextBox.WordWrap = false;
            // 
            // revertSettingsFolderButton
            // 
            this.revertSettingsFolderButton.Location = new System.Drawing.Point(570, 33);
            this.revertSettingsFolderButton.Name = "revertSettingsFolderButton";
            this.revertSettingsFolderButton.Size = new System.Drawing.Size(60, 22);
            this.revertSettingsFolderButton.TabIndex = 11;
            this.revertSettingsFolderButton.Text = "Revert";
            this.revertSettingsFolderButton.UseVisualStyleBackColor = true;
            this.revertSettingsFolderButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 265);
            this.Controls.Add(this.revertSettingsFolderButton);
            this.Controls.Add(this.settingsFolderTextBox);
            this.Controls.Add(this.changeSettingsFolderButton);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.steamIDTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.avatarPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Goldberg Profile Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel avatarPanel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox steamIDTextBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button changeSettingsFolderButton;
        private System.Windows.Forms.TextBox settingsFolderTextBox;
        private System.Windows.Forms.Button revertSettingsFolderButton;
    }
}

