using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.DataProviders;
using SystemCore.Users.UserData;

namespace SystemCore.Services
{
	public class AccountManager
	{
		private IAccountDataManager _accountDataManager;
		public AccountManager(IAccountDataManager accountDataManager)
		{
			_accountDataManager = accountDataManager;
		}
		public Account CreateAccount(string userName, string password, PersonalData personalData)
		{
			int id = _accountDataManager.CreateAccount(userName, password, personalData);
			Account account = new Account(userName, password, id);
			return account;
		}

		public bool ChangeUserName(Account account, string userName)
		{
			if (_accountDataManager.ChangeUserName(account.UserName, userName))
			{
				account.UserName = userName;
				return true;
			}
			return false;
		}

		public bool ChangePassword(Account account, string password)
		{
			if (_accountDataManager.ChangeUserPassword(account.UserName, password))
			{
				account.Password = password;
				return true;
			}
			return false;
		}
	}
}
