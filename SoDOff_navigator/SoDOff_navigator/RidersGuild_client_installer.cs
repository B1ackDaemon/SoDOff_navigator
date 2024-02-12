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
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using Microsoft.Win32;
using System.Threading;

namespace SoDOff_navigator
{
    public partial class RidersGuild_client_installer : Form
    {
        Locale locale = Main.main.GetLocale();
        public RidersGuild_client_installer()
        {
            InitializeComponent();

            //textBox_path.Text = @"D:\RidersGuild";
            Main.main.WriteLog = "[Riders Guild installer] window opened." + "\n";

            UpdateUI();
        }

        private void btn_install_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                //MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(locale.error_install_path, "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                Main.main.WriteLog = "[Riders Guild installer] set install directory to: " + dialog.SelectedPath + "\n";
            }
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            //if (textBox_path.Text.Contains("Select...") == true)
            if (textBox_path.Text.Contains(locale.installer_path) == true)
            {
                //MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(locale.error_install_path, "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //else if (textBox_path.Text.Contains("Select...") == false)
            else if (textBox_path.Text.Contains(locale.installer_path) == false)
            {
                Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
                Thread install_thread;
                install_thread = new Thread(DownloadAndInstall);
                install_thread.Start();
                install_thread.IsBackground = true;
            }
        }

