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
            this.groupBox_install_path.SuspendLayout();
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
            this.btn_close.Location = new System.Drawing.Point(200, 253);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 11;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_install
            // 
            this.btn_install.Location = new System.Drawing.Point(99, 181);
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
            this.label_preinstalled.Location = new System.Drawing.Point(6, 237);
            this.label_preinstalled.Name = "label_preinstalled";
            this.label_preinstalled.Size = new System.Drawing.Size(86, 13);
            this.label_preinstalled.TabIndex = 14;
            this.label_preinstalled.Text = "I have it installed";
            // 
            // btn_locate
            // 
            this.btn_locate.Location = new System.Drawing.Point(9, 253);
            this.btn_locate.Name = "btn_locate";
            this.btn_locate.Size = new System.Drawing.Size(75, 23);
            this.btn_locate.TabIndex = 13;
            this.btn_locate.Text = "Locate...";
            this.btn_locate.UseVisualStyleBackColor = true;
            this.btn_locate.Click += new System.EventHandler(this.btn_locate_Click);
            // 
            // RidersGuild_client_installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
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
    }
}