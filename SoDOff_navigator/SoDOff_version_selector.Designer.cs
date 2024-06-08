namespace SoDOff_navigator
{
    partial class SoDOff_version_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoDOff_version_selector));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_331 = new System.Windows.Forms.RadioButton();
            this.radioButton_312 = new System.Windows.Forms.RadioButton();
            this.radioButton_29 = new System.Windows.Forms.RadioButton();
            this.radioButton_113 = new System.Windows.Forms.RadioButton();
            this.radioButton_16 = new System.Windows.Forms.RadioButton();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_331);
            this.groupBox1.Controls.Add(this.radioButton_312);
            this.groupBox1.Controls.Add(this.radioButton_29);
            this.groupBox1.Controls.Add(this.radioButton_113);
            this.groupBox1.Controls.Add(this.radioButton_16);
            this.groupBox1.Location = new System.Drawing.Point(26, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select client version to play";
            // 
            // radioButton_331
            // 
            this.radioButton_331.AutoSize = true;
            this.radioButton_331.Location = new System.Drawing.Point(19, 118);
            this.radioButton_331.Name = "radioButton_331";
            this.radioButton_331.Size = new System.Drawing.Size(46, 17);
            this.radioButton_331.TabIndex = 4;
            this.radioButton_331.TabStop = true;
            this.radioButton_331.Text = "3.31";
            this.radioButton_331.UseVisualStyleBackColor = true;
            // 
            // radioButton_312
            // 
            this.radioButton_312.AutoSize = true;
            this.radioButton_312.Location = new System.Drawing.Point(19, 95);
            this.radioButton_312.Name = "radioButton_312";
            this.radioButton_312.Size = new System.Drawing.Size(46, 17);
            this.radioButton_312.TabIndex = 3;
            this.radioButton_312.TabStop = true;
            this.radioButton_312.Text = "3.12";
            this.radioButton_312.UseVisualStyleBackColor = true;
            // 
            // radioButton_29
            // 
            this.radioButton_29.AutoSize = true;
            this.radioButton_29.Location = new System.Drawing.Point(19, 72);
            this.radioButton_29.Name = "radioButton_29";
            this.radioButton_29.Size = new System.Drawing.Size(40, 17);
            this.radioButton_29.TabIndex = 2;
            this.radioButton_29.TabStop = true;
            this.radioButton_29.Text = "2.9";
            this.radioButton_29.UseVisualStyleBackColor = true;
            // 
            // radioButton_113
            // 
            this.radioButton_113.AutoSize = true;
            this.radioButton_113.Location = new System.Drawing.Point(19, 49);
            this.radioButton_113.Name = "radioButton_113";
            this.radioButton_113.Size = new System.Drawing.Size(46, 17);
            this.radioButton_113.TabIndex = 1;
            this.radioButton_113.TabStop = true;
            this.radioButton_113.Text = "1.13";
            this.radioButton_113.UseVisualStyleBackColor = true;
            // 
            // radioButton_16
            // 
            this.radioButton_16.AutoSize = true;
            this.radioButton_16.Location = new System.Drawing.Point(19, 26);
            this.radioButton_16.Name = "radioButton_16";
            this.radioButton_16.Size = new System.Drawing.Size(40, 17);
            this.radioButton_16.TabIndex = 0;
            this.radioButton_16.TabStop = true;
            this.radioButton_16.Text = "1.6";
            this.radioButton_16.UseVisualStyleBackColor = true;
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
            // SoDOff_version_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 222);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SoDOff_version_selector";
            this.Text = "SoDOff version selector";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_331;
        private System.Windows.Forms.RadioButton radioButton_312;
        private System.Windows.Forms.RadioButton radioButton_29;
        private System.Windows.Forms.RadioButton radioButton_113;
        private System.Windows.Forms.RadioButton radioButton_16;
        private System.Windows.Forms.Button btn_ok;
    }
}