        private void btn_locate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                //MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(locale.error_install_path, "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                Main.main.WriteLog = "[Riders Guild installer] set locate directory to: " + dialog.SelectedPath + "\n";
                Main.main.WriteLog = "[Riders Guild installer] creating locate thread." + "\n";
                Thread locate_thread;
                locate_thread = new Thread(LocatePreinstalled);
                locate_thread.Start();
                locate_thread.IsBackground = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Main.main.WriteLog = "[Riders Guild installer] closed window." + "\n";
            this.Close();
        }

        public Point CenterPosition()
        {
            int x = (this.Width / 2) - (label_title.Width / 2) - 6;
            int y = (this.Height / 2) - (label_title.Height * 3);
            return new Point(x, y);
        }
        public Point CenterPositionX()
        {
            int x = (this.Width / 2) - (label_title.Width / 2) - 6;
            int y = label_title.Location.Y;
            return new Point(x, y);
        }

        public void UpdateUI()
        {
            label_title.Text = locale.rg_online_installer_title;
            groupBox_install_path.Text = locale.installer_install_path;
            textBox_path.Text = locale.installer_path;
            btn_install_path.Text = locale.installer_select_path;
            btn_install.Text = locale.installer_install;
            label_preinstalled.Text = locale.installer_preinstalled;
            btn_locate.Text = locale.installer_locate;
            btn_close.Text = locale.installer_close;
            label_title.Location = CenterPositionX();
        }

        public void DownloadAndInstall()
        {
            Main.main.WriteLog = "[Riders Guild installer] initializing install process." + "\n";
            string archive_name = "";
            string archive_md5 = "";
            string original_md5 = "";

            //label_title.Text = "Installing, please wait...";
            label_title.Text = locale.install_in_progress;
            label_title.Location = CenterPosition();
            groupBox_install_path.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            //btn_close.Text = "Cancel";
            btn_close.Text = locale.installer_cancel;
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(100, 233);

            if (Directory.Exists(textBox_path.Text) == false)
            {
                Directory.CreateDirectory(textBox_path.Text);
            }

            archive_name = @"\ridersguild_SoD_3.31.zip";
            original_md5 = "fa1628bdf364f8424e5d9fb331a62966";
            if (File.Exists(textBox_path.Text + archive_name) == true)
            {
                Main.main.WriteLog = "[Riders Guild installer] checking existing zip archive checksum..." + "\n";
                archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
            }
            if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
            {
                Main.main.WriteLog = "[Riders Guild installer] downloading zip archive from Riders Guild server..." + "\n";
                WebClient Client = new WebClient();
                Client.DownloadFile("https://ridersguild.org/ridersguild_SoD_3.31.zip", textBox_path.Text + archive_name);

                Main.main.WriteLog = "[Riders Guild installer] checking zip archive checksum..." + "\n";
                archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
            }

            if (archive_md5 != original_md5)
            {
                //label_title.Text = "Installation failed.";
                label_title.Text = locale.error_install_failed;
                label_title.Location = CenterPosition();
                //btn_close.Text = "Finish";
                btn_close.Text = locale.installer_finish;
                Main.main.WriteLog = "[Riders Guild installer] failed to verify archive integrity." + "\n";

                //MessageBox.Show("Failed to verify archive integrity!\nCheck your internet connection.", "Riders Guild Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(locale.error_archive_integrity, "Riders Guild Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (archive_md5 == original_md5)
            {
                //read zip contents
                Main.main.WriteLog = "[Riders Guild installer] reading zip archive..." + "\n";
                byte[] zip = ReadFile(textBox_path.Text + archive_name);
                MemoryStream memzip = new MemoryStream();
                memzip.Write(zip, 0, zip.Length);
                ZipArchive archive = new ZipArchive(memzip);

                //extract it in current directory
                Main.main.WriteLog = "[Riders Guild installer] extracting zip archive..." + "\n";
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string dir = "";
                    Stream unzippedEntryStream = entry.Open();
                    string path = textBox_path.Text + @"\" + entry.FullName.Replace(@"/", @"\");
                    if (entry.Name.Contains(".") == true || entry.Length > 0)
                    {
                        dir = path.Replace(entry.Name, "");
                    }
                    else if (entry.Name.Contains(".") == false)
                    {
                        dir = path;
                    }
                    if (Directory.Exists(dir) == false)
                    {
                        Directory.CreateDirectory(dir);
                    }

                    if (entry.Name.Contains(".") == true || entry.Length > 0)
                    {
                        using (Stream file = File.Create(path))
                        {
                            CopyStream(unzippedEntryStream, file);
                        }
                    }
                }
                Main.main.WriteLog = "[Riders Guild installer] opening registry key..." + "\n";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                {
                    if (key != null)  // Must check for null key
                    {
                        key.SetValue("RidersGuild_online", textBox_path.Text + @"\ridersguild_SoD_3.31");
                        Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.31 (online)" + "\n";
                    }
                }

                //label_title.Text = "Installation finished.";
                label_title.Text = locale.install_complete;
                label_title.Location = CenterPosition();
                //btn_close.Text = "Finish";
                btn_close.Text = locale.installer_finish;
                Main.main.WriteLog = "[Riders Guild installer] finished install process." + "\n";
            }
        }

        public void LocatePreinstalled()
        {
            Main.main.WriteLog = "[Riders Guild installer] initializing locate process." + "\n";
            //label_title.Text = "Scanning, please wait...";
            label_title.Text = locale.locate_in_progress;
            label_title.Location = CenterPosition();
            groupBox_install_path.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            //btn_close.Text = "Cancel";
            btn_close.Text = locale.installer_cancel;
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(100, 233);

            Main.main.WriteLog = "[Riders Guild installer] searching for installed SoD clients..." + "\n";
            string[] files = Directory.GetFiles(textBox_path.Text, "DOMain.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string md5 = HashingCompute.GetMD5HashFromFile(file);
                string path = file.Replace("DOMain.exe", "");
                if (md5 == "b12b8f61fbaa9fae76f22e63d81467db" && File.Exists(path + @"\SoDServer.exe") == false)
                {
                    string dll_path = file.Replace("DOMain.exe", "") + @"\DOMain_Data\Managed\Assembly-CSharp.dll";
                    string dll_md5 = HashingCompute.GetMD5HashFromFile(dll_path);
                    if (dll_md5 == "cc93086bb5490ee6a585394653f56b6d")
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                        {
                            if (key != null)  // Must check for null key
                            {
                                key.SetValue("RidersGuild_online", file.Replace("DOMain.exe", ""));
                                Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.31 (online)" + "\n";
                            }
                        }
                    }
                }
            }
            //label_title.Text = "Scanning finished.";
            label_title.Text = locale.locate_complete;
            label_title.Location = CenterPosition();
            //btn_close.Text = "Finish";
            btn_close.Text = locale.installer_finish;
            Main.main.WriteLog = "[Riders Guild installer] finished locate process." + "\n";
        }

        byte[] ReadFile(string path)
        {
            using (FileStream fsSource = new FileStream(path,
                    FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];

                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                    // Break when the end of the file is reached.
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = bytes.Length;
                return bytes;
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
