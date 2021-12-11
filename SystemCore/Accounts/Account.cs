using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Accounts
{
	public class Account
	{
		public string UserName { get; internal set; }
		public string Password { get; internal set; }
		public int ID { get; internal set; }

		public Account(string userName, string password, int iD)
		{
			UserName = userName;
			Password = password;
			ID = iD;
		}
	}
}
