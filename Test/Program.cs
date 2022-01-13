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


namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			TestFactoryMethod();
		}

		static void TestFactoryMethod()
		{
			EncryptorCreator<string, string> encryptorCreator = new DefaultEncryptorCreator();
			UseEncryptorCreator(encryptorCreator);

			encryptorCreator = new AdapterEncryptorCreator();
			UseEncryptorCreator(encryptorCreator);
		}

		static void UseEncryptorCreator(EncryptorCreator<string, string> encryptorCreator)
		{
			string toEncrypt = "I am encryptable";
			IEncryptor<string, string> encryptor = encryptorCreator.CreateEncryptor();
			Console.WriteLine(encryptor.EncryptData(toEncrypt));
		}

		static void TestAbstractFactory()
		{
			IProviderFactory factory;

			factory = new DefaultProvidersFactory();
			DescribeFactoriesProducts(factory);

			factory = new FileProvidersFactory();
			DescribeFactoriesProducts(factory);
		}
		static void DescribeFactoriesProducts(IProviderFactory factory)
		{
			IExersiceDataProvider exersiceDataProvider = factory.CreateExerciseDataProvider();
			ITestDataProvider testDataProvider = factory.CreateTestDataProvider();

			Console.WriteLine($"Описание задания: {exersiceDataProvider.GetInstruction(0)}, {exersiceDataProvider.GetWording(0)}");
			Console.WriteLine($"Описание теста: {testDataProvider.GetDescription(0)}, {testDataProvider.GetDuration(0)}");
		}

		static void TestSingleton()
		{
			IAccountDataManager dataManager = new DefaultAccountDataManager();
			AccountManager manager = new AccountManager(dataManager);
			IEncryptor<string, string> encryptor = new DefaultEncryptor();
			ILoginService loginService = new DefaultLoginService(dataManager, encryptor);
			IExamGenerator examGenerator = new DefaultExamGenerator(new DefaultTestDataProvider(), new DefaultExersiceDataProvider());

			Presentator presentator_1 = ConsolePresentator.Init(manager, loginService, examGenerator);

			Presentator presentatorClone = ConsolePresentator.Init(manager, loginService, examGenerator);

			if (ReferenceEquals(presentator_1, presentatorClone))
			{
				Console.WriteLine("presentator_1 это тот же объект, что и presentatorClone");
			}
			else
			{
				Console.WriteLine("Ссылки указывают на разных презентаторов");
			}
		}

		static void TestPrototype()
		{
			IExamGenerator examGenerator = new DefaultExamGenerator(new DefaultTestDataProvider(), new DefaultExersiceDataProvider());

			SystemCore.Tests.Test examPrototype = (SystemCore.Tests.Test)examGenerator.GenerateExam();

			IDescribedEntity exam = new SystemCore.Tests.Test("Экзамен 2 - создан вручную", 100);
			for (int i = 0; i < 3; i++)
			{
				((SystemCore.Tests.Test)exam).AddEntity(new Exersice() { Instruction = $"Ex {i + 1} ", Wording = "Hello" });
			}

			IDescribedEntity exam_2 = examPrototype.Clone();

			IDescribedEntity exam_3 = exam.Clone();

			Console.WriteLine("exam и examPrototype");
			Console.WriteLine(exam.GetDescription());
			Console.WriteLine(examPrototype.GetDescription());

			Console.WriteLine("\r\n\r\nexam_2 и examPrototype");
			Console.WriteLine(exam_2.GetDescription());
			Console.WriteLine(examPrototype.GetDescription());

			Console.WriteLine("\r\n\r\nexam_3 и exam");
			Console.WriteLine(exam_3.GetDescription());
			Console.WriteLine(exam.GetDescription());
		}
	}
}
