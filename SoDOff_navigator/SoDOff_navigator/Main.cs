using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace SoDOff_navigator
{
    
    public partial class Main : Form
    {

        Locale locale = new Locale();
        public Main()
        {
            InitializeComponent();
            main = this;

            richTextBox_log.Text += "[Main] Program started." + "\n";

            comboBox_language.Items.Add("EN");
            comboBox_language.Items.Add("RU");
            comboBox_language.SelectedIndex = 0;

            checkEnvironment();
            checkRegistry();
        }

        internal static Main main;
        internal string WriteLog
        {
            set { richTextBox_log.Text += value; }
        }
        public Locale GetLocale()
        {
            return locale;
        }

        public void checkEnvironment()
        {
            if (Directory.GetCurrentDirectory().Contains(@"\windows\system32") == true 
                || Directory.GetCurrentDirectory().Contains(@"\windows\System32") == true
                || Directory.GetCurrentDirectory().Contains(@"\Windows\system32") == true
                || Directory.GetCurrentDirectory().Contains(@"\Windows\System32") == true)
            {
                MessageBox.Show("You're not supposed to launch this program from inside zip archive!", "SoDOff Navigator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void checkRegistry()
        {
            richTextBox_log.Text += "[Main] Checking registry keys." + "\n";
            string keyName = @"HKEY_CURRENT_USER\SOFTWARE\SoDOffNavigator";
            if (Registry.GetValue(keyName, "SoDOff_331", null) == null)
            {
                richTextBox_log.Text += "[Main] Creating registry keys." + "\n";
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SoDOffNavigator");
                key.SetValue("SoDOff_16", "not installed");
                key.SetValue("SoDOff_113", "not installed");
                key.SetValue("SoDOff_29", "not installed");
                key.SetValue("SoDOff_312", "not installed");
                key.SetValue("SoDOff_331", "not installed");
                key.SetValue("RidersGuild_online", "not installed");
                key.SetValue("RidersGuild_online_319", "not installed");
                key.SetValue("RidersGuild_online_321", "not installed");
                key.SetValue("RidersGuild_online_326", "not installed");
                key.SetValue("RidersGuild_offline", "not installed");
                key.Close();
            }
            else
            {
                richTextBox_log.Text += "[Main] Found previously created registry keys." + "\n";
            }
        }

        private void richTextBox_log_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBox_log.SelectionStart = richTextBox_log.Text.Length;
            // scroll it automatically
            richTextBox_log.ScrollToCaret();

            //checking, if log file exists
            if (File.Exists("log.txt") == true)
            {
                //write contents to log.txt
                System.IO.File.WriteAllText("log.txt", richTextBox_log.Text);
            }
            //checking, if log file doesn't exist
            else if (File.Exists("log.txt") == false)
            {
                //create new log file in current directory
                FileStream fs = File.Create("log.txt");
                fs.Close();
                //write contents to log.txt
                System.IO.File.WriteAllText("log.txt", richTextBox_log.Text);
            }
        }

        private void btn_install_sodoff_online_Click(object sender, EventArgs e)
        {
            SoDOff_client_installer install_dialog = new SoDOff_client_installer();
            install_dialog.Show();
        }

        private void btn_play_sodoff_online_Click(object sender, EventArgs e)
        {
            string path_16 = "";
            string path_113 = "";
            string path_29 = "";
            string path_312 = "";
            string path_331 = "";
            int versions_installed = 0;
            richTextBox_log.Text += "[Play SoDOff] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("SoDOff_16");
                if (o != null)
                {
                    path_16 = o.ToString();
                }
                o = key.GetValue("SoDOff_113");
                if (o != null)
                {
                    path_113 = o.ToString();
                }
                o = key.GetValue("SoDOff_29");
                if (o != null)
                {
                    path_29 = o.ToString();
                }
                o = key.GetValue("SoDOff_312");
                if (o != null)
                {
                    path_312 = o.ToString();
                }
                o = key.GetValue("SoDOff_331");
                if (o != null)
                {
                    path_331 = o.ToString();
                }
            }
            key.Close();

            if (path_16 != "not installed")
            {
                versions_installed++;
            }
            if (path_113 != "not installed")
            {
                versions_installed++;
            }
            if (path_29 != "not installed")
            {
                versions_installed++;
            }
            if (path_312 != "not installed")
            {
                versions_installed++;
            }
            if (path_331 != "not installed")
            {
                versions_installed++;
            }

            if (versions_installed > 1)
            {
                richTextBox_log.Text += "[Play SoDOff] Multiple versions detected!" + "\n";

                SoDOff_version_selector select_dialog = new SoDOff_version_selector();
                select_dialog.Show();
            }
            else if (versions_installed == 1)
            {
                richTextBox_log.Text += "[Play SoDOff] Single version detected!" + "\n";
                if (path_16 != "not installed")
                {
                    richTextBox_log.Text += "[Play SoDOff] Launching version: 1.6..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_16 + @"\sodoff-launcher.exe";
                    clientProcess.StartInfo.WorkingDirectory = path_16;
                    clientProcess.Start();
                }
                else if (path_113 != "not installed")
                {
                    richTextBox_log.Text += "[Play SoDOff] Launching version: 1.13..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_113 + @"\sodoff-launcher.exe";
                    clientProcess.StartInfo.WorkingDirectory = path_113;
                    clientProcess.Start();
                }
                else if (path_29 != "not installed")
                {
                    richTextBox_log.Text += "[Play SoDOff] Launching version: 2.9..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_29 + @"\DOMain.exe";
                    clientProcess.Start();
                }
                else if (path_312 != "not installed")
                {
                    richTextBox_log.Text += "[Play SoDOff] Launching version: 3.12..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_312 + @"\sodoff-launcher.exe";
                    clientProcess.StartInfo.WorkingDirectory = path_312;
                    clientProcess.Start();
                }
                else if (path_331 != "not installed")
                {
                    richTextBox_log.Text += "[Play SoDOff] Launching version: 3.31..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_331 + @"\DOMain.exe";
                    clientProcess.Start();
                }
            }
            else if (versions_installed == 0)
            {
                MessageBox.Show(locale.main_play_error_client_not_found, "Play SoDOff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_install_riders_guild_online_Click(object sender, EventArgs e)
        {
            RidersGuild_client_installer install_dialog = new RidersGuild_client_installer();
            install_dialog.Show();
        }

        private void btn_play_riders_guild_online_Click(object sender, EventArgs e)
        {
            string path_319 = "";
            string path_321 = "";
            string path_326 = "";
            string path_331 = "";
            int versions_installed = 0;

            richTextBox_log.Text += "[Play Riders Guild] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_online_319");
                if (o != null)
                {
                    path_319 = o.ToString();
                }
                o = key.GetValue("RidersGuild_online_321");
                if (o != null)
                {
                    path_321 = o.ToString();
                }
                o = key.GetValue("RidersGuild_online_326");
                if (o != null)
                {
                    path_326 = o.ToString();
                }
                o = key.GetValue("RidersGuild_online");
                if (o != null)
                {
                    path_331 = o.ToString();
                }
            }
            key.Close();

            if (path_319 != "not installed")
            {
                versions_installed++;
            }
            if (path_321 != "not installed")
            {
                versions_installed++;
            }
            if (path_326 != "not installed")
            {
                versions_installed++;
            }
            if (path_331 != "not installed")
            {
                versions_installed++;
            }

            if (versions_installed > 1)
            {
                richTextBox_log.Text += "[Play Riders Guild] Multiple versions detected!" + "\n";

                RidersGuild_version_selector select_dialog = new RidersGuild_version_selector();
                select_dialog.Show();
            }
            else if (versions_installed == 1)
            {
                if (path_319 != "not installed")
                {
                    richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.19 (online)..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_319 + @"\DOMain.exe";
                    clientProcess.Start();
                }
                else if (path_321 != "not installed")
                {
                    richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.21 (online)..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_321 + @"\DOMain.exe";
                    clientProcess.Start();
                }
                else if (path_326 != "not installed")
                {
                    richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.26 (online)..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_326 + @"\DOMain.exe";
                    clientProcess.Start();
                }
                else if (path_331 != "not installed")
                {
                    richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.31 (online)..." + "\n";
                    Process clientProcess = new Process();
                    clientProcess.StartInfo.FileName = path_331 + @"\DOMain.exe";
                    clientProcess.Start();
                }
            }
            else if (versions_installed == 0)
            {
                MessageBox.Show(locale.main_play_error_client_not_found, "Play Riders Guild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_install_riders_guild_server_Click(object sender, EventArgs e)
        {
            RidersGuild_server_installer install_dialog = new RidersGuild_server_installer();
            install_dialog.Show();
        }

        private void btn_start_server_riders_guild_Click(object sender, EventArgs e)
        {
            string path = "";

            richTextBox_log.Text += "[Play Riders Guild] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_offline");
                if (o != null)
                {
                    path = o.ToString();
                }
            }
            key.Close();

            if (path != "not installed")
            {
                richTextBox_log.Text += "[Play Riders Guild] Launching server (offline)..." + "\n";
                Process clientProcess = new Process();
                if (File.Exists(path + @"\SoDServer.exe") == true)
                {
                    clientProcess.StartInfo.FileName = path + @"\SoDServer.exe";
                }
                else if (File.Exists(path + @"\SoDServer") == true)
                {
                    clientProcess.StartInfo.FileName = path + @"\SoDServer";
                }
                clientProcess.StartInfo.WorkingDirectory = path;
                clientProcess.Start();
            }
            else if (path == "not installed")
            {
                MessageBox.Show(locale.main_play_error_server_not_found, "Start Server (Riders Guild)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_play_riders_guild_offline_Click(object sender, EventArgs e)
        {
            string path = "";

            richTextBox_log.Text += "[Play Riders Guild] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_offline");
                if (o != null)
                {
                    path = o.ToString();
                }
            }
            key.Close();

            if (path != "not installed")
            {
                richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.31 (offline)..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (path == "not installed")
            {
                MessageBox.Show(locale.main_play_error_client_not_found, "Play Riders Guild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_discord_sodoff_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.com/invite/6FK3rJcyKC");
        }

        private void btn_discord_riders_guild_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/qVZBYghHxB");
        }

        private void label_about_Click(object sender, EventArgs e)
        {
            About about_dialog = new About();
            about_dialog.Show();
        }

        private void btn_mod_manager_Click(object sender, EventArgs e)
        {
            Mod_Manager mods_dialog = new Mod_Manager();
            mods_dialog.Show();
        }

        private void btn_install_riders_guild_assets_Click(object sender, EventArgs e)
        {
            string path = "";
            richTextBox_log.Text += "[Install assets Riders Guild] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_offline");
                if (o != null)
                {
                    path = o.ToString();
                }
            }
            key.Close();

            if (path != "not installed")
            {
                RidersGuild_assets_installer assets_dialog = new RidersGuild_assets_installer();
                assets_dialog.Show();
            }
            else if (path == "not installed")
            {
                MessageBox.Show(locale.main_play_error_server_not_found, "Install assets (Riders Guild)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_language.Text == "RU")
            {
                locale.updateLocale("russian");
                UpdateUI();
            }
            else if (comboBox_language.Text == "EN")
            {
                locale.updateLocale("english");
                UpdateUI();
            }
        }

        public Point CenterPositionX(Label label)
        {
            int x = (this.Width / 2) - (label.Width / 2) - 6;
            int y = label.Location.Y;
            return new Point(x, y);
        }
        public Point LanguagePositionX(Label label)
        {
            int x = comboBox_language.Location.X - label.Width - 6;
            int y = label.Location.Y;
            return new Point(x, y);
        }

        public void UpdateUI()
        {
            label_title.Text = locale.main_title;
            groupBox_play_online.Text = locale.main_play_online;
            groupBox_play_offline.Text = locale.main_play_offline;
            groupBox_social.Text = locale.main_social;
            btn_install_sodoff_online.Text = locale.main_install_sodoff;
            btn_install_riders_guild_online.Text = locale.main_install_rg_online;
            btn_play_sodoff_online.Text = locale.main_play_sodoff;
            btn_play_riders_guild_online.Text = locale.main_play_rg_online;
            btn_install_riders_guild_server.Text = locale.main_install_rg_server;
            btn_install_riders_guild_assets.Text = locale.main_install_rg_assets;
            btn_start_server_riders_guild.Text = locale.main_start_rg_server;
            btn_play_riders_guild_offline.Text = locale.main_play_rg_offline;
            btn_discord_sodoff.Text = locale.main_visit_sodoff_discord;
            btn_discord_riders_guild.Text = locale.main_visit_rg_discord;
            btn_mod_manager.Text = locale.main_mod_manager;
            label_about.Text = locale.main_about;
            label_language.Text = locale.main_language;

            label_title.Location = CenterPositionX(label_title);
            label_about.Location = CenterPositionX(label_about);
            label_language.Location = LanguagePositionX(label_language);
        }
    }
}
