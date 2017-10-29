using AsanDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClassroom
{
	class User : ORM
	{
		private int id;
		private string username;
		private string password;
		private string ip;
		private string last_login;

		public int _id
		{
			get { return id; }
			set { id = value; }
		}

		public string _username
		{
			get { return username; }
			set { username = value; }
		}

		public string _password
		{
			get { return password; }
			set { password = value; }
		}

		public string _ip
		{
			get { return ip; }
			set { ip = value; }
		}

		public string _last_login
		{
			get { return last_login; }
			set { last_login = value; }
		}

		public User()
		{
			table_ = "users";
			pk_ = "id";
		}
	}
}
