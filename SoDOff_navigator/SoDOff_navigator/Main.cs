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

    public class Locale
    {
        public string current_language;
        public string main_title;
        public string main_play_online;
        public string main_play_offline;
        public string main_social;
        public string main_install_sodoff;
        public string main_install_rg_online;
        public string main_play_sodoff;
        public string main_play_rg_online;
        public string main_install_rg_server;
        public string main_start_rg_server;
        public string main_play_rg_offline;
        public string main_visit_sodoff_discord;
        public string main_visit_rg_discord;
        public string main_mod_manager;
        public string main_about;
        public string main_language;
        public string sodoff_installer_title;
        public string rg_online_installer_title;
        public string rg_server_installer_title;
        public string sodoff_installer_client_ver;
        public string sodoff_installer_version_default;
        public string sodoff_installer_version_select;
        public string sodoff_version_select;
        public string installer_install_path;
        public string installer_path;
        public string installer_select_path;
        public string installer_install;
        public string installer_preinstalled;
        public string installer_locate;
        public string installer_close;
        public string installer_finish;
        public string installer_cancel;

        public string error_install_path;
        public string error_client_version;
        public string error_archive_integrity;
        public string error_install_failed;

        public string install_in_progress;
        public string install_complete;
        public string locate_in_progress;
        public string locate_complete;

        public string mods_author;
        public string mods_category;
        public string mod_choose_client;
        public string mod_list;
        public string mod_name;
        public string mod_author;
        public string mod_description;
        public string mod_dependency;
        public string mod_direct_dl;
        public string mod_download;
        public string mod_install;
        public string mod_download_automatic;
        public string mod_download_manual;

        public string mod_error_select_mod_install;
        public string mod_error_select_mod_download;
        public string mod_error_select_client;
        public string mod_install_finished;
        public string mod_error_manual_download;
        public string mod_download_complete;
        public string mod_download_failed;
        public string mod_already_downloaded;

        public string mod_author_any;
        public string mod_category_any;
        public string mod_category_cosmetic;
        public string mod_category_utility;

        public string mod_yes;
        public string mod_no;

        public Locale updateLocale(string language)
        {
            Locale stringList = new Locale();

            if (language == "russian")
            {
                current_language = "russian";
                main_title = "Главное Меню";
                main_play_online = "Играть онлайн";
                main_play_offline = "Играть офлайн";
                main_social = "Соцсети";
                main_install_sodoff = "Установка SoDOff";
                main_install_rg_online = "Установка Riders Guild";
                main_play_sodoff = "Запуск SoDOff";
                main_play_rg_online = "Запуск Riders Guild";
                main_install_rg_server = "Установка сервера\nRiders Guild";
                main_start_rg_server = "Запуск сервера Riders Guild";
                main_play_rg_offline = "Запуск Riders Guild";
                main_visit_sodoff_discord = "Discord SoDOff";
                main_visit_rg_discord = "Discord Riders Guild";
                main_mod_manager = "Менеджер Модов";
                main_about = "SoDOff Navigator - полезный установщик и запускатор";
                main_language = "Язык:";

                sodoff_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                rg_online_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                rg_server_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                installer_install_path = "Путь для установки";
                installer_path = "Нажмите 'Выбрать...'";
                installer_select_path = "Выбрать...";
                sodoff_installer_client_ver = "Версия клиента";
                sodoff_installer_version_default = "Установить версию 3.31 (по умолч.)";
                sodoff_installer_version_select = "Установить старую версию";
                installer_install = "Установить";
                installer_preinstalled = "Уже установлено";
                installer_locate = "Указать...";
                installer_close = "Закрыть";

                error_install_path = "Папка для установки не выбрана!";
                error_client_version = "Версия клиента не выбрана!";
                error_archive_integrity = "Не удалось сверить целостность архива!\nПроверьте интернет соединение.";
                error_install_failed = "Установка не удалась.";

                install_in_progress = "Идет установка...";
                install_complete = "Установка закончена.";

                locate_in_progress = "Идет сканирование...";
                locate_complete = "Сканирование закончено.";
                installer_finish = "Завершить";
                installer_cancel = "Отмена";
                sodoff_version_select = "Какую версию игры запустить";

                mods_author = "Автор Мода";
                mods_category = "Категория";
                mod_choose_client = "Клиент для установки:";
                mod_list = "Список модов:";
                mod_name = "Название мода: ";
                mod_author = "Автор: ";
                mod_description = "Описание: ";
                mod_dependency = "Зависимость: ";
                mod_direct_dl = "Прямая закачка: ";
                mod_download = "Скачать";
                mod_install = "Установить";
                mod_download_automatic = "Скачать (автоматич)";
                mod_download_manual = "Скачать (вручную)";

                mod_error_select_mod_install = "Выберите мод из списка перед установкой.";
                mod_error_select_mod_download = "Выберите мод из списка перед закачкой.";
                mod_error_select_client = "Выберите клиент перед установкой.";

                mod_install_finished = "Установка закончена.";
                mod_error_manual_download = "Этот мод нужно скачать вручную перед установкой.";
                mod_download_failed = "Закачка не удалась. Проверьте интернет соединение.";

                mod_already_downloaded = "Файл с модом уже скачан.";
                mod_download_complete = "Закачка завершена.";

                mod_author_any = "Любой";
                mod_category_any = "Любая";
                mod_category_cosmetic = "Косметика";
                mod_category_utility = "Утилита";

                mod_yes = "да";
                mod_no = "нет";
            }
            else if (language == "english")
            {
                current_language = "english";
                main_title = "Main Menu";
                main_play_online = "Play online";
                main_play_offline = "Play offline";
                main_social = "Social";
                main_install_sodoff = "Install SoDOff";
                main_install_rg_online = "Install\nRiders Guild";
                main_play_sodoff = "Play\nSoDOff";
                main_play_rg_online = "Play\nRiders Guild";
                main_install_rg_server = "Install server\n(Riders Guild)";
                main_start_rg_server = "Start server\n(Riders Guild)";
                main_play_rg_offline = "Play\n(Riders Guild)";
                main_visit_sodoff_discord = "Visit Discord (SoDOff)";
                main_visit_rg_discord = "Visit Discord (Riders Guild)";
                main_mod_manager = "Mod Manager";
                main_about = "SoDOff Navigator - handy installer and launcher";
                main_language = "Language:";

                sodoff_installer_title = "Welcome to SoDOff client installer!\nPlease, select install path directory\nand click Install button to proceed.";
                rg_online_installer_title = "Welcome to Riders Guild client installer!\nPlease, select install path directory\nand click Install button to proceed.";
                rg_server_installer_title = "Welcome to Riders Guild server installer!\nPlease, select install path directory\nand click Install button to proceed.";
                installer_install_path = "Install path";
                installer_path = "Press 'Select...' button";
                installer_select_path = "Select...";
                sodoff_installer_client_ver = "Client version";
                sodoff_installer_version_default = "Install 3.31 version (default)";
                sodoff_installer_version_select = "I want to install older version";
                installer_install = "Install";
                installer_preinstalled = "I have it installed";
                installer_locate = "Locate...";
                installer_close = "Close";

                error_install_path = "No folder was selected!";
                error_client_version = "No client version selected!";
                error_archive_integrity = "Failed to verify archive integrity!\nCheck your internet connection.";
                error_install_failed = "Installation failed.";

                install_in_progress = "Installing, please wait...";
                install_complete = "Installation finished.";

                locate_in_progress = "Scanning, please wait...";
                locate_complete = "Scanning finished.";
                installer_finish = "Finish";
                installer_cancel = "Cancel";

                sodoff_version_select = "Select client version to play";

                mods_author = "Mod Author";
                mods_category = "Category";
                mod_choose_client = "Choose client to install:";
                mod_list = "Mods list:";
                mod_name = "Mod name: ";
                mod_author = "Author: ";
                mod_description = "Description: ";
                mod_dependency = "Dependency: ";
                mod_direct_dl = "Direct download: ";
                mod_download = "Download";
                mod_install = "Install";
                mod_download_automatic = "Download (automatic)";
                mod_download_manual = "Download (manual)";

                mod_error_select_mod_install = "You must select mod from list before installing.";
                mod_error_select_mod_download = "You must select mod from list before downloading.";
                mod_error_select_client = "You must choose client before installing.";

                mod_install_finished = "Instalation finished.";
                mod_error_manual_download = "This mod must be downloaded manually before installing.";
                mod_download_failed = "Download failed. Check your internet connection.";
                mod_already_downloaded = "Mod file already downloaded.";
                mod_download_complete = "Download complete.";

                mod_author_any = "Any";
                mod_category_any = "Any";
                mod_category_cosmetic = "Cosmetic";
                mod_category_utility = "Utility";

                mod_yes = "yes";
                mod_no = "no";
            }

            return stringList;
        }
    }
}
