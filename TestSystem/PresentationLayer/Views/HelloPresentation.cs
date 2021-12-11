using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
	public class HelloPresentation : Presentation
	{
		public HelloPresentation(Presentator presentator) => this.presentator = presentator;
		public override bool StartPresentation()
		{
			UserAction action;
			action = ShowStart();
			switch (action)
			{
				case UserAction.Login:
					{
						presentator.ChangePresentation(presentator.PresentationRepository.LoginPresentation);
						break;
					}
				case UserAction.Register:
					{
						presentator.ChangePresentation(presentator.PresentationRepository.RegisterPresentation);
						break;
					}
				case UserAction.Exit:
					return false;
			}
			return true;
		}

		private UserAction ShowStart()
		{
			bool exit = false;
			UserAction action = UserAction.Exit;
			do
			{
				Console.Clear();
				Console.WriteLine("1 - залогиниться");
				Console.WriteLine("2 - зарегистрироваться");
				Console.WriteLine("ESC - Выйти");
				Console.WriteLine("Ваш выбор: ");
				var key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.D1:
						{
							action = UserAction.Login;
							exit = true;
							break;
						}
					case ConsoleKey.D2:
						{
							action = UserAction.Register;
							exit = true;
							break;
						}
					case ConsoleKey.Escape:
						{
							action = UserAction.Exit;
							exit = true;
							break;
						}
				}
			} while (!exit);
			return action;
		}
	}
	public enum UserAction
	{
		Login,
		Register,
		PassExam,
		// actions
		Exit
	}
}
