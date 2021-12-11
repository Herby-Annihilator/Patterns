using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.Users.UserData;

namespace SystemCore.DataProviders
{
	public interface IAccountDataManager
	{
		bool ChangeUserName(string oldUserName, string userName);
		bool ChangeUserPassword(string userName, string password);
		int CreateAccount(string userName, string password, PersonalData personalData);
		Account GetAccount(string userName, string password);
		int GetFreeAccountID();
	}
}
