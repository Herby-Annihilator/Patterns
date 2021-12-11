using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users.UserData;

namespace SystemCore.Users
{
	public class User
	{
		public PersonalData PersonalData { get; protected set; }
		public string Login { get; protected set; }
		public string Password { get; set; }
	}
}
