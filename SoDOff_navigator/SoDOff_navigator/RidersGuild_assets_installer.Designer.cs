namespace SoDOff_navigator
{
    partial class RidersGuild_assets_installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RidersGuild_assets_installer));
            this.groupBox_download = new System.Windows.Forms.GroupBox();
            this.radioButton_edge = new System.Windows.Forms.RadioButton();
            this.radioButton_online = new System.Windows.Forms.RadioButton();
            this.groupBox_edge = new System.Windows.Forms.GroupBox();
            this.label_pe_desc = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.btn_edge_path = new System.Windows.Forms.Button();
            this.btn_install = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.groupBox_quality = new System.Windows.Forms.GroupBox();
            this.radioButton_high = new System.Windows.Forms.RadioButton();
            this.radioButton_mid = new System.Windows.Forms.RadioButton();
            this.radioButton_low = new System.Windows.Forms.RadioButton();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_files = new System.Windows.Forms.Label();
            this.groupBox_download.SuspendLayout();
            this.groupBox_edge.SuspendLayout();
            this.groupBox_quality.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_download
            // 
            this.groupBox_download.Controls.Add(this.radioButton_edge);
            this.groupBox_download.Controls.Add(this.radioButton_online);
            this.groupBox_download.Location = new System.Drawing.Point(21, 83);
            this.groupBox_download.Name = "groupBox_download";
            this.groupBox_download.Size = new System.Drawing.Size(318, 69);
            this.groupBox_download.TabIndex = 0;
            this.groupBox_download.TabStop = false;
            this.groupBox_download.Text = "Choose download method";
            // 
            // radioButton_edge
            // 
            this.radioButton_edge.AutoSize = true;
            this.radioButton_edge.Location = new System.Drawing.Point(17, 42);
            this.radioButton_edge.Name = "radioButton_edge";
            this.radioButton_edge.Size = new System.Drawing.Size(174, 17);
            this.radioButton_edge.TabIndex = 1;
            this.radioButton_edge.TabStop = true;
            this.radioButton_edge.Text = "Import assets from Project Edge";
            this.radioButton_edge.UseVisualStyleBackColor = true;
            this.radioButton_edge.CheckedChanged += new System.EventHandler(this.radioButton_edge_CheckedChanged);
            // 
            // radioButton_online
            // 
            this.radioButton_online.AutoSize = true;
            this.radioButton_online.Location = new System.Drawing.Point(17, 19);
            this.radioButton_online.Name = "radioButton_online";
            this.radioButton_online.Size = new System.Drawing.Size(188, 17);
            this.radioButton_online.TabIndex = 0;
            this.radioButton_online.TabStop = true;
            this.radioButton_online.Text = "Download from Riders Guild server";
            this.radioButton_online.UseVisualStyleBackColor = true;
            this.radioButton_online.CheckedChanged += new System.EventHandler(this.radioButton_online_CheckedChanged);
            // 
            // groupBox_edge
            // 
            this.groupBox_edge.Controls.Add(this.label_pe_desc);
            this.groupBox_edge.Controls.Add(this.textBox_path);
            this.groupBox_edge.Controls.Add(this.btn_edge_path);
            this.groupBox_edge.Location = new System.Drawing.Point(21, 214);
            this.groupBox_edge.Name = "groupBox_edge";
            this.groupBox_edge.Size = new System.Drawing.Size(318, 89);
            this.groupBox_edge.TabIndex = 1;
            this.groupBox_edge.TabStop = false;
            this.groupBox_edge.Text = "Project Edge path";
            // 
            // label_pe_desc
            // 
            this.label_pe_desc.AutoSize = true;
            this.label_pe_desc.Location = new System.Drawing.Point(17, 19);
            this.label_pe_desc.Name = "label_pe_desc";
            this.label_pe_desc.Size = new System.Drawing.Size(175, 26);
            this.label_pe_desc.TabIndex = 5;
            this.label_pe_desc.Text = "Choose directory with Project Edge \r\ninstalled or 3.31.0 archive.sga";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(17, 54);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(210, 20);
            this.textBox_path.TabIndex = 3;
            this.textBox_path.Text = "press \"Select...\" button";
            // 
            // btn_edge_path
            // 
            this.btn_edge_path.Location = new System.Drawing.Point(231, 52);
            this.btn_edge_path.Name = "btn_edge_path";
            this.btn_edge_path.Size = new System.Drawing.Size(75, 23);
            this.btn_edge_path.TabIndex = 4;
            this.btn_edge_path.Text = "Select...";
            this.btn_edge_path.UseVisualStyleBackColor = true;
            this.btn_edge_path.Click += new System.EventHandler(this.btn_edge_path_Click);
            // 
            // btn_install
            // 
            this.btn_install.Location = new System.Drawing.Point(133, 319);
            this.btn_install.Name = "btn_install";
            this.btn_install.Size = new System.Drawing.Size(75, 35);
            this.btn_install.TabIndex = 2;
            this.btn_install.Text = "Install";
            this.btn_install.UseVisualStyleBackColor = true;
            this.btn_install.Click += new System.EventHandler(this.btn_install_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(277, 377);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.Location = new System.Drawing.Point(13, 7);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(250, 60);
            this.label_title.TabIndex = 6;
            this.label_title.Text = "Welcome to RG assets installer! \r\nPlease, select download method \r\nand click Inst" +
    "all button to proceed.";
            // 
            // groupBox_quality
            // 
            this.groupBox_quality.Controls.Add(this.radioButton_high);
            this.groupBox_quality.Controls.Add(this.radioButton_mid);
            this.groupBox_quality.Controls.Add(this.radioButton_low);
            this.groupBox_quality.Location = new System.Drawing.Point(21, 158);
            this.groupBox_quality.Name = "groupBox_quality";
            this.groupBox_quality.Size = new System.Drawing.Size(319, 51);
            this.groupBox_quality.TabIndex = 7;
            this.groupBox_quality.TabStop = false;
            this.groupBox_quality.Text = "Choose assets quality";
            // 
            // radioButton_high
            // 
            this.radioButton_high.AutoSize = true;
            this.radioButton_high.Location = new System.Drawing.Point(158, 23);
            this.radioButton_high.Name = "radioButton_high";
            this.radioButton_high.Size = new System.Drawing.Size(47, 17);
            this.radioButton_high.TabIndex = 3;
            this.radioButton_high.TabStop = true;
            this.radioButton_high.Text = "High";
            this.radioButton_high.UseVisualStyleBackColor = true;
            this.radioButton_high.CheckedChanged += new System.EventHandler(this.radioButton_high_CheckedChanged);
            // 
            // radioButton_mid
            // 
            this.radioButton_mid.AutoSize = true;
            this.radioButton_mid.Location = new System.Drawing.Point(87, 23);
            this.radioButton_mid.Name = "radioButton_mid";
            this.radioButton_mid.Size = new System.Drawing.Size(42, 17);
            this.radioButton_mid.TabIndex = 2;
            this.radioButton_mid.TabStop = true;
            this.radioButton_mid.Text = "Mid";
            this.radioButton_mid.UseVisualStyleBackColor = true;
            this.radioButton_mid.CheckedChanged += new System.EventHandler(this.radioButton_mid_CheckedChanged);
            // 
            // radioButton_low
            // 
            this.radioButton_low.AutoSize = true;
            this.radioButton_low.Location = new System.Drawing.Point(17, 23);
            this.radioButton_low.Name = "radioButton_low";
            this.radioButton_low.Size = new System.Drawing.Size(45, 17);
            this.radioButton_low.TabIndex = 1;
            this.radioButton_low.TabStop = true;
            this.radioButton_low.Text = "Low";
            this.radioButton_low.UseVisualStyleBackColor = true;
            this.radioButton_low.CheckedChanged += new System.EventHandler(this.radioButton_low_CheckedChanged);
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(14, 493);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(67, 13);
            this.labelDownloaded.TabIndex = 25;
            this.labelDownloaded.Text = "Downloaded";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(187, 493);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 24;
            this.labelSpeed.Text = "Speed";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 447);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 23);
            this.progressBar.TabIndex = 23;
            // 
            // label_files
            // 
            this.label_files.AutoSize = true;
            this.label_files.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_files.Location = new System.Drawing.Point(56, 520);
            this.label_files.Name = "label_files";
            this.label_files.Size = new System.Drawing.Size(152, 20);
            this.label_files.TabIndex = 26;
            this.label_files.Text = "Files: 10000 / 11000";
            // 
            // RidersGuild_assets_installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 412);
            this.Controls.Add(this.label_files);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox_quality);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_install);
            this.Controls.Add(this.groupBox_edge);
            this.Controls.Add(this.groupBox_download);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RidersGuild_assets_installer";
            this.Text = "RidersGuild_assets_installer";
            this.groupBox_download.ResumeLayout(false);
            this.groupBox_download.PerformLayout();
            this.groupBox_edge.ResumeLayout(false);
            this.groupBox_edge.PerformLayout();
            this.groupBox_quality.ResumeLayout(false);
            this.groupBox_quality.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_download;
        private System.Windows.Forms.RadioButton radioButton_edge;
        private System.Windows.Forms.RadioButton radioButton_online;
        private System.Windows.Forms.GroupBox groupBox_edge;
        private System.Windows.Forms.Label label_pe_desc;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button btn_edge_path;
        private System.Windows.Forms.Button btn_install;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.GroupBox groupBox_quality;
        private System.Windows.Forms.RadioButton radioButton_high;
        private System.Windows.Forms.RadioButton radioButton_mid;
        private System.Windows.Forms.RadioButton radioButton_low;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_files;
    }
}