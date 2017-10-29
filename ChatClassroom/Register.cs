using AsanDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatClassroom
{
	public partial class Register : Form
	{
		private string username;
		private string password;
		private string c_password;
		private string user_ip;
		private DB db;

		public Register()
		{
			InitializeComponent();
			db = new DB();

			user_ip = (new System.Net.WebClient()).DownloadString("https://api.ipify.org");
			//user_ip = "192.168.1.1";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			username = tbUsername.Text;
			password = tbPassword.Text;
			c_password = tbC_password.Text;

			if (!Helpers.checkUsername(username)) return;

			//TODO: Change to ORM-..
			db.bind("username", username);
			string selectedUser = db.single("SELECT username FROM users WHERE username = @username");

			if (selectedUser == username)
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "A username already exists, please try again.", Properties.Resources.error);
				Thread.Sleep(1000);
				return;
			}

			if (!c_password.Equals(password))
			{
				
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "The both passwords do not match, please try again!", Properties.Resources.error);
				Thread.Sleep(1000);
				return;
			}

			string timePlusOne = DateTime.Now.AddMinutes(1.3).ToString();

			db.bind("wait_time", timePlusOne);
			db.bind("uid", Configuration.UID);
			db.query("DELETE FROM wait WHERE uid = @uid");
			db.bind("wait_time", timePlusOne);
			db.bind("uid", Configuration.UID);
			int nresult = db.nQuery("INSERT INTO wait (uid,wait_time) VALUES(@uid,@wait_time)");

			if (nresult < 1)
			{
				MessageBox.Show("Ocorreu um erro, por favor tente mais tarde.");
				return;
			}

			//Create User...
			User user = new User();
			user._username = username;
			user._password = Helpers.Encrypt(Properties.Settings.Default["key"].ToString(), password, true);
			user._ip = user_ip; // Get the ip !
			user.create();

			MessageBox.Show("Your registration has been sent, taking into account your data, the activation will take place!","Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);
			db.CloseConn();
			Close();

		}

		private void Register_Load(object sender, EventArgs e)
		{

		}
	}
}
