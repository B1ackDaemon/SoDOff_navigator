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
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        bool DownloadCompleted = false;
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
                /*Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
                Thread install_thread;
                install_thread = new Thread(DownloadAndInstall);
                install_thread.Start();
                install_thread.IsBackground = true;*/
                if (radioButton_version_default.Checked == true)
                {
                    Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
                    Thread install_thread;
                    install_thread = new Thread(DownloadAndInstall);
                    install_thread.Start();
                    install_thread.IsBackground = true;
                }
                else if (radioButton_version_select.Checked == true && comboBox_version.Text == "")
                {
                    //MessageBox.Show("No client version selected!", "Select game version", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(locale.error_client_version, "Select game version", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (radioButton_version_select.Checked == true && comboBox_version.Text != "")
                {
                    Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
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
        public Point CenterPositionX(Label label)
        {
            int x = (this.Width / 2) - (label.Width / 2) - 6;
            int y = label.Location.Y;
            return new Point(x, y);
        }

        public void UpdateUI()
        {
            label_title.Text = locale.rg_online_installer_title;
            groupBox_install_path.Text = locale.installer_install_path;
            textBox_path.Text = locale.installer_path;
            btn_install_path.Text = locale.installer_select_path;
            groupBox_client_ver.Text = locale.sodoff_installer_client_ver;
            radioButton_version_default.Text = locale.sodoff_installer_version_default;
            radioButton_version_select.Text = locale.sodoff_installer_version_select;
            btn_install.Text = locale.installer_install;
            label_preinstalled.Text = locale.installer_preinstalled;
            btn_locate.Text = locale.installer_locate;
            btn_close.Text = locale.installer_close;
            label_title.Location = CenterPositionX(label_title);
        }

        public void DownloadAndInstall()
        {
            Main.main.WriteLog = "[Riders Guild installer] initializing install process." + "\n";
            string version = "";
            string archive_name = "";
            string archive_md5 = "";
            string original_md5 = "";

            //label_title.Text = "Installing, please wait...";
            label_title.Text = locale.install_in_progress;
            label_title.Location = CenterPosition();
            groupBox_install_path.Visible = false;
            groupBox_client_ver.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            //btn_close.Text = "Cancel";
            btn_close.Text = locale.installer_cancel;
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(140, 273);

            if (Directory.Exists(textBox_path.Text) == false)
            {
                Directory.CreateDirectory(textBox_path.Text);
            }

            if (radioButton_version_default.Checked == true)
            {
                version = "3.31";
                Main.main.WriteLog = "[Riders Guild installer] setting client version to: " + version + "\n";
            }
            else if (radioButton_version_select.Checked == true)
            {
                version = comboBox_version.Text;
                Main.main.WriteLog = "[Riders Guild installer] setting client version to: " + version + "\n";
            }

            if (version == "3.19")
            {
                archive_name = @"\ridersguild_SoD_3.19.zip";
                original_md5 = "7a0d57a38dfc04c752d404234af6473c";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[Riders Guild installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[Riders Guild installer] downloading zip archive from Riders Guild server..." + "\n";
                    DownloadFile("https://ridersguild.org/ridersguild_SoD_3.19.zip", textBox_path.Text + archive_name);

                    while (DownloadCompleted == false)
                    {
                        Thread.Sleep(1000);
                    }

                    Main.main.WriteLog = "[Riders Guild installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "3.21")
            {
                archive_name = @"\ridersguild_SoD_3.21.zip";
                original_md5 = "b6559383dc42a80550fbdd68744c33b6";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[Riders Guild installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[Riders Guild installer] downloading zip archive from Riders Guild server..." + "\n";
                    DownloadFile("https://ridersguild.org/ridersguild_SoD_3.21.zip", textBox_path.Text + archive_name);

                    while (DownloadCompleted == false)
                    {
                        Thread.Sleep(1000);
                    }

                    Main.main.WriteLog = "[Riders Guild installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "3.26")
            {
                archive_name = @"\ridersguild_SoD_3.26.zip";
                original_md5 = "d44313a38efce4448500dfaa5a6b1727";
                if (File.Exists(textBox_path.Text + archive_name) == true)
                {
                    Main.main.WriteLog = "[Riders Guild installer] checking existing zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
                if (File.Exists(textBox_path.Text + archive_name) == false || archive_md5 != original_md5)
                {
                    Main.main.WriteLog = "[Riders Guild installer] downloading zip archive from Riders Guild server..." + "\n";
                    DownloadFile("https://ridersguild.org/ridersguild_SoD_3.26.zip", textBox_path.Text + archive_name);

                    while (DownloadCompleted == false)
                    {
                        Thread.Sleep(1000);
                    }

                    Main.main.WriteLog = "[Riders Guild installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
            }
            else if (version == "3.31")
            {
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
                    DownloadFile("https://ridersguild.org/ridersguild_SoD_3.31.zip", textBox_path.Text + archive_name);

                    while (DownloadCompleted == false)
                    {
                        Thread.Sleep(1000);
                    }

                    Main.main.WriteLog = "[Riders Guild installer] checking zip archive checksum..." + "\n";
                    archive_md5 = HashingCompute.GetMD5HashFromFile(textBox_path.Text + archive_name);
                }
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
                        if (version == "3.19")
                        {
                            key.SetValue("RidersGuild_online_319", textBox_path.Text + @"\ridersguild_SoD_3.19");
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.19 (online)" + "\n";
                        }
                        else if (version == "3.21")
                        {
                            key.SetValue("RidersGuild_online_321", textBox_path.Text + @"\ridersguild_SoD_3.21");
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.21 (online)" + "\n";
                        }
                        else if (version == "3.26")
                        {
                            key.SetValue("RidersGuild_online_326", textBox_path.Text + @"\ridersguild_SoD_3.26");
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.26 (online)" + "\n";
                        }
                        else if (version == "3.31")
                        {
                            key.SetValue("RidersGuild_online", textBox_path.Text + @"\ridersguild_SoD_3.31");
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.31 (online)" + "\n";
                        }
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
            groupBox_client_ver.Visible = false;
            btn_install.Visible = false;
            btn_locate.Visible = false;
            label_preinstalled.Visible = false;
            //btn_close.Text = "Cancel";
            btn_close.Text = locale.installer_cancel;
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(140, 273);

            int clients_found = 0;

            Main.main.WriteLog = "[Riders Guild installer] searching for installed SoD clients..." + "\n";
            string[] files = Directory.GetFiles(textBox_path.Text, "DOMain.exe", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string md5 = HashingCompute.GetMD5HashFromFile(file);
                string path = file.Replace("DOMain.exe", "");
                if (md5 == "3b6594a5c5aa8e5a7e8d7de9ff286b18")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("RidersGuild_online_319", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.19" + "\n";
                        }
                    }
                    clients_found++;
                }
                else if (md5 == "e03ed19a1d1fb4a12054a1774edb50a6")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("RidersGuild_online_321", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.21" + "\n";
                        }
                    }
                    clients_found++;
                }
                else if (md5 == "98b2bbb5261fb4dab1d8609efde879e3")
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator", true)) // Must dispose key or use "using" keyword
                    {
                        if (key != null)  // Must check for null key
                        {
                            key.SetValue("RidersGuild_online_326", file.Replace("DOMain.exe", ""));
                            Main.main.WriteLog = "[Riders Guild installer] writing installed client path to registry for version: 3.26" + "\n";
                        }
                    }
                    clients_found++;
                }
                else if (md5 == "b12b8f61fbaa9fae76f22e63d81467db" && File.Exists(path + @"\SoDServer.exe") == false)
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
                        clients_found++;
                    }
                }
            }
            //label_title.Text = "Scanning finished.";
            label_title.Text = locale.locate_complete;
            label_title.Location = CenterPosition();
            label_clients.Text = locale.locate_clients_found + files.Length + "\n" + locale.locate_clients_added + clients_found;
            label_clients.Location = CenterPositionX(label_clients);
            label_clients.Location = new Point(label_clients.Location.X, (label_title.Location.Y + 60));
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

        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    labelDownloaded.Text = "";
                    labelSpeed.Text = "";
                    progressBar.Location = new Point(61, 160);
                    labelDownloaded.Location = new Point(58, 186);
                    labelSpeed.Location = new Point(231, 186);
                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            //labelPerc.Text = e.ProgressPercentage.ToString() + "%";
            progressBar.Refresh();
            progressBar.CreateGraphics().DrawString(e.ProgressPercentage.ToString() + "%",
                new Font("Arial", (float)8.25, FontStyle.Regular),
                Brushes.Black,
                new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                //MessageBox.Show("Download has been canceled.");
                Main.main.WriteLog = "[Riders Guild installer] download has been cancelled." + "\n";
            }
            else
            {
                progressBar.Visible = false;
                labelDownloaded.Visible = false;
                labelSpeed.Visible = false;
                //MessageBox.Show("Download completed!");
                DownloadCompleted = true;
            }
        }

        private void radioButton_version_default_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_version.Visible = false;
        }

        private void radioButton_version_select_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_version.Visible = true;
            comboBox_version.Items.Clear();
            comboBox_version.Items.Add("3.19");
            comboBox_version.Items.Add("3.21");
            comboBox_version.Items.Add("3.26");
        }
    }
}
