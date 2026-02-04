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

namespace Goldberg_Profile_Editor
{
    public partial class Form1 : Form
    {
        private string settingsFolderPath;
        private string configPathFile;
        private string defaultSettingsFolder;
        private string exeConfigPathFile;
        private string originalSettingsFolderPath;
        private bool isEditingSettingsFolder = false;

        public Form1()
        {
            InitializeComponent();
            avatarPanel.Cursor = Cursors.Hand;
            exeConfigPathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config_path.cfg");
            defaultSettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GSE Saves", "settings");
            settingsFolderPath = GetSettingsFolderPath();
            originalSettingsFolderPath = settingsFolderPath;
            changeSettingsFolderButton.Click += ChangeSettingsFolderButton_Click;
            settingsFolderTextBox.TextChanged += SettingsFolderTextBox_TextChanged;
            revertSettingsFolderButton.Click += RevertSettingsFolderButton_Click;
            UpdateSettingsFolderTextBox();
            LoadUserAvatar();
            InitializeLanguageComboBox();
            LoadUserInfo();
            saveButton.Click += SaveButton_Click;
            avatarPanel.Click += AvatarPanel_Click;
        }

        private string GetSettingsFolderPath()
        {
            try
            {
                if (File.Exists(exeConfigPathFile))
                {
                    string customPath = File.ReadAllText(exeConfigPathFile).Trim();
                    if (!string.IsNullOrEmpty(customPath) && Directory.Exists(customPath))
                        return customPath;
                }
            }
            catch { }
            return defaultSettingsFolder;
        }

        private void SetSettingsFolderPath(string newPath)
        {
            if (!string.IsNullOrEmpty(newPath) && newPath != defaultSettingsFolder)
            {
                Directory.CreateDirectory(newPath);
                File.WriteAllText(exeConfigPathFile, newPath);
                settingsFolderPath = newPath;
            }
            else
            {
                settingsFolderPath = defaultSettingsFolder;
            }
            UpdateSettingsFolderTextBox();
        }

        private void UpdateSettingsFolderTextBox()
        {
            if (File.Exists(exeConfigPathFile))
                settingsFolderTextBox.Text = settingsFolderPath;
            else
                settingsFolderTextBox.Text = defaultSettingsFolder;
            originalSettingsFolderPath = settingsFolderTextBox.Text;
            isEditingSettingsFolder = false;
            changeSettingsFolderButton.Text = "Open Settings Folder";
            revertSettingsFolderButton.Visible = false;
        }

        private void SettingsFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (settingsFolderTextBox.Text != originalSettingsFolderPath)
            {
                isEditingSettingsFolder = true;
                changeSettingsFolderButton.Text = "Save";
                revertSettingsFolderButton.Visible = true;
            }
            else
            {
                isEditingSettingsFolder = false;
                changeSettingsFolderButton.Text = "Open Settings Folder";
                revertSettingsFolderButton.Visible = false;
            }
        }

        private void RevertSettingsFolderButton_Click(object sender, EventArgs e)
        {
            settingsFolderTextBox.Text = originalSettingsFolderPath;
            isEditingSettingsFolder = false;
            changeSettingsFolderButton.Text = "Open Settings Folder";
            revertSettingsFolderButton.Visible = false;
        }

