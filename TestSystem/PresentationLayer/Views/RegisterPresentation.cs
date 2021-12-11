using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;
using SystemCore.Services;
using SystemCore.Users.UserData;

namespace PresentationLayer.Views
{
	class RegisterPresentation : Presentation
	{
		AccountManager _accountManager;
		public RegisterPresentation(AccountManager accountManager, Presentator presentator)
		{
			_accountManager = accountManager;
			this.presentator = presentator;
		}
		public override bool StartPresentation()
		{
			string firstName, lastName, patronymic, userName, password;
			DateTime birthady;
			Address address;
			Console.Write("Ваше имя: ");
			firstName = Console.ReadLine();
			Console.Write("Ваша фамилия: ");
			lastName = Console.ReadLine();
			Console.Write("Ваше отчество: ");
			patronymic = Console.ReadLine();
			birthady = GetBirthday();
			address = GetAddress();
			Console.Write("Введите имя пользователя: ");
			userName = Console.ReadLine();
			Console.Write("Введите пароль: ");
			password = Console.ReadLine();
			_accountManager.CreateAccount(userName, password, new PersonalData(firstName, lastName, patronymic, birthady, address));
			presentator.ChangePresentation(presentator.PresentationRepository.HelloPresentation);
			return true;
		}

		private DateTime GetBirthday()
		{
			int day, mounth, year;
			string date;
			string[] buffer;
			do
			{
				Console.Write("Введите дату рождения по маске dd.MM.yyyy - ");
				date = Console.ReadLine();
				buffer = date.Split('.', StringSplitOptions.RemoveEmptyEntries);
			} while (!(int.TryParse(buffer[0], out day) 
				&& int.TryParse(buffer[1], out mounth) 
				&& int.TryParse(buffer[2], out year))
				);
			return new DateTime(year, mounth, day);
		}

		private Address GetAddress()
		{
			string countryName, cityName, streetName;
			int houseNumber;
			LocalityType localityType = LocalityType.City;
			Console.Write("Страна проживания: ");
			countryName = Console.ReadLine();
			bool validLocalityType = false;
			Console.WriteLine("Тип населенного пункта:");
			Console.WriteLine("1 - Большой город");
			Console.WriteLine("2 - Небольшой город");
			Console.WriteLine("3 - Деревня");
			do
			{
				Console.Write("Ваш выбор: ");
				var key = Console.ReadKey().Key;
				switch(key)
				{
					case ConsoleKey.D1:
						{
							localityType = LocalityType.City;
							validLocalityType = true;
							break;
						}
					case ConsoleKey.D2:
						{
							localityType = LocalityType.Town;
							validLocalityType = true;
							break;
						}
					case ConsoleKey.D3:
						{
							localityType = LocalityType.Village;
							validLocalityType = true;
							break;
						}
				}
			} while (!validLocalityType);
			Console.Write("\nНаименование населенного пункта: ");
			cityName = Console.ReadLine();
			Console.Write("Название улицы проживания: ");
			streetName = Console.ReadLine();
			do
			{
				Console.Write("Номер дома: ");
			} while (!int.TryParse(Console.ReadLine(), out houseNumber));
			return new Address(countryName, new Locality(localityType, cityName), streetName, houseNumber);
		}
	}
}
