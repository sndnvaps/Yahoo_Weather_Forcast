namespace Yahoo_WeatherForcast
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSentRequest = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEtouch = new System.Windows.Forms.Button();
            this.btnWeather_com = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSentRequest
            // 
            this.btnSentRequest.Location = new System.Drawing.Point(503, 117);
            this.btnSentRequest.Name = "btnSentRequest";
            this.btnSentRequest.Size = new System.Drawing.Size(75, 23);
            this.btnSentRequest.TabIndex = 0;
            this.btnSentRequest.Text = "发送请求";
            this.btnSentRequest.UseVisualStyleBackColor = true;
            this.btnSentRequest.Click += new System.EventHandler(this.btnSentRequest_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(107, 90);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(486, 21);
            this.txtRequest.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView2);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(25, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 280);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取到的数据";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(17, 178);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(504, 83);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(18, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(504, 143);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Requeset URL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 82);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnEtouch
            // 
            this.btnEtouch.Location = new System.Drawing.Point(12, 500);
            this.btnEtouch.Name = "btnEtouch";
            this.btnEtouch.Size = new System.Drawing.Size(100, 23);
            this.btnEtouch.TabIndex = 7;
            this.btnEtouch.Text = "万年历天气预报";
            this.btnEtouch.UseVisualStyleBackColor = true;
            this.btnEtouch.Click += new System.EventHandler(this.btnEtouch_Click);
            // 
            // btnWeather_com
            // 
            this.btnWeather_com.Location = new System.Drawing.Point(12, 529);
            this.btnWeather_com.Name = "btnWeather_com";
            this.btnWeather_com.Size = new System.Drawing.Size(100, 23);
            this.btnWeather_com.TabIndex = 8;
            this.btnWeather_com.Text = "中国气象网预报";
            this.btnWeather_com.UseVisualStyleBackColor = true;
            this.btnWeather_com.Click += new System.EventHandler(this.btnWeather_com_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 582);
            this.Controls.Add(this.btnWeather_com);
            this.Controls.Add(this.btnEtouch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.btnSentRequest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSentRequest;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEtouch;
        private System.Windows.Forms.Button btnWeather_com;
    }
}

