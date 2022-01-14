using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Events;
using SystemCore.Services;

namespace SystemCore.Accounts
{
	public class AdminAccount : Account
	{
		public AccountManager AccountManager { get; protected set; }
		private AccountUserNameChangedHandler _accountUserNameChangedHandler = new AccountUserNameChangedHandler();
		private AccountPasswordChangedHandler _accountPasswordChangedHandler = new AccountPasswordChangedHandler();
		private AccountCreatedHandler _accountCreatedHandler = new AccountCreatedHandler();
		public AdminAccount(AccountManager accountManager) : base("Admin", "admin", 0)
		{
			AccountManager = accountManager;
			AccountManager.AccountCreated.AddHandler(_accountCreatedHandler);
			AccountManager.PasswordChanged.AddHandler(_accountPasswordChangedHandler);
			AccountManager.UserNameChanged.AddHandler(_accountUserNameChangedHandler);
		}
		~AdminAccount() // страшновато
		{
			AccountManager.AccountCreated.RemoveHandler(_accountCreatedHandler);
			AccountManager.PasswordChanged.RemoveHandler(_accountPasswordChangedHandler);
			AccountManager.UserNameChanged.RemoveHandler(_accountUserNameChangedHandler);
			AccountManager = null;
			GC.Collect();
		}
	}

	public class AccountUserNameChangedHandler : IEventHandler<string>
	{
		public void Handle(object sender, string eventArgs)
		{
			Console.WriteLine($"Админский аккаун реагирует на событие. Аргументы события: {eventArgs}");
		}
	}

	public class AccountPasswordChangedHandler : IEventHandler<string>
	{
		public void Handle(object sender, string eventArgs)
		{
			Console.WriteLine($"Админский аккаун реагирует на событие. Аргументы события: {eventArgs}");
		}
	}

	public class AccountCreatedHandler : IEventHandler<string>
	{
		public void Handle(object sender, string eventArgs)
		{
			Console.WriteLine($"Админский аккаун реагирует на событие. Аргументы события: {eventArgs}");
		}
	}
}
