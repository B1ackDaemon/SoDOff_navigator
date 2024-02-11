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
using System.IO;
using System.IO.Compression;
using System.Net;

namespace SoDOff_navigator
{
    public partial class Mod_Manager : Form
    {
        Mods[] mod;
        int[] mod_index;
        public Mod_Manager()
        {
            InitializeComponent();

            Main.main.WriteLog = "[Mod Manager] window opened." + "\n";

            if (File.Exists("modslist.txt") == false)
            {
                Main.main.WriteLog = "[Mod Manager] downloading mods list from remote server..." + "\n";

                WebClient Client = new WebClient();
                Client.DownloadFile("https://raw.githubusercontent.com/B1ackDaemon/SoDOff_navigator_modslist/main/modslist.txt", "modslist.txt");
            }

            Main.main.WriteLog = "[Mod Manager] reading mods list..." + "\n";
            mod = new Mods().createModsList(System.IO.File.ReadAllLines("modslist.txt"));

            comboBox_category.Items.Add("Any");
            comboBox_category.Items.Add("Cosmetic");
            comboBox_category.Items.Add("Utility");
            comboBox_author.Items.Add("Any");

            Main.main.WriteLog = "[Mod Manager] parsing installed clients from registry..." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("SoDOff_331");
                if (o != null)
                {
                    string path_331 = o.ToString();
                    if (path_331 != "not installed")
                    {
                        comboBox_client.Items.Add("SoDOff 3.31");
                    }
                }
                o = key.GetValue("RidersGuild_online");
                if (o != null)
                {
                    string ridersguild_online = o.ToString();
                    if (ridersguild_online != "not installed")
                    {
                        comboBox_client.Items.Add("Riders Guild 3.31 (online)");
                    }
                }
                o = key.GetValue("RidersGuild_offline");
                if (o != null)
                {
                    string ridersguild_offline = o.ToString();
                    if (ridersguild_offline != "not installed")
                    {
                        comboBox_client.Items.Add("Riders Guild 3.31 (offline)");
                    }
                }
            }
            key.Close();

            comboBox_author.SelectedIndex = 0;
            comboBox_category.SelectedIndex = 0;

            ParseModAuthors();
            UpdateModsList();
        }

        public void ParseModAuthors()
        {
            bool author_found = false;

            for (int i = 0; i < mod.Length; i++)
            {
                for (int j = 0; j < comboBox_author.Items.Count; j++)
                {
                    if (mod[i].author == comboBox_author.Items[j].ToString())
                    {
                        author_found = true;
                    }
                }
                if (author_found == false)
                {
                    comboBox_author.Items.Add(mod[i].author);
                }
                author_found = false;
            }
        }

        public void UpdateModsList()
        {
            int items_added = 0;
            listBox_mods.Items.Clear();
            mod_index = new int[mod.Length];
            for (int i = 0; i < mod.Length; i++)
            {
                if (comboBox_author.Text == "Any" && comboBox_category.Text == "Any")
                {
                    listBox_mods.Items.Add(mod[i].name);
                    mod_index[i] = i;
                }
                else if (comboBox_author.Text != "Any" && comboBox_category.Text == "Any")
                {
                    if (mod[i].author == comboBox_author.Text)
                    {
                        listBox_mods.Items.Add(mod[i].name);
                        mod_index[items_added] = i;
                        items_added++;
                    }
                }
                else if (comboBox_author.Text == "Any" && comboBox_category.Text != "Any")
                {
                    if (mod[i].category == comboBox_category.Text)
                    {
                        listBox_mods.Items.Add(mod[i].name);
                        mod_index[items_added] = i;
                        items_added++;
                    }
                }
                else if (comboBox_author.Text != "Any" && comboBox_category.Text != "Any")
                {
                    if (mod[i].author == comboBox_author.Text && mod[i].category == comboBox_category.Text)
                    {
                        listBox_mods.Items.Add(mod[i].name);
                        mod_index[items_added] = i;
                        items_added++;
                    }
                }
            }
        }

