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

namespace SoDOff_navigator
{
    public partial class RidersGuild_version_selector : Form
    {
        Locale locale = Main.main.GetLocale();
        string path_319 = "";
        string path_321 = "";
        string path_326 = "";
        string path_331 = "";
        string mode = "";
        string md5 = "";
        public RidersGuild_version_selector(string mode_caller)
        {
            InitializeComponent();

            Main.main.WriteLog = "[Riders Guild version selector] window opened." + "\n";

            groupBox1.Text = locale.sodoff_version_select;

            radioButton_319.Enabled = false;
            radioButton_321.Enabled = false;
            radioButton_326.Enabled = false;
            radioButton_331.Enabled = false;

            mode = mode_caller;
            Main.main.WriteLog = "[Riders Guild version selector] reading registry keys." + "\n";
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
                radioButton_319.Enabled = true;
            }
            if (path_321 != "not installed")
            {
                radioButton_321.Enabled = true;
            }
            if (path_326 != "not installed")
            {
                radioButton_326.Enabled = true;
            }
            if (path_331 != "not installed")
            {
                radioButton_331.Enabled = true;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (radioButton_319.Checked == true)
            {
                if (mode == "online")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_319 + @"\DOMain_Data\resources.assets");
                    if (md5 != "dbeac93ca6a74a3e136d57c1658e9579")
                    {
                        ClientPatcher.PatchClient(path_319, "3.19", "online");
                    }
                }
                else if (mode == "offline")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_319 + @"\DOMain_Data\resources.assets");
                    if (md5 != "3bf6fb34efa8ba3a5bedbe3b4b4641d5")
                    {
                        ClientPatcher.PatchClient(path_319, "3.19", "offline");
                    }
                }

                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.19..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_319 + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (radioButton_321.Checked == true)
            {
                if (mode == "online")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_321 + @"\DOMain_Data\resources.assets");
                    if (md5 != "3e408ff83c732cc63658a26a8d9ddf10")
                    {
                        ClientPatcher.PatchClient(path_321, "3.21", "online");
                    }
                }
                else if (mode == "offline")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_321 + @"\DOMain_Data\resources.assets");
                    if (md5 != "71467a9d220435669b713e3c03a5076c")
                    {
                        ClientPatcher.PatchClient(path_321, "3.21", "offline");
                    }
                }

                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.21..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_321 + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (radioButton_326.Checked == true)
            {
                if (mode == "online")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_326 + @"\DOMain_Data\resources.assets");
                    if (md5 != "af86180040420fcf2c64e613024db81f")
                    {
                        ClientPatcher.PatchClient(path_326, "3.26", "online");
                    }
                }
                else if (mode == "offline")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_326 + @"\DOMain_Data\resources.assets");
                    if (md5 != "f179ccd882ee22e6d6b4005df9b81268")
                    {
                        ClientPatcher.PatchClient(path_326, "3.26", "offline");
                    }
                }

                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.26..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_326 + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (radioButton_331.Checked == true)
            {
                if (mode == "online")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_331 + @"\DOMain_Data\resources.assets");
                    if (md5 != "83b1272b4c5f5497a02a8c204eba3326")
                    {
                        ClientPatcher.PatchClient(path_331, "3.31", "online");
                    }
                }
                else if (mode == "offline")
                {
                    md5 = HashingCompute.GetMD5HashFromFile(path_331 + @"\DOMain_Data\resources.assets");
                    if (md5 != "9cb7367af109984591568fe9165b75a1")
                    {
                        ClientPatcher.PatchClient(path_331, "3.31", "offline");
                    }
                }

                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.31..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_331 + @"\DOMain.exe";
                clientProcess.Start();
            }
        }
    }
}
