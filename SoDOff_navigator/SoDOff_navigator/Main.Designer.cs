namespace SoDOff_navigator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.label_log = new System.Windows.Forms.Label();
            this.btn_install_sodoff_online = new System.Windows.Forms.Button();
            this.btn_play_sodoff_online = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.btn_discord_sodoff = new System.Windows.Forms.Button();
            this.btn_play_riders_guild_online = new System.Windows.Forms.Button();
            this.btn_install_riders_guild_online = new System.Windows.Forms.Button();
            this.btn_discord_riders_guild = new System.Windows.Forms.Button();
            this.groupBox_play_online = new System.Windows.Forms.GroupBox();
            this.groupBox_play_offline = new System.Windows.Forms.GroupBox();
            this.btn_play_riders_guild_offline = new System.Windows.Forms.Button();
            this.btn_start_server_riders_guild = new System.Windows.Forms.Button();
            this.btn_install_riders_guild_server = new System.Windows.Forms.Button();
            this.groupBox_social = new System.Windows.Forms.GroupBox();
            this.btn_mod_manager = new System.Windows.Forms.Button();
            this.label_about = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.label_language = new System.Windows.Forms.Label();
            this.groupBox_play_online.SuspendLayout();
            this.groupBox_play_offline.SuspendLayout();
            this.groupBox_social.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(24, 399);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(337, 93);
            this.richTextBox_log.TabIndex = 0;
            this.richTextBox_log.Text = "";
            this.richTextBox_log.TextChanged += new System.EventHandler(this.richTextBox_log_TextChanged);
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(21, 383);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(59, 13);
            this.label_log.TabIndex = 1;
            this.label_log.Text = "Debug log:";
            // 
            // btn_install_sodoff_online
            // 
            this.btn_install_sodoff_online.Location = new System.Drawing.Point(16, 35);
            this.btn_install_sodoff_online.Name = "btn_install_sodoff_online";
            this.btn_install_sodoff_online.Size = new System.Drawing.Size(75, 35);
            this.btn_install_sodoff_online.TabIndex = 2;
            this.btn_install_sodoff_online.Text = "Install \r\nSoDOff";
            this.btn_install_sodoff_online.UseVisualStyleBackColor = true;
            this.btn_install_sodoff_online.Click += new System.EventHandler(this.btn_install_sodoff_online_Click);
            // 
            // btn_play_sodoff_online
            // 
            this.btn_play_sodoff_online.Location = new System.Drawing.Point(16, 93);
            this.btn_play_sodoff_online.Name = "btn_play_sodoff_online";
            this.btn_play_sodoff_online.Size = new System.Drawing.Size(75, 35);
            this.btn_play_sodoff_online.TabIndex = 3;
            this.btn_play_sodoff_online.Text = "Play \r\nSoDOff";
            this.btn_play_sodoff_online.UseVisualStyleBackColor = true;
            this.btn_play_sodoff_online.Click += new System.EventHandler(this.btn_play_sodoff_online_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_title.Location = new System.Drawing.Point(169, 15);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(119, 25);
            this.label_title.TabIndex = 4;
            this.label_title.Text = "Main Menu";
            // 
            // btn_discord_sodoff
            // 
            this.btn_discord_sodoff.Location = new System.Drawing.Point(59, 35);
            this.btn_discord_sodoff.Name = "btn_discord_sodoff";
            this.btn_discord_sodoff.Size = new System.Drawing.Size(78, 35);
            this.btn_discord_sodoff.TabIndex = 5;
            this.btn_discord_sodoff.Text = "Visit Discord\r\n(SoDOff)";
            this.btn_discord_sodoff.UseVisualStyleBackColor = true;
            this.btn_discord_sodoff.Click += new System.EventHandler(this.btn_discord_sodoff_Click);
            // 
            // btn_play_riders_guild_online
            // 
            this.btn_play_riders_guild_online.Location = new System.Drawing.Point(97, 93);
            this.btn_play_riders_guild_online.Name = "btn_play_riders_guild_online";
            this.btn_play_riders_guild_online.Size = new System.Drawing.Size(75, 35);
            this.btn_play_riders_guild_online.TabIndex = 6;
            this.btn_play_riders_guild_online.Text = "Play \r\nRiders Guild";
            this.btn_play_riders_guild_online.UseVisualStyleBackColor = true;
            this.btn_play_riders_guild_online.Click += new System.EventHandler(this.btn_play_riders_guild_online_Click);
            // 
            // btn_install_riders_guild_online
            // 
            this.btn_install_riders_guild_online.Location = new System.Drawing.Point(97, 35);
            this.btn_install_riders_guild_online.Name = "btn_install_riders_guild_online";
            this.btn_install_riders_guild_online.Size = new System.Drawing.Size(75, 35);
            this.btn_install_riders_guild_online.TabIndex = 7;
            this.btn_install_riders_guild_online.Text = "Install \r\nRiders Guild";
            this.btn_install_riders_guild_online.UseVisualStyleBackColor = true;
            this.btn_install_riders_guild_online.Click += new System.EventHandler(this.btn_install_riders_guild_online_Click);
            // 
            // btn_discord_riders_guild
            // 
            this.btn_discord_riders_guild.Location = new System.Drawing.Point(281, 35);
            this.btn_discord_riders_guild.Name = "btn_discord_riders_guild";
            this.btn_discord_riders_guild.Size = new System.Drawing.Size(78, 35);
            this.btn_discord_riders_guild.TabIndex = 8;
            this.btn_discord_riders_guild.Text = "Visit Discord\r\n(Riders Guild)";
            this.btn_discord_riders_guild.UseVisualStyleBackColor = true;
            this.btn_discord_riders_guild.Click += new System.EventHandler(this.btn_discord_riders_guild_Click);
            // 
            // groupBox_play_online
            // 
            this.groupBox_play_online.Controls.Add(this.btn_play_sodoff_online);
            this.groupBox_play_online.Controls.Add(this.btn_install_sodoff_online);
            this.groupBox_play_online.Controls.Add(this.btn_install_riders_guild_online);
            this.groupBox_play_online.Controls.Add(this.btn_play_riders_guild_online);
            this.groupBox_play_online.Location = new System.Drawing.Point(24, 66);
            this.groupBox_play_online.Name = "groupBox_play_online";
            this.groupBox_play_online.Size = new System.Drawing.Size(189, 145);
            this.groupBox_play_online.TabIndex = 9;
            this.groupBox_play_online.TabStop = false;
            this.groupBox_play_online.Text = "Play online";
            // 
            // groupBox_play_offline
            // 
            this.groupBox_play_offline.Controls.Add(this.btn_play_riders_guild_offline);
            this.groupBox_play_offline.Controls.Add(this.btn_start_server_riders_guild);
            this.groupBox_play_offline.Controls.Add(this.btn_install_riders_guild_server);
            this.groupBox_play_offline.Location = new System.Drawing.Point(245, 66);
            this.groupBox_play_offline.Name = "groupBox_play_offline";
            this.groupBox_play_offline.Size = new System.Drawing.Size(200, 145);
            this.groupBox_play_offline.TabIndex = 10;
            this.groupBox_play_offline.TabStop = false;
            this.groupBox_play_offline.Text = "Play offline";
            // 
            // btn_play_riders_guild_offline
            // 
            this.btn_play_riders_guild_offline.Location = new System.Drawing.Point(102, 93);
            this.btn_play_riders_guild_offline.Name = "btn_play_riders_guild_offline";
            this.btn_play_riders_guild_offline.Size = new System.Drawing.Size(78, 35);
            this.btn_play_riders_guild_offline.TabIndex = 2;
            this.btn_play_riders_guild_offline.Text = "Play \r\n(Riders Guild)";
            this.btn_play_riders_guild_offline.UseVisualStyleBackColor = true;
            this.btn_play_riders_guild_offline.Click += new System.EventHandler(this.btn_play_riders_guild_offline_Click);
            // 
            // btn_start_server_riders_guild
            // 
            this.btn_start_server_riders_guild.Location = new System.Drawing.Point(18, 93);
            this.btn_start_server_riders_guild.Name = "btn_start_server_riders_guild";
            this.btn_start_server_riders_guild.Size = new System.Drawing.Size(78, 35);
            this.btn_start_server_riders_guild.TabIndex = 1;
            this.btn_start_server_riders_guild.Text = "Start server\r\n(Riders Guild)";
            this.btn_start_server_riders_guild.UseVisualStyleBackColor = true;
            this.btn_start_server_riders_guild.Click += new System.EventHandler(this.btn_start_server_riders_guild_Click);
            // 
            // btn_install_riders_guild_server
            // 
            this.btn_install_riders_guild_server.Location = new System.Drawing.Point(18, 35);
            this.btn_install_riders_guild_server.Name = "btn_install_riders_guild_server";
            this.btn_install_riders_guild_server.Size = new System.Drawing.Size(162, 35);
            this.btn_install_riders_guild_server.TabIndex = 0;
            this.btn_install_riders_guild_server.Text = "Install server\r\n(Riders Guild)";
            this.btn_install_riders_guild_server.UseVisualStyleBackColor = true;
            this.btn_install_riders_guild_server.Click += new System.EventHandler(this.btn_install_riders_guild_server_Click);
            // 
            // groupBox_social
            // 
            this.groupBox_social.Controls.Add(this.btn_mod_manager);
            this.groupBox_social.Controls.Add(this.btn_discord_sodoff);
            this.groupBox_social.Controls.Add(this.btn_discord_riders_guild);
            this.groupBox_social.Location = new System.Drawing.Point(24, 240);
            this.groupBox_social.Name = "groupBox_social";
            this.groupBox_social.Size = new System.Drawing.Size(421, 100);
            this.groupBox_social.TabIndex = 11;
            this.groupBox_social.TabStop = false;
            this.groupBox_social.Text = "Social";
            // 
            // btn_mod_manager
            // 
            this.btn_mod_manager.Location = new System.Drawing.Point(171, 35);
            this.btn_mod_manager.Name = "btn_mod_manager";
            this.btn_mod_manager.Size = new System.Drawing.Size(75, 35);
            this.btn_mod_manager.TabIndex = 9;
            this.btn_mod_manager.Text = "Mod Manager";
            this.btn_mod_manager.UseVisualStyleBackColor = true;
            this.btn_mod_manager.Click += new System.EventHandler(this.btn_mod_manager_Click);
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_about.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_about.Location = new System.Drawing.Point(112, 356);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(232, 13);
            this.label_about.TabIndex = 12;
            this.label_about.Text = "SoDOff Navigator - handy installer and launcher";
            this.label_about.Click += new System.EventHandler(this.label_about_Click);
            // 
            // comboBox_language
            // 
            this.comboBox_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Location = new System.Drawing.Point(408, 5);
            this.comboBox_language.Name = "comboBox_language";
            this.comboBox_language.Size = new System.Drawing.Size(52, 21);
            this.comboBox_language.TabIndex = 13;
            this.comboBox_language.SelectedIndexChanged += new System.EventHandler(this.comboBox_language_SelectedIndexChanged);
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Location = new System.Drawing.Point(344, 9);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(58, 13);
            this.label_language.TabIndex = 14;
            this.label_language.Text = "Language:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 382);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.comboBox_language);
            this.Controls.Add(this.label_about);
            this.Controls.Add(this.groupBox_social);
            this.Controls.Add(this.groupBox_play_offline);
            this.Controls.Add(this.groupBox_play_online);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.richTextBox_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "SoDOff Navigator";
            this.groupBox_play_online.ResumeLayout(false);
            this.groupBox_play_offline.ResumeLayout(false);
            this.groupBox_social.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Button btn_install_sodoff_online;
        private System.Windows.Forms.Button btn_play_sodoff_online;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button btn_discord_sodoff;
        private System.Windows.Forms.Button btn_play_riders_guild_online;
        private System.Windows.Forms.Button btn_install_riders_guild_online;
        private System.Windows.Forms.Button btn_discord_riders_guild;
        private System.Windows.Forms.GroupBox groupBox_play_online;
        private System.Windows.Forms.GroupBox groupBox_play_offline;
        private System.Windows.Forms.Button btn_play_riders_guild_offline;
        private System.Windows.Forms.Button btn_start_server_riders_guild;
        private System.Windows.Forms.Button btn_install_riders_guild_server;
        private System.Windows.Forms.GroupBox groupBox_social;
        private System.Windows.Forms.Label label_about;
        private System.Windows.Forms.Button btn_mod_manager;
        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.Label label_language;
    }
}