        private void comboBox_author_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModsList();
        }

        private void comboBox_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateModsList();
        }

        private void listBox_mods_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_mod_name.Text = "Mod name: " + mod[mod_index[listBox_mods.SelectedIndex]].name;
            label_mod_author.Text = "Author: " + mod[mod_index[listBox_mods.SelectedIndex]].author;
            label_direct_dl.Text = "Direct download: " + mod[mod_index[listBox_mods.SelectedIndex]].direct_download;
            label_description.Text = "Description: " + mod[mod_index[listBox_mods.SelectedIndex]].description;
            label_dependency.Text = "Dependency: " + mod[mod_index[listBox_mods.SelectedIndex]].dependency;
            label_direct_dl.Text = "Direct download: " + mod[mod_index[listBox_mods.SelectedIndex]].direct_download;
            if (mod[mod_index[listBox_mods.SelectedIndex]].direct_download == "no")
            {
                btn_download.Text = "Download (manual)";
            }
            else if (mod[mod_index[listBox_mods.SelectedIndex]].direct_download == "yes")
            {
                btn_download.Text = "Download (automatic)";
            }

            Main.main.WriteLog = "[Mod Manager] selected mod: " + mod[mod_index[listBox_mods.SelectedIndex]].name + "\n";
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            if (listBox_mods.SelectedIndex < 0)
            {
                MessageBox.Show("You must select mod from list before installing.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listBox_mods.SelectedIndex >= 0)
            {
                if (comboBox_client.Text == "")
                {
                    MessageBox.Show("You must choose client before installing.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBox_client.Text != "")
                {
                    int index = mod_index[listBox_mods.SelectedIndex];
                    string file_md5 = "";
                    string game_path = "";

                    Main.main.WriteLog = "[Mod Manager] parsing selected client path from registry..." + "\n";
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
                    if (key != null)
                    {
                        Object o;
                        if (comboBox_client.Text == "SoDOff 3.31")
                        {
                            o = key.GetValue("SoDOff_331");
                            if (o != null)
                            {
                                game_path = o.ToString();
                            }
                        }
                        else if (comboBox_client.Text == "Riders Guild 3.31 (online)")
                        {
                            o = key.GetValue("RidersGuild_online");
                            if (o != null)
                            {
                                game_path = o.ToString();
                            }
                        }
                        else if (comboBox_client.Text == "Riders Guild 3.31 (offline)")
                        {
                            o = key.GetValue("RidersGuild_offline");
                            if (o != null)
                            {
                                game_path = o.ToString();
                            }
                        }
                    }
                    key.Close();

                    if (Directory.Exists("Mods") == false)
                    {
                        Directory.CreateDirectory("Mods");
                    }

                    if (mod[index].direct_download == "no")
                    {
                        if (File.Exists("Mods" + @"\" + mod[index].file_name) == true)
                        {
                            file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                            if (file_md5 == mod[index].checksum)
                            {
                                InstallMod(index, game_path);

                                MessageBox.Show("Instalation finished.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (File.Exists("Mods" + @"\" + mod[index].file_name) == false || file_md5 != mod[index].checksum)
                        {
                            MessageBox.Show("This mod must be downloaded manually before installing.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (mod[index].direct_download == "yes")
                    {
                        if (File.Exists("Mods" + @"\" + mod[index].file_name) == true)
                        {
                            file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                            if (file_md5 == mod[index].checksum)
                            {
                                InstallMod(index, game_path);

                                MessageBox.Show("Instalation finished.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (File.Exists("Mods" + @"\" + mod[index].file_name) == false || file_md5 != mod[index].checksum)
                        {
                            WebClient Client = new WebClient();
                            Client.DownloadFile(mod[index].download_link, "Mods" + @"\" + mod[index].file_name);

                            file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                            if (file_md5 == mod[index].checksum)
                            {
                                InstallMod(index, game_path);

                                MessageBox.Show("Instalation finished.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (file_md5 != mod[index].checksum)
                            {
                                MessageBox.Show("Download failed. Check your internet connection.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (listBox_mods.SelectedIndex < 0)
            {
                MessageBox.Show("You must select mod from list before downloading.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listBox_mods.SelectedIndex >= 0)
            {
                int index = mod_index[listBox_mods.SelectedIndex];
                string file_md5 = "";

                if (Directory.Exists("Mods") == false)
                {
                    Directory.CreateDirectory("Mods");
                }

                if (mod[index].direct_download == "no")
                {
                    if (File.Exists("Mods" + @"\" + mod[index].file_name) == true)
                    {
                        file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                        if (file_md5 == mod[index].checksum)
                        {
                            MessageBox.Show("Mod file already downloaded.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (File.Exists("Mods" + @"\" + mod[index].file_name) == false || file_md5 != mod[index].checksum)
                    {
                        System.Diagnostics.Process.Start(mod[index].download_link);
                    }
                }
                else if (mod[index].direct_download == "yes")
                {
                    if (File.Exists("Mods" + @"\" + mod[index].file_name) == true)
                    {
                        file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                        if (file_md5 == mod[index].checksum)
                        {
                            MessageBox.Show("Mod file already downloaded.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (File.Exists("Mods" + @"\" + mod[index].file_name) == false || file_md5 != mod[index].checksum)
                    {
                        WebClient Client = new WebClient();
                        Client.DownloadFile(mod[index].download_link, "Mods" + @"\" + mod[index].file_name);

                        file_md5 = HashingCompute.GetMD5HashFromFile("Mods" + @"\" + mod[index].file_name);
                        if (file_md5 == mod[index].checksum)
                        {
                            MessageBox.Show("Download complete.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (file_md5 != mod[index].checksum)
                        {
                            MessageBox.Show("Download failed. Check your internet connection.", "Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void InstallMod(int index, string game_path)
        {
            Main.main.WriteLog = "[Mod Manager] initializing install process." + "\n";

            if (Directory.Exists("Mods") == false)
            {
                Directory.CreateDirectory("Mods");
            }
            if (File.Exists("Mods" + @"\" + mod[index].file_name) == false)
            {
                Main.main.WriteLog = "[Mod Manager] downloading mod file from remote server..." + "\n";

                WebClient Client = new WebClient();
                Client.DownloadFile(mod[index].download_link, "Mods" + @"\" + mod[index].file_name);
            }

            if (mod[index].dependency != "none")
            {
                Main.main.WriteLog = "[Mod Manager] required dependency detected: " + mod[index].dependency + "\n";
                string result = "";
                result = mod[index].dependency;

                while (result != "none")
                {
                    result = InstallDependency(result, game_path);
                }
            }

            if (mod[index].file_name.Contains(".dll") == true || mod[index].file_name.Contains(".zip") && mod[index].category == "Cosmetic")
            {
                string dir = game_path + @"\" + mod[index].install_path;
                if (Directory.Exists(dir) == false)
                {
                    Directory.CreateDirectory(dir);
                }
                if (File.Exists(game_path + @"\" + mod[index].install_path + @"\" + mod[index].file_name) == false)
                {
                    Main.main.WriteLog = "[Mod Manager] copying mod file: " + mod[index].file_name + "\n";
                    File.Copy("Mods" + @"\" + mod[index].file_name, game_path + @"\" + mod[index].install_path + @"\" + mod[index].file_name);
                }
                else if (File.Exists(game_path + @"\" + mod[index].install_path + @"\" + mod[index].file_name) == true)
                {
                    string file_md5 = HashingCompute.GetMD5HashFromFile(game_path + @"\" + mod[index].install_path + @"\" + mod[index].file_name);
                    if (file_md5 == mod[index].checksum)
                    {
                        Main.main.WriteLog = "[Mod Manager] mod file: " + mod[index].file_name + " already installed, skipping..." + "\n";
                    }
                }
            }
            else if (mod[index].file_name.Contains(".zip") == true && mod[index].category != "Cosmetic")
            {
                ExtractZip("Mods" + @"\" + mod[index].file_name, game_path);
            }
            Main.main.WriteLog = "[Mod Manager] finished installing mod: " + mod[index].name + "\n";
        }

        public string InstallDependency(string dependency_name, string game_dir)
        {
            Main.main.WriteLog = "[Mod Manager] initializing install dependency process." + "\n";
            for (int i = 0; i < mod.Length; i++)
            {
                if (mod[i].name == dependency_name)
                {
                    Main.main.WriteLog = "[Mod Manager] found required dependency: " + mod[i].name + "\n";
                    if (File.Exists("Mods" + @"\" + mod[i].file_name) == false)
                    {
                        Main.main.WriteLog = "[Mod Manager] downloading dependency file from remote server..." + "\n";

                        WebClient Client = new WebClient();
                        Client.DownloadFile(mod[i].download_link, "Mods" + @"\" + mod[i].file_name);
                    }

                    if (mod[i].file_name.Contains(".dll") == true)
                    {
                        string dir = game_dir + @"\" + mod[i].install_path;
                        if (Directory.Exists(dir) == false)
                        {
                            Directory.CreateDirectory(dir);
                        }
                        if (File.Exists(game_dir + @"\" + mod[i].install_path + @"\" + mod[i].file_name) == false)
                        {
                            Main.main.WriteLog = "[Mod Manager] copying dependency file: " + mod[i].file_name + "\n";
                            File.Copy("Mods" + @"\" + mod[i].file_name, game_dir + @"\" + mod[i].install_path + @"\" + mod[i].file_name);
                        }
                        else if (File.Exists(game_dir + @"\" + mod[i].install_path + @"\" + mod[i].file_name) == true)
                        {
                            string file_md5 = HashingCompute.GetMD5HashFromFile(game_dir + @"\" + mod[i].install_path + @"\" + mod[i].file_name);
                            if (file_md5 == mod[i].checksum)
                            {
                                Main.main.WriteLog = "[Mod Manager] dependency file: " + mod[i].file_name + " already installed, skipping..." + "\n";
                            }
                        }
                    }
                    else if (mod[i].file_name.Contains(".zip") == true)
                    {
                        ExtractZip("Mods" + @"\" + mod[i].file_name, game_dir);
                    }
                    Main.main.WriteLog = "[Mod Manager] finished installing dependency: " + mod[i].name + "\n";
                    return mod[i].dependency;
                }
            }
            //returning none to avoid getting stuck in infinite loop
            Main.main.WriteLog = "[Mod Manager] dependency not found: " + dependency_name + "\n";
            return "none";
        }

        void ExtractZip(string zip_path, string dst)
        {
            //read zip contents
            Main.main.WriteLog = "[Mod Manager] reading zip archive..." + "\n";
            byte[] zip = ReadFile(zip_path);
            MemoryStream memzip = new MemoryStream();
            memzip.Write(zip, 0, zip.Length);
            ZipArchive archive = new ZipArchive(memzip);

            //extract it in current directory
            Main.main.WriteLog = "[Mod Manager] extracting zip archive..." + "\n";
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string dir = "";
                Stream unzippedEntryStream = entry.Open();
                string path = dst + @"\" + entry.FullName.Replace(@"/", @"\");
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

public class Mods
{
    public string name;
    public string author;
    public string description;
    public string download_link;
    public string direct_download;
    public string install_path;
    public string dependency;
    public string category;
    public string file_name;
    public string checksum;

    public Mods[] createModsList(string[] textlist)
    {
        int list_params = 11;
        Mods[] modsList = new Mods[textlist.Length / list_params];
        //write to log;
        for (int i = 0; i < (textlist.Length / list_params); i++)
        {
            modsList[i] = new Mods();
            int counter = 0;
            if (i > 0) counter = i * list_params;
            for (int j = counter; j < (counter + list_params); j++)
            {
                if (textlist[j].Contains("ModName=") == true)
                {
                    modsList[i].name = textlist[j].Replace("ModName=", "");
                }
                else if (textlist[j].Contains("ModAuthor=") == true)
                {
                    modsList[i].author = textlist[j].Replace("ModAuthor=", "");
                }
                else if (textlist[j].Contains("ModDescription=") == true)
                {
                    modsList[i].description = textlist[j].Replace("ModDescription=", "");
                }
                else if (textlist[j].Contains("ModDownloadLink=") == true)
                {
                    modsList[i].download_link = textlist[j].Replace("ModDownloadLink=", "");
                }
                else if (textlist[j].Contains("ModDirectDownload=") == true)
                {
                    modsList[i].direct_download = textlist[j].Replace("ModDirectDownload=", "");
                }
                else if (textlist[j].Contains("ModInstallPath=") == true)
                {
                    modsList[i].install_path = textlist[j].Replace("ModInstallPath=", "");
                }
                else if (textlist[j].Contains("ModDependency=") == true)
                {
                    modsList[i].dependency = textlist[j].Replace("ModDependency=", "");
                }
                else if (textlist[j].Contains("ModCategory=") == true)
                {
                    modsList[i].category = textlist[j].Replace("ModCategory=", "");
                }
                else if (textlist[j].Contains("ModFileName=") == true)
                {
                    modsList[i].file_name = textlist[j].Replace("ModFileName=", "");
                }
                else if (textlist[j].Contains("ModChecksum=") == true)
                {
                    modsList[i].checksum = textlist[j].Replace("ModChecksum=", "");
                }
            }
        }
        return modsList;
    }
}
