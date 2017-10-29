namespace ChatClassroom
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.button1 = new System.Windows.Forms.Button();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.rtbChat = new System.Windows.Forms.RichTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.lbAboutChannel = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label16 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tHereNow = new System.Windows.Forms.Timer(this.components);
			this.tHours = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(461, 231);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 28);
			this.button1.TabIndex = 2;
			this.button1.Text = "Send Message";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbMessage
			// 
			this.tbMessage.Location = new System.Drawing.Point(3, 232);
			this.tbMessage.Multiline = true;
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(455, 28);
			this.tbMessage.TabIndex = 3;
			this.tbMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMessage_KeyPress);
			// 
			// rtbChat
			// 
			this.rtbChat.AcceptsTab = true;
			this.rtbChat.BackColor = System.Drawing.Color.White;
			this.rtbChat.BulletIndent = 2;
			this.rtbChat.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.rtbChat.Font = new System.Drawing.Font("Lucida Sans Typewriter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbChat.Location = new System.Drawing.Point(3, 6);
			this.rtbChat.Margin = new System.Windows.Forms.Padding(0);
			this.rtbChat.Name = "rtbChat";
			this.rtbChat.ReadOnly = true;
			this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.rtbChat.Size = new System.Drawing.Size(566, 220);
			this.rtbChat.TabIndex = 6;
			this.rtbChat.Text = "Waiting for user connection...";
			this.rtbChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbChat_MouseDown);
			this.rtbChat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rtbChat_MouseUp);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 295);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(581, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lbStatus
			// 
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(19, 17);
			this.lbStatus.Text = "    ";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(547, 17);
			this.toolStripStatusLabel1.Spring = true;
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(581, 295);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
			this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.tbMessage);
			this.tabPage1.Controls.Add(this.rtbChat);
			this.tabPage1.Controls.Add(this.listBox1);
			this.tabPage1.Controls.Add(this.lbAboutChannel);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(573, 269);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Chat";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(572, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "             ";
			// 
			// listBox1
			// 
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.Location = new System.Drawing.Point(575, 62);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(150, 164);
			this.listBox1.TabIndex = 8;
			this.listBox1.Tag = "";
			// 
			// lbAboutChannel
			// 
			this.lbAboutChannel.Location = new System.Drawing.Point(572, 6);
			this.lbAboutChannel.Name = "lbAboutChannel";
			this.lbAboutChannel.Size = new System.Drawing.Size(153, 40);
			this.lbAboutChannel.TabIndex = 7;
			this.lbAboutChannel.Text = "         ";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.pictureBox1);
			this.tabPage3.Controls.Add(this.linkLabel3);
			this.tabPage3.Controls.Add(this.linkLabel2);
			this.tabPage3.Controls.Add(this.linkLabel1);
			this.tabPage3.Controls.Add(this.label16);
			this.tabPage3.Controls.Add(this.label14);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.label19);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(573, 269);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "About";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(21, 51);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(157, 25);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel3
			// 
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Location = new System.Drawing.Point(64, 159);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(132, 13);
			this.linkLabel3.TabIndex = 10;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "qwerty124563@gmail.com";
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(64, 135);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(187, 13);
			this.linkLabel2.TabIndex = 11;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "http://steamcommunity.com/id/13dev";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(64, 109);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(130, 13);
			this.linkLabel1.TabIndex = 12;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://github.com/13dev";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(18, 159);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 13);
			this.label16.TabIndex = 3;
			this.label16.Text = "Email:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(18, 135);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 13);
			this.label14.TabIndex = 4;
			this.label14.Text = "Steam:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Github:";
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label19.Dock = System.Windows.Forms.DockStyle.Right;
			this.label19.Location = new System.Drawing.Point(283, 0);
			this.label19.Margin = new System.Windows.Forms.Padding(0);
			this.label19.Name = "label19";
			this.label19.Padding = new System.Windows.Forms.Padding(10);
			this.label19.Size = new System.Drawing.Size(290, 269);
			this.label19.TabIndex = 7;
			this.label19.Text = resources.GetString("label19.Text");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 8);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(1);
			this.label2.Size = new System.Drawing.Size(138, 15);
			this.label2.TabIndex = 8;
			this.label2.Text = "This program was made by:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tbOutput);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(573, 269);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Debug";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tbOutput
			// 
			this.tbOutput.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbOutput.Location = new System.Drawing.Point(3, 3);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ReadOnly = true;
			this.tbOutput.Size = new System.Drawing.Size(567, 198);
			this.tbOutput.TabIndex = 2;
			// 
			// tHereNow
			// 
			this.tHereNow.Interval = 10000;
			this.tHereNow.Tick += new System.EventHandler(this.tHereNow_Tick);
			// 
			// tHours
			// 
			this.tHours.Enabled = true;
			this.tHours.Interval = 1000;
			this.tHours.Tick += new System.EventHandler(this.tHours_Tick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(581, 317);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kappa System";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.RichTextBox rtbChat;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lbStatus;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label lbAboutChannel;
		private System.Windows.Forms.Timer tHereNow;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Timer tHours;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label2;
	}
}

