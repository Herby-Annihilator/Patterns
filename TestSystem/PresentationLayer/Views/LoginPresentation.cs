using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.Services;

namespace PresentationLayer.Views
{
	class LoginPresentation : Presentation
	{
		ILoginService _loginService;
		Account _account;
		public LoginPresentation(ILoginService loginService, Presentator presentator)
		{
			_loginService = loginService;
			this.presentator = presentator;
		}
		public override bool StartPresentation()
		{
			string userName, password;
			Console.Clear();
			Console.Write("Логин: ");
			userName = Console.ReadLine();
			Console.Write("Пароль: ");
			password = Console.ReadLine();
			_account = _loginService.LoginUser(userName, password);
			if (_account == null)
			{
				Console.WriteLine("Пользователя не существует. Вы можете выйти, повторить попытку входа, либо зарегистрироваться.");
				Console.WriteLine("1 - зарегистрироваться");
				Console.WriteLine("2 - повторить попытку");
				Console.WriteLine("ESC - выйти");
				bool validAnswer = false;
				do
				{
					var key = Console.ReadKey(true).Key;
					switch (key)
					{
						case ConsoleKey.D1:
							{
								presentator.ChangePresentation(presentator.PresentationRepository.RegisterPresentation);
								validAnswer = true;
								break;
							}
						case ConsoleKey.D2:
							{
								presentator.ChangePresentation(presentator.PresentationRepository.LoginPresentation);
								validAnswer = true;
								break;
							}
						case ConsoleKey.Escape:
							{
								presentator.ChangePresentation(presentator.PresentationRepository.HelloPresentation);
								validAnswer = true;
								break;
							}
					}
				} while (!validAnswer);				
			}
			else
			{
				presentator.ChangePresentation(presentator.PresentationRepository.MainPresentation);
			}
			return true;
		}
	}
}
