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
    
    public partial class SoDOff_version_selector : Form
    {
        Locale locale = Main.main.GetLocale();
        string path_16 = "";
        string path_113 = "";
        string path_29 = "";
        string path_312 = "";
        string path_331 = "";
        public SoDOff_version_selector()
        {
            InitializeComponent();

            Main.main.WriteLog = "[SoDOff version selector] window opened." + "\n";

            groupBox1.Text = locale.sodoff_version_select;

            radioButton_16.Enabled = false;
            radioButton_113.Enabled = false;
            radioButton_29.Enabled = false;
            radioButton_312.Enabled = false;
            radioButton_331.Enabled = false;
            Main.main.WriteLog = "[SoDOff version selector] reading registry keys." + "\n";
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
                radioButton_16.Enabled = true;
            }
            if (path_113 != "not installed")
            {
                radioButton_113.Enabled = true;
            }
            if (path_29 != "not installed")
            {
                radioButton_29.Enabled = true;
            }
            if (path_312 != "not installed")
            {
                radioButton_312.Enabled = true;
            }
            if (path_331 != "not installed")
            {
                radioButton_331.Enabled = true;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (radioButton_16.Checked == true)
            {
                Main.main.WriteLog = "[SoDOff version selector] Launching version: 1.6..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_16 + @"\sodoff-launcher.exe";
                clientProcess.StartInfo.WorkingDirectory = path_16;
                clientProcess.Start();
            }
            else if (radioButton_113.Checked == true)
            {
                Main.main.WriteLog = "[SoDOff version selector] Launching version: 1.13..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_113 + @"\sodoff-launcher.exe";
                clientProcess.StartInfo.WorkingDirectory = path_113;
                clientProcess.Start();
            }
            else if (radioButton_29.Checked == true)
            {
                Main.main.WriteLog = "[SoDOff version selector] Launching version: 2.9..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_29 + @"\DOMain.exe";
                clientProcess.Start();
            }
            else if (radioButton_312.Checked == true)
            {
                Main.main.WriteLog = "[SoDOff version selector] Launching version: 3.12..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_312 + @"\sodoff-launcher.exe";
                clientProcess.StartInfo.WorkingDirectory = path_312;
                clientProcess.Start();
            }
            else if (radioButton_331.Checked == true)
            {
                Main.main.WriteLog = "[SoDOff version selector] Launching version: 3.31..." + "\n";
                Process clientProcess = new Process();
                clientProcess.StartInfo.FileName = path_331 + @"\DOMain.exe";
                clientProcess.Start();
            }
        }
    }
}
