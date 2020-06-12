namespace Chat_ClientServer
{
    partial class Server
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.rb_Mess = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMess = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNumClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.list_client = new System.Windows.Forms.CheckedListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_stt = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.tbIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(26, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Information";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(101, 76);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(203, 22);
            this.tbPort.TabIndex = 3;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(101, 37);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(203, 22);
            this.tbIP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(387, 71);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 38);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // rb_Mess
            // 
            this.rb_Mess.Location = new System.Drawing.Point(26, 174);
            this.rb_Mess.Name = "rb_Mess";
            this.rb_Mess.Size = new System.Drawing.Size(452, 309);
            this.rb_Mess.TabIndex = 2;
            this.rb_Mess.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Message";
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(26, 535);
            this.tbMess.Multiline = true;
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(633, 38);
            this.tbMess.TabIndex = 4;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(691, 535);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 38);
            this.btSend.TabIndex = 5;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số client kết nối:";
            // 
            // tbNumClient
            // 
            this.tbNumClient.Location = new System.Drawing.Point(497, 87);
            this.tbNumClient.Name = "tbNumClient";
            this.tbNumClient.Size = new System.Drawing.Size(269, 22);
            this.tbNumClient.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 129);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "List Client:";
            // 
            // list_client
            // 
            this.list_client.FormattingEnabled = true;
            this.list_client.Location = new System.Drawing.Point(497, 173);
            this.list_client.Name = "list_client";
            this.list_client.Size = new System.Drawing.Size(283, 310);
            this.list_client.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_stt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(792, 25);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_stt
            // 
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(151, 20);
            this.lb_stt.Text = "toolStripStatusLabel1";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 614);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.list_client);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNumClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbMess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rb_Mess);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Server";
            this.Text = "Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.RichTextBox rb_Mess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMess;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNumClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox list_client;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lb_stt;
    }
}

