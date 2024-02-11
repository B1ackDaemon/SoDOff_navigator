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
using System.Security.Cryptography;

namespace SoDOff_navigator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            main = this;

            richTextBox_log.Text += "[Main] Program started." + "\n";

            checkEnvironment();
            checkRegistry();
        }

        internal static Main main;
        internal string WriteLog
        {
            set { richTextBox_log.Text += value; }
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
                MessageBox.Show("No installed game client found.\nInstall or locate preinstalled copy.", "Play SoDOff", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_install_riders_guild_online_Click(object sender, EventArgs e)
        {
            RidersGuild_client_installer install_dialog = new RidersGuild_client_installer();
            install_dialog.Show();
        }

        private void btn_play_riders_guild_online_Click(object sender, EventArgs e)
        {
            string path = "";

            richTextBox_log.Text += "[Play Riders Guild] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_online");
                if (o != null)
                {
                    path = o.ToString();
                }
            }
            key.Close();

            if (path != "not installed")
            {
                richTextBox_log.Text += "[Play Riders Guild] Launching version: 3.31 (online)..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (path == "not installed")
            {
                MessageBox.Show("No installed game client found.\nInstall or locate preinstalled copy.", "Play Riders Guild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                clientProcess.StartInfo.FileName = path + @"\SoDServer.exe";
                clientProcess.StartInfo.WorkingDirectory = path;
                clientProcess.Start();
            }
            else if (path == "not installed")
            {
                MessageBox.Show("No installed game server found.\nInstall or locate preinstalled copy.", "Start Server (Riders Guild)", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("No installed game client found.\nInstall or locate preinstalled copy.", "Play Riders Guild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

    class HashingCompute
    {
        public static String GetMD5HashFromFile(String fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetMD5HashFromStream(MemoryStream mem)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(mem);


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetMD5HashFromBinary(BinaryReader buf)
        {
            byte[] tmp = buf.ReadBytes((int)buf.BaseStream.Length);
            MemoryStream mem = new MemoryStream();
            mem.Write(tmp, 0, tmp.Length);
            mem.Position = 0;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(mem);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static String GetSHA1HashFromFile(String fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] retVal = sha1.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
