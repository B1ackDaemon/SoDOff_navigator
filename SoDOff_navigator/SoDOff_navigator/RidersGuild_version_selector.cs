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
        string path_331 = "";
        public RidersGuild_version_selector()
        {
            InitializeComponent();

            Main.main.WriteLog = "[Riders Guild version selector] window opened." + "\n";

            groupBox1.Text = locale.sodoff_version_select;

            radioButton_319.Enabled = false;
            radioButton_331.Enabled = false;
            Main.main.WriteLog = "[Riders Guild version selector] reading registry keys." + "\n";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SoDOffNavigator");
            if (key != null)
            {
                Object o = key.GetValue("RidersGuild_online_319");
                if (o != null)
                {
                    path_319 = o.ToString();
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
            if (path_331 != "not installed")
            {
                radioButton_331.Enabled = true;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (radioButton_319.Checked == true)
            {
                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.19..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_319 + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (radioButton_331.Checked == true)
            {
                Main.main.WriteLog = "[Riders Guild version selector] Launching version: 3.31..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_331 + @"\DOMain.exe";
                clientProcess.Start();
            }
        }
    }
}
