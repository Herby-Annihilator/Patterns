using DataLayer;
using Infrastructure.Services;
using PresentationLayer.Presentators;
using PresentationLayer.Presentators.Base;
using System;
using SystemCore.Services;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			DefaultAccountDataManager defaultAccountDataManager = new DefaultAccountDataManager();

			AccountManager accountManager = new AccountManager(defaultAccountDataManager);

			DefaultEncryptor defaultEncryptor = new DefaultEncryptor();

			DefaultLoginService defaultLoginService = new DefaultLoginService(defaultAccountDataManager, defaultEncryptor);

			DefaultExamGenerator defaultExamGenerator = new DefaultExamGenerator(new DefaultTestDataProvider(),
				new DefaultExersiceDataProvider());

			Presentator presentator = new ConsolePresentator(accountManager, defaultLoginService, defaultExamGenerator);
			presentator.StartPresentation();
		}
	}
}
