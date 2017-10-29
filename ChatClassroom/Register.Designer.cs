namespace ChatClassroom
{
	partial class Register
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbC_password = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Password:";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(78, 36);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '●';
			this.tbPassword.Size = new System.Drawing.Size(118, 20);
			this.tbPassword.TabIndex = 1;
			// 
			// tbUsername
			// 
			this.tbUsername.Location = new System.Drawing.Point(78, 10);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(341, 20);
			this.tbUsername.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(202, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Confirm password:";
			// 
			// tbC_password
			// 
			this.tbC_password.Location = new System.Drawing.Point(301, 36);
			this.tbC_password.Name = "tbC_password";
			this.tbC_password.PasswordChar = '●';
			this.tbC_password.Size = new System.Drawing.Size(118, 20);
			this.tbC_password.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(331, 63);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Send Request";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Location = new System.Drawing.Point(16, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(180, 26);
			this.label4.TabIndex = 3;
			this.label4.Text = "Created by 13 Developer ++";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Register
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::ChatClassroom.Properties.Resources._390ee120731934bf9d91de4f3ea67bbf;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(431, 98);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.tbC_password);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Register";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KAPPA - Register";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Register_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbC_password;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
	}
}