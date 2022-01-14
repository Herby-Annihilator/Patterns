using DataLayer;
using DataLayer.AbstractFactories.Base;
using DataLayer.AbstractFactories;

using PresentationLayer.Presentators;
using PresentationLayer.Presentators.Base;

using System;

using SystemCore.Services;
using SystemCore.Exersices;
using SystemCore.Users.UserData;
using SystemCore.Entities;
using SystemCore.DataProviders;

using Infrastructure.Services;
using Infrastructure.ExistingServices;
using Infrastructure.FactoryMethods.Base;
using Infrastructure.FactoryMethods;
using SystemCore.Accounts;
using SystemCore.Events;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			TestObserver();
			//ReactOnEvent();
		}

		static void TestState()
		{
			DefaultAccountDataManager defaultAccountDataManager = new DefaultAccountDataManager();

			AccountManager accountManager = new AccountManager(defaultAccountDataManager);

			DefaultEncryptor defaultEncryptor = new DefaultEncryptor();

			DefaultLoginService defaultLoginService = new DefaultLoginService(defaultAccountDataManager, defaultEncryptor);

			DefaultExamGenerator defaultExamGenerator = new DefaultExamGenerator(new DefaultTestDataProvider(),
				new DefaultExersiceDataProvider());

			Presentator presentator = ConsolePresentator.Init(accountManager, defaultLoginService, defaultExamGenerator);
			presentator.StartPresentation();
		}

		static void TestMemento()
		{
			PersonalData originator = new PersonalData(
				"firstName",
				"lastName",
				"patronymic",
				DateTime.Now,
				new Address("Rissia", new Locality(LocalityType.Town, "Barnaul"), "No street", 15)
				);

			Console.WriteLine(originator.Address.StreetName);

			IMemento memento = originator.GetMemento();
			originator.Address.StreetName = "Pr. Lenina";

			Console.WriteLine(originator.Address.StreetName);

			originator.Restore(memento);
			Console.WriteLine(originator.Address.StreetName);
		}


		static void TestObserver()
		{
			DefaultAccountDataManager defaultAccountDataManager = new DefaultAccountDataManager();

			AccountManager accountManager = new AccountManager(defaultAccountDataManager);

			AdminAccount adminAccount = new AdminAccount(accountManager);
			PasswordChangedHandler passwordChangedHandler = new PasswordChangedHandler();
			accountManager.PasswordChanged.AddHandler(passwordChangedHandler);

			PersonalData data = new PersonalData(
				"firstName",
				"lastName",
				"patronymic",
				DateTime.Now,
				new Address("Rissia", new Locality(LocalityType.Town, "Barnaul"), "No street", 15)
				);

			Account testAcc = accountManager.CreateAccount("user_1", "123", data);
			accountManager.ChangePassword(testAcc, "321");
			accountManager.ChangeUserName(testAcc, "10_user");
		}

		static void ReactOnEvent()
		{
			DefaultAccountDataManager defaultAccountDataManager = new DefaultAccountDataManager();
			AccountManager accountManager = new AccountManager(defaultAccountDataManager);

			PasswordChangedHandler passwordChangedHandler = new PasswordChangedHandler();
			accountManager.PasswordChanged.AddHandler(passwordChangedHandler);

			PersonalData data = new PersonalData(
				"firstName",
				"lastName",
				"patronymic",
				DateTime.Now,
				new Address("Rissia", new Locality(LocalityType.Town, "Barnaul"), "No street", 15)
				);

			Account testAcc = accountManager.CreateAccount("user_1", "123", data);
			accountManager.ChangePassword(testAcc, "10101010");
		}

		class PasswordChangedHandler : IEventHandler<string>
		{
			void IEventHandler<string>.Handle(object sender, string eventArgs)
			{
				Console.WriteLine($"Класс Program реагирует на событие. Аргументы события: {eventArgs}");
			}
		}
	}
}
