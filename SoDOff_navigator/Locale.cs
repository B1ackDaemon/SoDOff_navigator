namespace SoDOff_navigator
{
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
        public string main_install_rg_assets;
        public string main_start_rg_server;
        public string main_play_rg_offline;
        public string main_visit_sodoff_discord;
        public string main_visit_rg_discord;
        public string main_mod_manager;
        public string main_about;
        public string main_language;
        public string main_play_error_client_not_found;
        public string main_play_error_server_not_found;
        public string sodoff_installer_title;
        public string rg_online_installer_title;
        public string rg_server_installer_title;
        public string rg_assets_installer_title;
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
        public string locate_clients_found;
        public string locate_clients_added;

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
        public string mod_none;

        public string rg_assets_dl_method;
        public string rg_assets_dl_online;
        public string rg_assets_pe_import;
        public string rg_assets_quality;
        public string rg_assets_quality_low;
        public string rg_assets_quality_mid;
        public string rg_assets_quality_high;
        public string rg_assets_pe_path;
        public string rg_assets_pe_description;

        public string error_assets_quality;
        public string error_pe_path;

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
                main_install_rg_assets = "Установка ассетов\nRiders Guild";
                main_start_rg_server = "Запуск сервера Riders Guild";
                main_play_rg_offline = "Запуск Riders Guild";
                main_visit_sodoff_discord = "Discord SoDOff";
                main_visit_rg_discord = "Discord Riders Guild";
                main_mod_manager = "Менеджер Модов";
                main_about = "SoDOff Navigator - полезный установщик и запускатор";
                main_language = "Язык:";
                main_play_error_client_not_found = "Установленный клиент не найден.\nУстановите или укажите установленную ранее копию.";
                main_play_error_server_not_found = "Установленный сервер не найден.\nУстановите или укажите установленную ранее копию.";

                sodoff_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                rg_online_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                rg_server_installer_title = "Вас приветствует установщик!\nВыберите папку для установки\nи нажмите кнопку Установить.";
                rg_assets_installer_title = "Вас приветствует установщик!\nВыберите способ для установки\nи нажмите кнопку Установить.";
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
                locate_clients_found = "Клиентов найдено: ";
                locate_clients_added = "Клиентов добавлено: ";
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
                mod_none = "отсутствует";

                rg_assets_dl_method = "Выберите способ закачки";
                rg_assets_dl_online = "Скачать с сервера Riders Guild";
                rg_assets_pe_import = "Импорт ассетов из Project Edge";
                rg_assets_quality = "Выберите качество ассетов";
                rg_assets_quality_low = "Низкое";
                rg_assets_quality_mid = "Среднее";
                rg_assets_quality_high = "Высокое";
                rg_assets_pe_path = "Путь к Project Edge";
                rg_assets_pe_description = "Укажите папку с установленным\nProject Edge или 3.31.0 archive.sga";

                error_assets_quality = "Не выбрано качество ассетов!";
                error_pe_path = "Не указан путь к Project Edge!";

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
                main_install_rg_assets = "Install assets\n(Riders Guild)";
                main_start_rg_server = "Start server\n(Riders Guild)";
                main_play_rg_offline = "Play\n(Riders Guild)";
                main_visit_sodoff_discord = "Visit Discord (SoDOff)";
                main_visit_rg_discord = "Visit Discord (Riders Guild)";
                main_mod_manager = "Mod Manager";
                main_about = "SoDOff Navigator - handy installer and launcher";
                main_language = "Language:";
                main_play_error_client_not_found = "No installed game client found.\nInstall or locate preinstalled copy.";
                main_play_error_server_not_found = "No installed game server found.\nInstall or locate preinstalled copy.";

                sodoff_installer_title = "Welcome to SoDOff client installer!\nPlease, select install path directory\nand click Install button to proceed.";
                rg_online_installer_title = "Welcome to Riders Guild client installer!\nPlease, select install path directory\nand click Install button to proceed.";
                rg_server_installer_title = "Welcome to Riders Guild server installer!\nPlease, select install path directory\nand click Install button to proceed.";
                rg_assets_installer_title = "Welcome to RG assets installer!\nPlease, select download method\nand click Install button to proceed.";
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
                locate_clients_found = "Clients found: ";
                locate_clients_added = "Clients added: ";
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

                mod_install_finished = "Installation finished.";
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
                mod_none = "none";

                rg_assets_dl_method = "Choose download method";
                rg_assets_dl_online = "Download from Riders Guild server";
                rg_assets_pe_import = "Import assets from Project Edge";
                rg_assets_quality = "Choose assets quality";
                rg_assets_quality_low = "Low";
                rg_assets_quality_mid = "Mid";
                rg_assets_quality_high = "High";
                rg_assets_pe_path = "Project Edge path";
                rg_assets_pe_description = "Choose directory with Project Edge\ninstalled or 3.31.0 archive.sga";

                error_assets_quality = "Assets quality not specified!";
                error_pe_path = "Project Edge path not specified!";
            }
            else if (language == "german")
            {
                current_language = "german";
                main_title = "Hauptmenü";
                main_play_online = "Online spielen";
                main_play_offline = "Offline spielen";
                main_social = "Soziales";
                main_install_sodoff = "SoDOff installieren";
                main_install_rg_online = "Riders Guild installieren";
                main_play_sodoff = "SoDOff spielen";
                main_play_rg_online = "Riders Guild spielen";
                main_install_rg_server = "Server installieren (Riders Guild)";
                main_install_rg_assets = "Assets installieren (Riders Guild)";
                main_start_rg_server = "Server starten (Riders Guild)";
                main_play_rg_offline = "Offline spielen (Riders Guild)";
                main_visit_sodoff_discord = "SoDOff Discord besuchen";
                main_visit_rg_discord = "Riders Guild Discord besuchen";
                main_mod_manager = "Mod-Manager";
                main_about = "SoDOff Navigator - praktischer Installer und Launcher";
                main_language = "Sprache:";
                main_play_error_client_not_found = "Kein installierter Spielclient gefunden. Installieren oder lokalisieren Sie eine zuvor installierte Kopie.";
                main_play_error_server_not_found = "Kein installierter Spielserver gefunden. Installieren oder lokalisieren Sie eine zuvor installierte Kopie.";

                sodoff_installer_title = "Willkommen beim SoDOff-Client-Installer! Bitte wählen Sie das Installationsverzeichnis aus und klicken Sie auf Installieren, um fortzufahren.";
                rg_online_installer_title = "Willkommen beim Riders Guild-Client-Installer! Bitte wählen Sie das Installationsverzeichnis aus und klicken Sie auf Installieren, um fortzufahren.";
                rg_server_installer_title = "Willkommen beim Riders Guild-Server-Installer! Bitte wählen Sie das Installationsverzeichnis aus und klicken Sie auf Installieren, um fortzufahren.";
                rg_assets_installer_title = "Willkommen beim RG-Assets-Installer! Bitte wählen Sie die Download-Methode aus und klicken Sie auf Installieren, um fortzufahren.";
                installer_install_path = "Installationspfad";
                installer_path = "Drücken Sie die Schaltfläche 'Auswählen...'";
                installer_select_path = "Auswählen...";
                sodoff_installer_client_ver = "Client-Version";
                sodoff_installer_version_default = "3.31-Version installieren (Standard)";
                sodoff_installer_version_select = "Ich möchte eine ältere Version installieren";
                installer_install = "Installieren";
                installer_preinstalled = "Ich habe es bereits installiert";
                installer_locate = "Suchen...";
                installer_close = "Schließen";

                error_install_path = "Es wurde kein Ordner ausgewählt!";
                error_client_version = "Es wurde keine Client-Version ausgewählt!";
                error_archive_integrity = "Die Integrität des Archivs konnte nicht überprüft werden! Überprüfen Sie Ihre Internetverbindung.";
                error_install_failed = "Installation fehlgeschlagen.";

                install_in_progress = "Installation läuft, bitte warten...";
                install_complete = "Installation abgeschlossen.";

                locate_in_progress = "Suche läuft, bitte warten...";
                locate_complete = "Suche abgeschlossen.";
                locate_clients_found = "Gefundene Clients: ";
                locate_clients_added = "Hinzugefügte Clients: ";
                installer_finish = "Fertig";
                installer_cancel = "Abbrechen";

                sodoff_version_select = "Wählen Sie die Client-Version zum Spielen aus";

                mods_author = "Mod-Autor";
                mods_category = "Kategorie";
                mod_choose_client = "Wählen Sie den Client zum Installieren aus:";
                mod_list = "Mod-Liste:";
                mod_name = "Mod-Name: ";
                mod_author = "Autor: ";
                mod_description = "Beschreibung: ";
                mod_dependency = "Abhängigkeit: ";
                mod_direct_dl = "Direkter Download: ";
                mod_download = "Herunterladen";
                mod_install = "Installieren";
                mod_download_automatic = "Herunterladen (automatisch)";
                mod_download_manual = "Herunterladen (manuell)";

                mod_error_select_mod_install = "Sie müssen die Mod aus der Liste auswählen, bevor Sie sie installieren.";
                mod_error_select_mod_download = "Sie müssen die Mod aus der Liste auswählen, bevor Sie sie herunterladen.";
                mod_error_select_client = "Sie müssen den Client auswählen, bevor Sie ihn installieren.";

                mod_install_finished = "Installation abgeschlossen.";
                mod_error_manual_download = "Diese Mod muss vor der Installation manuell heruntergeladen werden.";
                mod_download_failed = "Herunterladen fehlgeschlagen. Überprüfen Sie Ihre Internetverbindung.";
                mod_already_downloaded = "Mod-Datei bereits heruntergeladen.";
                mod_download_complete = "Herunterladen abgeschlossen.";

                mod_author_any = "Beliebig";
                mod_category_any = "Beliebig";
                mod_category_cosmetic = "Kosmetisch";
                mod_category_utility = "Dienstprogramm";

                mod_yes = "ja";
                mod_no = "nein";
                mod_none = "keine";

                rg_assets_dl_method = "Wählen Sie die Download-Methode";
                rg_assets_dl_online = "Vom Riders Guild-Server herunterladen";
                rg_assets_pe_import = "Assets aus Project Edge importieren";
                rg_assets_quality = "Wählen Sie die Qualität der Assets aus";
                rg_assets_quality_low = "Niedrig";
                rg_assets_quality_mid = "Mittel";
                rg_assets_quality_high = "Hoch";
                rg_assets_pe_path = "Project Edge-Pfad";
                rg_assets_pe_description = "Wählen Sie das Verzeichnis mit Project Edge installiert oder 3.31.0 archive.sga";

                error_assets_quality = "Assets-Qualität nicht angegeben!";
                error_pe_path = "Project Edge-Pfad nicht angegeben!";
            }

            return stringList;
        }
    }
}
