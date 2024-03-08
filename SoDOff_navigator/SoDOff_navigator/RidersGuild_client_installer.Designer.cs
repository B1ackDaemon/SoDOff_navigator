namespace SoDOff_navigator
{
    partial class RidersGuild_client_installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RidersGuild_client_installer));
            this.label_title = new System.Windows.Forms.Label();
            this.groupBox_install_path = new System.Windows.Forms.GroupBox();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.btn_install_path = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_install = new System.Windows.Forms.Button();
            this.label_preinstalled = new System.Windows.Forms.Label();
            this.btn_locate = new System.Windows.Forms.Button();
            this.groupBox_client_ver = new System.Windows.Forms.GroupBox();
            this.comboBox_version = new System.Windows.Forms.ComboBox();
            this.radioButton_version_default = new System.Windows.Forms.RadioButton();
            this.radioButton_version_select = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.groupBox_install_path.SuspendLayout();
            this.groupBox_client_ver.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.Location = new System.Drawing.Point(-1, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(291, 60);
            this.label_title.TabIndex = 6;
            this.label_title.Text = "Welcome to Riders Guild client installer! \r\nPlease, select install path directory" +
    " \r\nand click Install button to proceed.";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_install_path
            // 
            this.groupBox_install_path.Controls.Add(this.textBox_path);
            this.groupBox_install_path.Controls.Add(this.btn_install_path);
            this.groupBox_install_path.Location = new System.Drawing.Point(21, 89);
            this.groupBox_install_path.Name = "groupBox_install_path";
            this.groupBox_install_path.Size = new System.Drawing.Size(238, 58);
            this.groupBox_install_path.TabIndex = 12;
            this.groupBox_install_path.TabStop = false;
            this.groupBox_install_path.Text = "Install path";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(15, 24);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(117, 20);
            this.textBox_path.TabIndex = 0;
            this.textBox_path.Text = "press \"Select...\" button";
            // 
            // btn_install_path
            // 
            this.btn_install_path.Location = new System.Drawing.Point(138, 21);
            this.btn_install_path.Name = "btn_install_path";
            this.btn_install_path.Size = new System.Drawing.Size(75, 23);
            this.btn_install_path.TabIndex = 2;
            this.btn_install_path.Text = "Select...";
            this.btn_install_path.UseVisualStyleBackColor = true;
            this.btn_install_path.Click += new System.EventHandler(this.btn_install_path_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(200, 306);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 11;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_install
            // 
            this.btn_install.Location = new System.Drawing.Point(99, 246);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(75, 33);
            this.btn_install.TabIndex = 10;
            this.btn_install.Text = "Install";
            this.btn_install.UseVisualStyleBackColor = true;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // label_preinstalled
            // 
            this.label_preinstalled.AutoSize = true;
            this.label_preinstalled.Location = new System.Drawing.Point(6, 290);
            this.label_preinstalled.Name = "label_preinstalled";
            this.label_preinstalled.Size = new System.Drawing.Size(86, 13);
            this.label_preinstalled.TabIndex = 14;
            this.label_preinstalled.Text = "I have it installed";
            // 
            // btn_locate
            // 
            this.btn_locate.Location = new System.Drawing.Point(9, 306);
            this.btn_locate.Name = "btn_locate";
            this.btn_locate.Size = new System.Drawing.Size(75, 23);
            this.btn_locate.TabIndex = 13;
            this.btn_locate.Text = "Locate...";
            this.btn_locate.UseVisualStyleBackColor = true;
            this.btn_locate.Click += new System.EventHandler(this.btn_locate_Click);
            // 
            // groupBox_client_ver
            // 
            this.groupBox_client_ver.Controls.Add(this.comboBox_version);
            this.groupBox_client_ver.Controls.Add(this.radioButton_version_default);
            this.groupBox_client_ver.Controls.Add(this.radioButton_version_select);
            this.groupBox_client_ver.Location = new System.Drawing.Point(21, 153);
            this.groupBox_client_ver.Name = "groupBox_client_ver";
            this.groupBox_client_ver.Size = new System.Drawing.Size(238, 75);
            this.groupBox_client_ver.TabIndex = 15;
            this.groupBox_client_ver.TabStop = false;
            this.groupBox_client_ver.Text = "Client version";
            // 
            // comboBox_version
            // 
            this.comboBox_version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_version.FormattingEnabled = true;
            this.comboBox_version.Location = new System.Drawing.Point(181, 44);
            this.comboBox_version.Name = "comboBox_version";
            this.comboBox_version.Size = new System.Drawing.Size(45, 21);
            this.comboBox_version.TabIndex = 8;
            this.comboBox_version.Visible = false;
            // 
            // radioButton_version_default
            // 
            this.radioButton_version_default.AutoSize = true;
            this.radioButton_version_default.Checked = true;
            this.radioButton_version_default.Location = new System.Drawing.Point(16, 21);
            this.radioButton_version_default.Name = "radioButton_version_default";
            this.radioButton_version_default.Size = new System.Drawing.Size(154, 17);
            this.radioButton_version_default.TabIndex = 6;
            this.radioButton_version_default.TabStop = true;
            this.radioButton_version_default.Text = "Install 3.31 version (default)";
            this.radioButton_version_default.UseVisualStyleBackColor = true;
            this.radioButton_version_default.CheckedChanged += new System.EventHandler(this.radioButton_version_default_CheckedChanged);
            // 
            // radioButton_version_select
            // 
            this.radioButton_version_select.AutoSize = true;
            this.radioButton_version_select.Location = new System.Drawing.Point(16, 44);
            this.radioButton_version_select.Name = "radioButton_version_select";
            this.radioButton_version_select.Size = new System.Drawing.Size(158, 17);
            this.radioButton_version_select.TabIndex = 7;
            this.radioButton_version_select.Text = "I want to install older version";
            this.radioButton_version_select.UseVisualStyleBackColor = true;
            this.radioButton_version_select.CheckedChanged += new System.EventHandler(this.radioButton_version_select_CheckedChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 349);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.TabIndex = 16;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(191, 395);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 17;
            this.labelSpeed.Text = "Speed";
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(18, 395);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(67, 13);
            this.labelDownloaded.TabIndex = 19;
            this.labelDownloaded.Text = "Downloaded";
            // 
            // RidersGuild_client_installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox_client_ver);
            this.Controls.Add(this.label_preinstalled);
            this.Controls.Add(this.btn_locate);
            this.Controls.Add(this.groupBox_install_path);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_install);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RidersGuild_client_installer";
            this.Text = "RidersGuild client installer";
            this.groupBox_install_path.ResumeLayout(false);
            this.groupBox_install_path.PerformLayout();
            this.groupBox_client_ver.ResumeLayout(false);
            this.groupBox_client_ver.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.GroupBox groupBox_install_path;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button btn_install_path;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.Label label_preinstalled;
        private System.Windows.Forms.Button btn_locate;
        private System.Windows.Forms.GroupBox groupBox_client_ver;
        private System.Windows.Forms.ComboBox comboBox_version;
        private System.Windows.Forms.RadioButton radioButton_version_default;
        private System.Windows.Forms.RadioButton radioButton_version_select;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelDownloaded;
    }
}