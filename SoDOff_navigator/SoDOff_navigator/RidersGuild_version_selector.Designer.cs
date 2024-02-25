namespace SoDOff_navigator
{
    partial class RidersGuild_version_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RidersGuild_version_selector));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_319 = new System.Windows.Forms.RadioButton();
            this.radioButton_331 = new System.Windows.Forms.RadioButton();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_331);
            this.groupBox1.Controls.Add(this.radioButton_319);
            this.groupBox1.Location = new System.Drawing.Point(26, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select client version to play";
            // 
            // radioButton_319
            // 
            this.radioButton_319.AutoSize = true;
            this.radioButton_319.Location = new System.Drawing.Point(19, 35);
            this.radioButton_319.Name = "radioButton_319";
            this.radioButton_319.Size = new System.Drawing.Size(46, 17);
            this.radioButton_319.TabIndex = 0;
            this.radioButton_319.TabStop = true;
            this.radioButton_319.Text = "3.19";
            this.radioButton_319.UseVisualStyleBackColor = true;
            // 
            // radioButton_331
            // 
            this.radioButton_331.AutoSize = true;
            this.radioButton_331.Location = new System.Drawing.Point(19, 59);
            this.radioButton_331.Name = "radioButton_331";
            this.radioButton_331.Size = new System.Drawing.Size(46, 17);
            this.radioButton_331.TabIndex = 1;
            this.radioButton_331.TabStop = true;
            this.radioButton_331.Text = "3.31";
            this.radioButton_331.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(89, 185);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // RidersGuild_version_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 222);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RidersGuild_version_selector";
            this.Text = "RidersGuild version selector";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_331;
        private System.Windows.Forms.RadioButton radioButton_319;
        private System.Windows.Forms.Button btn_ok;
    }
}