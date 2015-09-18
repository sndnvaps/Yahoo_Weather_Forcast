namespace Yahoo_WeatherForcast
{
    partial class Etouch
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
            this.btnSendReq = new System.Windows.Forms.Button();
            this.txtReqInput = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnSendReq
            // 
            this.btnSendReq.Location = new System.Drawing.Point(370, 70);
            this.btnSendReq.Name = "btnSendReq";
            this.btnSendReq.Size = new System.Drawing.Size(75, 23);
            this.btnSendReq.TabIndex = 0;
            this.btnSendReq.Text = "发送请求";
            this.btnSendReq.UseVisualStyleBackColor = true;
            this.btnSendReq.Click += new System.EventHandler(this.btnSendReq_Click);
            // 
            // txtReqInput
            // 
            this.txtReqInput.Location = new System.Drawing.Point(69, 39);
            this.txtReqInput.Name = "txtReqInput";
            this.txtReqInput.Size = new System.Drawing.Size(376, 21);
            this.txtReqInput.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(57, 141);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(388, 263);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Etouch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 491);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtReqInput);
            this.Controls.Add(this.btnSendReq);
            this.Name = "Etouch";
            this.Text = "Etouch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendReq;
        private System.Windows.Forms.TextBox txtReqInput;
        private System.Windows.Forms.ListView listView1;
    }
}