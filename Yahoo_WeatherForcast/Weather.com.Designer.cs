namespace Yahoo_WeatherForcast
{
    partial class Weather
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
            this.cbBoxCityName = new System.Windows.Forms.ComboBox();
            this.lbCityName = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btiGetWeatherInfo = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBoxCityName
            // 
            this.cbBoxCityName.FormattingEnabled = true;
            this.cbBoxCityName.Location = new System.Drawing.Point(81, 64);
            this.cbBoxCityName.Name = "cbBoxCityName";
            this.cbBoxCityName.Size = new System.Drawing.Size(121, 20);
            this.cbBoxCityName.TabIndex = 0;
            // 
            // lbCityName
            // 
            this.lbCityName.AutoSize = true;
            this.lbCityName.Location = new System.Drawing.Point(24, 67);
            this.lbCityName.Name = "lbCityName";
            this.lbCityName.Size = new System.Drawing.Size(29, 12);
            this.lbCityName.TabIndex = 1;
            this.lbCityName.Text = "城市";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(393, 158);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(26, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 357);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "天气预报";
            // 
            // btiGetWeatherInfo
            // 
            this.btiGetWeatherInfo.Location = new System.Drawing.Point(326, 64);
            this.btiGetWeatherInfo.Name = "btiGetWeatherInfo";
            this.btiGetWeatherInfo.Size = new System.Drawing.Size(75, 23);
            this.btiGetWeatherInfo.TabIndex = 4;
            this.btiGetWeatherInfo.Text = "查询天气情况";
            this.btiGetWeatherInfo.UseVisualStyleBackColor = true;
            this.btiGetWeatherInfo.Click += new System.EventHandler(this.btiGetWeatherInfo_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 222);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(393, 129);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Weather
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 532);
            this.Controls.Add(this.btiGetWeatherInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbCityName);
            this.Controls.Add(this.cbBoxCityName);
            this.Name = "Weather";
            this.Text = "Weather";
            this.Load += new System.EventHandler(this.Weather_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBoxCityName;
        private System.Windows.Forms.Label lbCityName;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btiGetWeatherInfo;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}