        private void ChangeSettingsFolderButton_Click(object sender, EventArgs e)
        {
            if (isEditingSettingsFolder)
            {
                string newPath = settingsFolderTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(newPath))
                {
                    SetSettingsFolderPath(newPath);
                    originalSettingsFolderPath = settingsFolderPath;
                    isEditingSettingsFolder = false;
                    changeSettingsFolderButton.Text = "Open Settings Folder";
                    revertSettingsFolderButton.Visible = false;
                    // Only create config if not default
                    if (settingsFolderPath != defaultSettingsFolder)
                    {
                        string iniPath = Path.Combine(settingsFolderPath, "configs.user.ini");
                        if (!File.Exists(iniPath))
                        {
                            File.WriteAllText(iniPath, "account_name=\naccount_steamid=\nlanguage=english\n");
                        }
                    }
                    MessageBox.Show($"Settings folder changed to:\n{settingsFolderPath}", "Settings Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserAvatar();
                    LoadUserInfo();
                }
            }
            else
            {
                // Open folder in explorer
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", settingsFolderPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeLanguageComboBox()
        {
            var languages = new List<(string Display, string Code)>
            {
                ("Arabic", "arabic"),
                ("Bulgarian", "bulgarian"),
                ("Chinese (Simplified)", "schinese"),
                ("Chinese (Traditional)", "tchinese"),
                ("Czech", "czech"),
                ("Danish", "danish"),
                ("Dutch", "dutch"),
                ("English", "english"),
                ("Finnish", "finnish"),
                ("French", "french"),
                ("German", "german"),
                ("Greek", "greek"),
                ("Hungarian", "hungarian"),
                ("Indonesian", "indonesian"),
                ("Italian", "italian"),
                ("Japanese", "japanese"),
                ("Korean", "koreana"),
                ("Norwegian", "norwegian"),
                ("Polish", "polish"),
                ("Portuguese", "portuguese"),
                ("Portuguese-Brazil", "brazilian"),
                ("Romanian", "romanian"),
                ("Russian", "russian"),
                ("Spanish-Spain", "spanish"),
                ("Spanish-Latin America", "latam"),
                ("Swedish", "swedish"),
                ("Thai", "thai"),
                ("Turkish", "turkish"),
                ("Ukrainian", "ukrainian"),
                ("Vietnamese", "vietnamese")
            };
            languageComboBox.Items.Clear();
            foreach (var lang in languages)
            {
                languageComboBox.Items.Add(new ComboBoxItem(lang.Display, lang.Code));
            }
        }

        private class ComboBoxItem
        {
            public string Display { get; }
            public string Code { get; }
            public ComboBoxItem(string display, string code)
            {
                Display = display;
                Code = code;
            }
            public override string ToString() => Display;
        }

        private void LoadUserAvatar()
        {
            try
            {
                // Use settingsFolderPath
                if (!Directory.Exists(settingsFolderPath))
                {
                    SetDefaultAvatar();
                    return;
                }

                // Look for avatar files with different extensions
                string[] possibleExtensions = { ".png", ".jpg", ".jpeg" };
                string avatarPath = null;

                foreach (string extension in possibleExtensions)
                {
                    string testPath = Path.Combine(settingsFolderPath, "account_avatar" + extension);
                    if (File.Exists(testPath))
                    {
                        avatarPath = testPath;
                        break;
                    }
                }

                if (avatarPath != null)
                {
                    using (Image originalImage = Image.FromFile(avatarPath))
                    {
                        Bitmap resizedAvatar = new Bitmap(originalImage, new Size(184, 184));
                        avatarPanel.BackgroundImage = resizedAvatar;
                        avatarPanel.BackgroundImageLayout = ImageLayout.Center;
                        avatarPanel.Size = new Size(184, 184);
                    }
                }
                else
                {
                    // Try to copy account_avatar_default from steam_settings folder
                    string steamSettingsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "steam_settings");
                    bool copied = false;

                    foreach (string extension in possibleExtensions)
                    {
                        string defaultAvatarPath = Path.Combine(steamSettingsFolder, "account_avatar_default" + extension);
                        if (File.Exists(defaultAvatarPath))
                        {
                            string destPath = Path.Combine(settingsFolderPath, "account_avatar" + extension);
                            File.Copy(defaultAvatarPath, destPath, true);
                            avatarPath = destPath;
                            copied = true;
                            break;
                        }
                    }

                    if (copied && avatarPath != null)
                    {
                        using (Image originalImage = Image.FromFile(avatarPath))
                        {
                            Bitmap resizedAvatar = new Bitmap(originalImage, new Size(184, 184));
                            avatarPanel.BackgroundImage = resizedAvatar;
                            avatarPanel.BackgroundImageLayout = ImageLayout.Center;
                            avatarPanel.Size = new Size(184, 184);
                        }
                    }
                    else
                    {
                        SetDefaultAvatar();
                    }
                }
            }
            catch (Exception ex)
            {
                SetDefaultAvatar();
                MessageBox.Show($"Error loading avatar: {ex.Message}", "Avatar Load Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetDefaultAvatar()
        {
            // Create a default avatar (gray placeholder)
            Bitmap defaultAvatar = new Bitmap(184, 184);
            using (Graphics g = Graphics.FromImage(defaultAvatar))
            {
                g.Clear(Color.LightGray);
                g.DrawString("No Avatar", new Font("Arial", 12), Brushes.DarkGray, 50, 80);
            }
            
            avatarPanel.BackgroundImage = defaultAvatar;
            avatarPanel.BackgroundImageLayout = ImageLayout.Center;
            avatarPanel.Size = new Size(184, 184);
        }

        private void LoadUserInfo()
        {
            try
            {
                string iniPath = Path.Combine(settingsFolderPath, "configs.user.ini");
                if (!File.Exists(iniPath))
                    return;
                string[] lines = File.ReadAllLines(iniPath);
                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    if (trimmed.StartsWith("account_name="))
                    {
                        usernameTextBox.Text = trimmed.Substring("account_name=".Length);
                    }
                    else if (trimmed.StartsWith("account_steamid="))
                    {
                        steamIDTextBox.Text = trimmed.Substring("account_steamid=".Length);
                    }
                    else if (trimmed.StartsWith("language="))
                    {
                        string langCode = trimmed.Substring("language=".Length);
                        foreach (ComboBoxItem item in languageComboBox.Items)
                        {
                            if (item.Code == langCode)
                            {
                                languageComboBox.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
                if (languageComboBox.SelectedIndex == -1 && languageComboBox.Items.Count > 0)
                {
                    foreach (ComboBoxItem item in languageComboBox.Items)
                    {
                        if (item.Code == "english")
                        {
                            languageComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user info: {ex.Message}", "User Info Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string iniPath = Path.Combine(settingsFolderPath, "configs.user.ini");
                if (!File.Exists(iniPath))
                {
                    MessageBox.Show("INI file not found. Cannot save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] lines = File.ReadAllLines(iniPath);
                bool foundLang = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    string trimmed = lines[i].Trim();
                    if (trimmed.StartsWith("account_name="))
                    {
                        lines[i] = "account_name=" + usernameTextBox.Text;
                    }
                    else if (trimmed.StartsWith("account_steamid="))
                    {
                        lines[i] = "account_steamid=" + steamIDTextBox.Text;
                    }
                    else if (trimmed.StartsWith("language="))
                    {
                        var selected = languageComboBox.SelectedItem as ComboBoxItem;
                        lines[i] = "language=" + (selected != null ? selected.Code : "english");
                        foundLang = true;
                    }
                }
                if (!foundLang)
                {
                    var selected = languageComboBox.SelectedItem as ComboBoxItem;
                    var langLine = "language=" + (selected != null ? selected.Code : "english");
                    var linesList = lines.ToList();
                    linesList.Add(langLine);
                    lines = linesList.ToArray();
                }
                File.WriteAllLines(iniPath, lines);
                MessageBox.Show("User info saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user info: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AvatarPanel_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select Avatar Image";
                    ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        bool needsResize = false;
                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            if (img.Width != 184 || img.Height != 184)
                            {
                                var result = MessageBox.Show(
                                    "Image is not 184x184 pixels. Do you want to resize it to fit?",
                                    "Resize Image?",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );
                                if (result == DialogResult.Yes)
                                {
                                    needsResize = true;
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }

                        if (!Directory.Exists(settingsFolderPath))
                            Directory.CreateDirectory(settingsFolderPath);
                        string destPath = Path.Combine(settingsFolderPath, "account_avatar.png");

                        using (Image img = Image.FromFile(ofd.FileName))
                        {
                            Image toSave = img;
                            if (needsResize)
                            {
                                Bitmap resized = new Bitmap(img, new Size(184, 184));
                                toSave = resized;
                            }
                            toSave.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                            if (needsResize && toSave is Bitmap)
                                toSave.Dispose();
                        }

                        LoadUserAvatar(); // Refresh avatar
                        MessageBox.Show("Avatar updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating avatar: {ex.Message}", "Avatar Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
