using AsanDB;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ChatClassroom
{
	public partial class Login : Form
	{
		private string username;
		private string password;
		private DB db;
		private DataTable _result;

		public Login()
		{
			InitializeComponent();

			var ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.Text += $"(v{ver})";

			db = new DB();

		}

		private void button1_Click(object sender, EventArgs e)
		{


			username = textBox1.Text;
			password = textBox2.Text;

			if (!Helpers.checkUsername(username)) return;

			db.bind("username", username);
			_result = db.query("SELECT * FROM users WHERE username = @username");


			if (_result.Rows.Count == 0)
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "The password or username is incorrect, please try again!", Properties.Resources.error);
				Thread.Sleep(2000);
				return;
			}


			//select password
			db.bind("username", username);
			string result = db.single("SELECT password FROM users WHERE username = @username");

			//hash input and compare to db..
			if (Helpers.Encrypt(Configuration.KEY, password, true) != result)
			{
				//give the same error...
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "The password or username is incorrect, please try again!", Properties.Resources.error);
				Thread.Sleep(2000);
				//MessageBox.Show("The password or username is incorrect, please try again!", "Ups...Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			if ((int)_result.Rows[0]["status"] == 0)
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Your account has not yet been approved, please contact the administrator.", Properties.Resources.error);
				//MessageBox.Show("Your account has not yet been approved, please contact the administrator.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				Thread.Sleep(2000);
				return;
			}

			Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Connecting, please wait...", Properties.Resources.info, 5000);
			Thread.Sleep(1000);
			//username exists and password is correct!
			//Open Main...
			Main form = new Main();
			form.setUsername(username);
			form.Show();
			this.Hide();
			db.CloseConn();

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			db.bind("uid", Configuration.UID);
			string result = db.single("SELECT wait_time FROM wait WHERE uid = @uid");

			if (!String.IsNullOrEmpty(result))
			{
				var wait_time = Helpers.TimeSpanToReadString(DateTime.Parse(result).Subtract(DateTime.Now));

				//TODO: protect thiss
				if (DateTime.Now <= DateTime.Parse(result))
				{
					Helpers.Notification(Configuration.NOTIFICATION_TITLE, $"Please try to wait { wait_time}, to make a new registration.", Properties.Resources.error);
					//MessageBox.Show($"Please try to wait { wait_time}, to make a new registration.", "Ups Momento de espera...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Thread.Sleep(500);
					return;
				}
			}

			Register form = new Register();
			form.ShowDialog();

		}

	}
}
