using DataLayer;
using Infrastructure.Services;
using PresentationLayer.Presentators;
using PresentationLayer.Presentators.Base;
using System;
using SystemCore.Services;
using SystemCore.Exersices;
using Infrastructure.ExistingServices;
using SystemCore.Users.UserData;
using SystemCore.Entities;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			TestComposite();
		}

		static void TestAdapter()
		{
			DefaultEncryptor defaultEncryptor = new DefaultEncryptor();
			ExistingEncryptor existingEncryptor = new ExistingEncryptor();
			EncryptorAdapter encryptorAdapter = new EncryptorAdapter(existingEncryptor);
			string test = "I am encryptable";
			Console.WriteLine(EncryptData(test, defaultEncryptor));
			Console.WriteLine(EncryptData(test, encryptorAdapter));
		}

		static string EncryptData(string data, IEncryptor<string, string> encryptor) => encryptor.EncryptData(data);

		static void TestDecorator()
		{
			PersonalData personalData = new PersonalData("firstName", "lastName", "patronymic", DateTime.Now,
				new Address("Russia", new Locality(LocalityType.Town, "Barnaul"), "No street", 15));
			IPersonalDataSender dataSender = new NetworkPersonalDataSender();
			dataSender = new PersonalDataSenderCompressionDecorator(dataSender);
			dataSender = new PersonalDataSenderEncryptorDecorator(dataSender);			
			dataSender.SendData(personalData);
		}

		static void TestComposite()
		{
			SystemCore.Tests.Test test = new SystemCore.Tests.Test("Экзамен", 100);
			for (int i = 0; i < 5; i++)
			{
				test.AddEntity(new Exersice() { Instruction = "Exersice", Wording = $" {i + 1}"});
				test.AddEntity(new SystemCore.Tests.Test($"test {i + 1}", i + 1));
			}
			TestIterator(test);
		}

		static void TestIterator(IDescribedEntity entity)
		{
			var iter = entity.GetEnumerator();
			while (iter.MoveNext())
			{
				Console.WriteLine(iter.GetCurrent().GetDescription());
			}
		}
	}
}
