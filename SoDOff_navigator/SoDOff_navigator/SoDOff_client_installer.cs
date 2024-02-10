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
using System.Security.Cryptography;

namespace SoDOff_navigator
{
    
    public partial class SoDOff_client_installer : Form
    {
        public SoDOff_client_installer()
        {
            InitializeComponent();

            //textBox_path.Text = @"D:\SoDOff";
            Main.main.WriteLog = "[SoDOff installer] window opened." + "\n";
        }

        private void btn_install_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                Main.main.WriteLog = "[SoDOff installer] set install directory to: " + dialog.SelectedPath + "\n";
            }
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text.Contains("Select...") == true)
            {
                MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_path.Text.Contains("Select...") == false)
            {
                if (radioButton_version_default.Checked == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] creating install thread." + "\n";
                    Thread install_thread;
                    install_thread = new Thread(DownloadAndInstall);
                    install_thread.Start();
                    install_thread.IsBackground = true;
                }
                else if (radioButton_version_select.Checked == true && comboBox_version.Text == "")
                {
                    MessageBox.Show("No client version selected!", "Select game version", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (radioButton_version_select.Checked == true && comboBox_version.Text != "")
                {
                    Main.main.WriteLog = "[SoDOff installer] creating install thread." + "\n";
                    Thread install_thread;
                    install_thread = new Thread(DownloadAndInstall);
                    install_thread.Start();
                    install_thread.IsBackground = true;
                }
            }
        }

        private void btn_locate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                Main.main.WriteLog = "[SoDOff installer] set locate directory to: " + dialog.SelectedPath + "\n";
                Main.main.WriteLog = "[SoDOff installer] creating locate thread." + "\n";
                Thread locate_thread;
                locate_thread = new Thread(LocatePreinstalled);
                locate_thread.Start();
                locate_thread.IsBackground = true;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Main.main.WriteLog = "[SoDOff installer] closed window." + "\n";
            this.Close();
        }

        private void radioButton_version_select_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_version.Visible = true;
            comboBox_version.Items.Clear();
            comboBox_version.Items.Add("1.6");
            comboBox_version.Items.Add("1.13");
            comboBox_version.Items.Add("2.9");
            comboBox_version.Items.Add("3.12");
        }

        private void radioButton_version_default_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_version.Visible = false;
        }

        public void DownloadAndInstall()
        {
            Main.main.WriteLog = "[SoDOff installer] initializing install process." + "\n";
            string version = "";
            string archive_name = "";
            string archive_md5 = "";
            string original_md5 = "";

            label_title.Text = "Installing, please wait...";
            label_title.Location = new Point(56, 130);
            groupBox_install_path.Visible = false;
            groupBox_client_ver.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            btn_close.Text = "Cancel";
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(100, 273);

            if (Directory.Exists(textBox_path.Text) == false)
            {
                Directory.CreateDirectory(textBox_path.Text);
            }

            if (radioButton_version_default.Checked == true)
            {
                version = "3.31";
                Main.main.WriteLog = "[SoDOff installer] setting client version to: " + version + "\n";
            }
            else if (radioButton_version_select.Checked == true)
            {
                version = comboBox_version.Text;
                Main.main.WriteLog = "[SoDOff installer] setting client version to: " + version + "\n";
            }

            if (version == "1.6")
            {
                archive_name = @"\SoD_1.6.zip";
                original_md5 = "4de76f805a74a93e97851c41c5d118fc";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[SoDOff installer] downloading zip archive from SoDOff server..." + "\n";
                    WebClient Client = new WebClient();
                    Client.Headers.Add("Referer", "https://sodoff.spirtix.com/SoD_1.6");
                    Client.DownloadFile("https://media.sodoff.spirtix.com/clients/SoD_1.6.zip", textBox_path.Text + archive_name);

                    Main.main.WriteLog = "[SoDOff installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "1.13")
            {
                archive_name = @"\SoD_1.13.zip";
                original_md5 = "7de1f0c5045c80e08229646d052b653f";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[SoDOff installer] downloading zip archive from SoDOff server..." + "\n";
                    WebClient Client = new WebClient();
                    Client.Headers.Add("Referer", "https://sodoff.spirtix.com/SoD_1.13");
                    Client.DownloadFile("https://media.sodoff.spirtix.com/clients/SoD_1.13.zip", textBox_path.Text + archive_name);

                    Main.main.WriteLog = "[SoDOff installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "2.9")
            {
                archive_name = @"\SoD_2.9.zip";
                original_md5 = "c805138dd5b5bb09b129ae291f581898";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[SoDOff installer] downloading zip archive from SoDOff server..." + "\n";
                    WebClient Client = new WebClient();
                    Client.Headers.Add("Referer", "https://sodoff.spirtix.com/SoD_2.9");
                    Client.DownloadFile("https://media.sodoff.spirtix.com/clients/SoD_2.9.zip", textBox_path.Text + archive_name);

                    Main.main.WriteLog = "[SoDOff installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "3.12")
            {
                archive_name = @"\SoD_3.12.zip";
                original_md5 = "3d5075de593f49a78ed397bca47dbb0f";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[SoDOff installer] downloading zip archive from SoDOff server..." + "\n";
                    WebClient Client = new WebClient();
                    Client.Headers.Add("Referer", "https://sodoff.spirtix.com/SoD_3.12");
                    Client.DownloadFile("https://media.sodoff.spirtix.com/clients/SoD_3.12.zip", textBox_path.Text + archive_name);

                    Main.main.WriteLog = "[SoDOff installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "3.31")
            {
                archive_name = @"\sod_windows.zip";
                original_md5 = "74d2ac0a3345c5b069064065de5963d5";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[SoDOff installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);  
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[SoDOff installer] downloading zip archive from SoDOff server..." + "\n";
                    WebClient Client = new WebClient();
                    Client.Headers.Add("Referer", "https://sodoff.spirtix.com/windows");
                    Client.DownloadFile("https://media.sodoff.spirtix.com/clients/sod_windows.zip", textBox_path.Text + archive_name);

                    Main.main.WriteLog = "[SoDOff installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }

            if (archive_md5 != original_md5)
            {
                label_title.Text = "Installation failed.";
                label_title.Location = new Point(64, 130);
                btn_close.Text = "Finish";
                Main.main.WriteLog = "[SoDOff installer] failed to verify archive integrity." + "\n";

                MessageBox.Show("Failed to verify archive integrity!\nCheck your internet connection.", "SoDOff Installer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (archive_md5 == original_md5)
            {
                //read zip contents
                Main.main.WriteLog = "[SoDOff installer] reading zip archive..." + "\n";
                byte[] zip = ReadFile(textBox_path.Text + archive_name);
                MemoryStream memzip = new MemoryStream();
                memzip.Write(zip, 0, zip.Length);
                ZipArchive archive = new ZipArchive(memzip);

                //extract it in current directory
                Main.main.WriteLog = "[SoDOff installer] extracting zip archive..." + "\n";
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
                Main.main.WriteLog = "[SoDOff installer] opening registry key..." + "\n";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                {
                    if (key != null)  // Must check for null key
                    {
                        if (version == "1.6")
                        {
                            key.SetValue("SoDOff_16", textBox_path.Text + @"\SoD_1.6");
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: " + version + "\n";
                        }
                        else if (version == "1.13")
                        {
                            key.SetValue("SoDOff_113", textBox_path.Text + @"\SoD_1.13");
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: " + version + "\n";
                        }
                        else if (version == "2.9")
                        {
                            key.SetValue("SoDOff_29", textBox_path.Text + @"\SoD_2.9");
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: " + version + "\n";
                        }
                        else if (version == "3.31")
                        {
                            key.SetValue("SoDOff_331", textBox_path.Text + @"\School of Dragons");
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: " + version + "\n";
                        }
                        else if (version == "3.12")
                        {
                            key.SetValue("SoDOff_312", textBox_path.Text + @"\SoD_3.12");
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: " + version + "\n";
                        }
                    }
                }

                label_title.Text = "Installation finished.";
                label_title.Location = new Point(64, 130);
                btn_close.Text = "Finish";
                Main.main.WriteLog = "[SoDOff installer] finished install process." + "\n";
            }
        }

        public void LocatePreinstalled()
        {
            Main.main.WriteLog = "[SoDOff installer] initializing locate process." + "\n";
            label_title.Text = "Scanning, please wait...";
            label_title.Location = new Point(56, 130);
            groupBox_install_path.Visible = false;
            groupBox_client_ver.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            btn_close.Text = "Cancel";
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(100, 273);

            Main.main.WriteLog = "[SoDOff installer] searching for installed SoD clients..." + "\n";
            string[] files = Directory.GetFiles(textBox_path.Text, "DOMain.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string md5 = HashingCompute.GetMD5HashFromFile(file);
                if (md5 == "4666f18e2319f5aa373bee22ffa43025")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("SoDOff_16", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: 1.6" + "\n";
                        }
                    }
                }
                else if (md5 == "a7648e3bdff49bc6428488a0235487d2")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("SoDOff_113", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: 1.13" + "\n";
                        }
                    }
                }
                else if (md5 == "2c2896bef2370463e14b384b22149ab7")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("SoDOff_29", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: 2.9" + "\n";
                        }
                    }
                }
                else if (md5 == "1616ccdbd5cdd3aba871edb572fbc1df")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("SoDOff_312", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: 3.12" + "\n";
                        }
                    }
                }
                else if (md5 == "b12b8f61fbaa9fae76f22e63d81467db")
                {
                    string dll_path = file.Replace("DOMain.exe", "") + @"\DOMain_Data\Managed\Assembly-CSharp.dll";
                    string dll_md5 = HashingCompute.GetMD5HashFromFile(dll_path);
                    if (dll_md5 == "38f1f37456c67bd658ab4faab871191d")
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                        {
                            if (key != null)  // Must check for null key
                            {
                                key.SetValue("SoDOff_331", file.Replace("DOMain.exe", ""));
                                Main.main.WriteLog = "[SoDOff installer] writing installed client path to registry for version: 3.31" + "\n";
                            }
                        }
                    }
                }
            }
            label_title.Text = "Scanning finished.";
            label_title.Location = new Point(68, 130);
            btn_close.Text = "Finish";
            Main.main.WriteLog = "[SoDOff installer] finished locate process." + "\n";
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
