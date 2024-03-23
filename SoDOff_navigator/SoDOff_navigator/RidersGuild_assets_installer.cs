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
    public partial class RidersGuild_assets_installer : Form
    {
        Locale locale = Main.main.GetLocale();
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        bool DownloadCompleted = false;

        string assets_quality = "None";
        public RidersGuild_assets_installer()
        {
            InitializeComponent();

            Main.main.WriteLog = "[Riders Guild installer] window opened." + "\n";

            UpdateUI();
        }

        private void radioButton_online_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_online.Checked == true)
            {
                groupBox_edge.Visible = false;
            }
        }

        private void radioButton_edge_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_edge.Checked == true)
            {
                groupBox_edge.Visible = true;
            }
        }

        private void radioButton_low_CheckedChanged(object sender, EventArgs e)
        {
            assets_quality = "Low";
        }

        private void radioButton_mid_CheckedChanged(object sender, EventArgs e)
        {
            assets_quality = "Mid";
        }

        private void radioButton_high_CheckedChanged(object sender, EventArgs e)
        {
            assets_quality = "High";
        }

        private void btn_edge_path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                MessageBox.Show(locale.error_install_path, "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                Main.main.WriteLog = "[Riders Guild installer] set Edge directory to: " + dialog.SelectedPath + "\n";
            }
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            if (radioButton_online.Checked == true && assets_quality != "None")
            {
                Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
                Thread install_thread;
                install_thread = new Thread(DownloadAndInstall);
                install_thread.Start();
                install_thread.IsBackground = true;
            }
            else if (radioButton_online.Checked == false && assets_quality != "None")
            {
                if (textBox_path.Text.Contains(locale.installer_path) == true)
                {
                    MessageBox.Show(locale.error_pe_path, "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox_path.Text.Contains(locale.installer_path) == false)
                {
                    Main.main.WriteLog = "[Riders Guild installer] creating install thread." + "\n";
                    Thread install_thread;
                    install_thread = new Thread(DownloadAndInstall);
                    install_thread.Start();
                    install_thread.IsBackground = true;
                }
            }
            else if (radioButton_online.Checked == true && assets_quality == "None")
            {
                MessageBox.Show(locale.error_assets_quality, "Select assets quality", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (radioButton_online.Checked == false && assets_quality == "None")
            {
                MessageBox.Show(locale.error_assets_quality, "Select assets quality", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
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

        void UpdateUI()
        {
            label_title.Text = locale.rg_assets_installer_title;
            groupBox_download.Text = locale.rg_assets_dl_method;
            radioButton_online.Text = locale.rg_assets_dl_online;
            radioButton_edge.Text = locale.rg_assets_pe_import;
            groupBox_quality.Text = locale.rg_assets_quality;
            radioButton_low.Text = locale.rg_assets_quality_low;
            radioButton_mid.Text = locale.rg_assets_quality_mid;
            radioButton_high.Text = locale.rg_assets_quality_high;
            groupBox_edge.Text = locale.rg_assets_pe_path;
            textBox_path.Text = locale.installer_path;
            label_pe_desc.Text = locale.rg_assets_pe_description;
            btn_edge_path.Text = locale.installer_select_path;
            btn_install.Text = locale.installer_install;
            btn_close.Text = locale.installer_close;
            label_title.Location = CenterPositionX(label_title);
        }

        public void DownloadAndInstall()
        {
            Main.main.WriteLog = "[Riders Guild installer] initializing install process." + "\n";

            //label_title.Text = "Installing, please wait...";
            label_title.Text = locale.install_in_progress;
            label_title.Location = CenterPosition();
            groupBox_download.Visible = false;
            groupBox_quality.Visible = false;
            groupBox_edge.Visible = false;
            btn_install.Visible = false;

            //btn_close.Text = "Cancel";
            btn_close.Text = locale.installer_cancel;
            btn_close.Size = new Size(75, 33);
            btn_close.Location = new Point(140, 323);

            label_files.Text = "";
            label_files.Location = new Point(100, 190);

            string client_path = "";
            string[] sga_list = new string[1];
            string[] rg_list = new string[1];

            Main.main.WriteLog = "[Riders Guild installer] Reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_offline");
                if (o != null)
                {
                    client_path = o.ToString();
                }
            }
            key.Close();

            CreateDirs(client_path);
            if (assets_quality == "Low")
            {
                if (radioButton_edge.Checked == true)
                {
                    if (File.Exists("pe_to_rg_331_low.txt") == false)
                    {
                        WebClient Client = new WebClient();
                        Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/pe_to_rg_331_low.txt", "pe_to_rg_331_low.txt");
                    }
                    sga_list = System.IO.File.ReadAllLines("pe_to_rg_331_low.txt");
                }
                if (File.Exists("rg_331_low.txt") == false)
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/rg_331_low.txt", "rg_331_low.txt");
                }
                rg_list = System.IO.File.ReadAllLines("rg_331_low.txt");
            }
            else if (assets_quality == "Mid")
            {
                if (radioButton_edge.Checked == true)
                {
                    if (File.Exists("pe_to_rg_331_mid.txt") == false)
                    {
                        WebClient Client = new WebClient();
                        Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/pe_to_rg_331_mid.txt", "pe_to_rg_331_mid.txt");
                    }
                    sga_list = System.IO.File.ReadAllLines("pe_to_rg_331_mid.txt");
                }
                if (File.Exists("rg_331_mid.txt") == false)
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/rg_331_mid.txt", "rg_331_mid.txt");
                }
                rg_list = System.IO.File.ReadAllLines("rg_331_mid.txt");
            }
            else if (assets_quality == "High")
            {
                if (radioButton_edge.Checked == true)
                {
                    if (File.Exists("pe_to_rg_331_high.txt") == false)
                    {
                        WebClient Client = new WebClient();
                        Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/pe_to_rg_331_high.txt", "pe_to_rg_331_high.txt");
                    }
                    sga_list = System.IO.File.ReadAllLines("pe_to_rg_331_high.txt");
                }
                if (File.Exists("rg_331_high.txt") == false)
                {
                    WebClient Client = new WebClient();
                    Client.DownloadFile("https://github.com/B1ackDaemon/SoDOff_navigator_modslist/raw/main/rg_331_high.txt", "rg_331_high.txt");
                }
                rg_list = System.IO.File.ReadAllLines("rg_331_high.txt");
            }

            if (radioButton_edge.Checked == true)
            {
                if (File.Exists(textBox_path.Text + @"\3.31.0 archive.sga") == true)
                {
                    Main.main.WriteLog = "[Riders Guild installer] found sga archive." + "\n";

                    string sga_path = textBox_path.Text + @"\3.31.0 archive.sga";
                    System.IO.FileStream arc =
                   new System.IO.FileStream(sga_path, System.IO.FileMode.Open,
                                            System.IO.FileAccess.Read);
                    ZipArchive archive = new ZipArchive(arc);

                    for (int i = 0; i < sga_list.Length; i++)
                    {
                        string[] split = sga_list[i].Split(',');
                        string og_path = client_path + @"\assets-cache\" + split[0];
                        string sa_path = "assets/" + split[1].TrimStart();
                        string og_md5 = split[2].TrimStart();
                        string md5 = "";

                        label_files.Text = "Files: " + i + @" \ " + sga_list.Length;

                        var entry = archive.GetEntry(sa_path);
                        Stream unzippedEntryStream = entry.Open();

                        if (File.Exists(og_path) == true)
                        {
                            md5 = HashingCompute.GetMD5HashFromFile(og_path);
                            if (md5 != og_md5)
                            {
                                using (Stream file = File.Create(og_path))
                                {
                                    CopyStream(unzippedEntryStream, file);
                                }
                            }
                        }
                        else if (File.Exists(og_path) == false)
                        {
                            using (Stream file = File.Create(og_path))
                            {
                                CopyStream(unzippedEntryStream, file);
                            }
                        } 
                    }
                }
                else if (File.Exists(textBox_path.Text + @"\3.31.0 archive.sga") == false)
                {
                    string assets_path = "";
                    Main.main.WriteLog = "[Riders Guild installer] sga archive not found." + "\n";

                    string[] files = Directory.GetFiles(textBox_path.Text, "sentinel-launcher.jar", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        if (file.Contains("sentinel-launcher.jar") == true)
                        {
                            assets_path = file.Replace("sentinel-launcher.jar", "") + @"\assets\assetarchive\assets\";
                        }
                    }

                    for (int i = 0; i < sga_list.Length; i++)
                    {
                        string[] split = sga_list[i].Split(',');
                        string og_path = client_path + @"\assets-cache\" + split[0];
                        string sa_path = assets_path + split[1].TrimStart();
                        string og_md5 = split[2].TrimStart();
                        string md5 = "";

                        label_files.Text = "Files: " + i + @" / " + sga_list.Length;

                        if (File.Exists(sa_path) == true)
                        {
                            if (File.Exists(og_path) == true)
                            {
                                md5 = HashingCompute.GetMD5HashFromFile(og_path);
                                if (md5 != og_md5)
                                {
                                    File.Copy(sa_path, og_path, true);
                                }
                            }
                            else if (File.Exists(og_path) == false)
                            {
                                File.Copy(sa_path, og_path);
                            }
                        }
                    }
                }
            }

            int index = 0;
            string server_url = "https://ridersguild.org/";
            while (index < rg_list.Length)
            {
                DownloadCompleted = false;
                string[] split = rg_list[index].Split(',');
                string og_path = client_path + @"\assets-cache\" + split[0];
                string og_md5 = split[1].TrimStart();
                string md5 = "";

                label_files.Text = "Files: " + index + @" / " + rg_list.Length;

                if (File.Exists(og_path) == true)
                {
                    md5 = HashingCompute.GetMD5HashFromFile(og_path);
                    if (md5 != og_md5)
                    {
                        DownloadFile(server_url + split[0], og_path);

                        while (DownloadCompleted == false)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    else if (md5 == og_md5)
                    {
                        index++;
                    }
                }
                else if (File.Exists(og_path) == false)
                {
                    DownloadFile(server_url + split[0], og_path);

                    while (DownloadCompleted == false)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            label_files.Visible = false;
            //label_title.Text = "Installation finished.";
            label_title.Text = locale.install_complete;
            label_title.Location = CenterPosition();
            //btn_close.Text = "Finish";
            btn_close.Text = locale.installer_finish;
            Main.main.WriteLog = "[Riders Guild installer] finished install process." + "\n";
        }

        public void CreateDirs(string path)
        {
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DOJILZ\Dragons\SoD\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DOJILZ\Dragons\SoD\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DOJILZ\LoadScreens\en-US\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DOJILZ\LoadScreens\en-US\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DWAPromos\en-US\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\DWAPromos\en-US\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\CountryFlags\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\CountryFlags\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Favs\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Favs\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Gender\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Gender\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Mood\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\data\Content\PlayerData\Mood\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\movies\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\movies\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\scene\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\scene\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\shareddata\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\shareddata\");
            }
            if (Directory.Exists(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\sound\") == false)
            {
                Directory.CreateDirectory(path + @"\assets-cache\DWADragonsUnity\WIN\3.31.0\" + assets_quality + @"\sound\");
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
                    progressBar.Visible = true;
                    labelDownloaded.Visible = true;
                    labelSpeed.Visible = true;

                    labelDownloaded.Text = "";
                    labelSpeed.Text = "";
                    progressBar.Location = new Point(61, 210);
                    labelDownloaded.Location = new Point(58, 236);
                    labelSpeed.Location = new Point(231, 236);
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
    }
}
