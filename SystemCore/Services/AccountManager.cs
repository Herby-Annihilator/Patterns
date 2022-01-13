using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.DataProviders;
using SystemCore.Entities;
using SystemCore.Events;
using SystemCore.Users.UserData;

namespace SystemCore.Services
{
	public class AccountManager
	{
		private Event<string> _accountCreated;
		public Event<string> AccountCreated => _accountCreated ??= new Event<string>();
		protected void OnAccountCreated(string param) => AccountCreated?.Invoke(this, param);

		private Event<string> _userNameChanged;
		public Event<string> UserNameChanged => _userNameChanged ??= new Event<string>();
		protected void OnUserNameChanged(string param) => UserNameChanged?.Invoke(this, param);

		private Event<string> _passwordChanged;
		public Event<string> PasswordChanged => _passwordChanged ??= new Event<string>();
		protected void OnPasswordChanged(string param) => PasswordChanged?.Invoke(this, param);


		private IAccountDataManager _accountDataManager;
		public AccountManager(IAccountDataManager accountDataManager)
		{
			_accountDataManager = accountDataManager;
		}
		public Account CreateAccount(string userName, string password, PersonalData personalData)
		{
			int id = _accountDataManager.CreateAccount(userName, password, personalData);
			Account account = new Account(userName, password, id);
			OnAccountCreated($"Создан аккаунт: UserName '{userName}', Password '{password}'");
			return account;
		}

		public bool ChangeUserName(Account account, string userName)
		{
			if (_accountDataManager.ChangeUserName(account.UserName, userName))
			{
				OnUserNameChanged($"UserName изменен с '{account.UserName}' на '{userName}'");
				account.UserName = userName;				
				return true;
			}
			OnUserNameChanged($"Не удалось изменить UserName '{account.UserName}'");
			return false;
		}

		public bool ChangePassword(Account account, string password)
		{
			if (_accountDataManager.ChangeUserPassword(account.UserName, password))
			{
				OnPasswordChanged($"Password изменен с '{account.Password}' на '{password}'");
				account.Password = password;
				return true;
			}
			OnUserNameChanged($"Не удалось изменить Password '{account.Password}'");
			return false;
		}
	}
}
