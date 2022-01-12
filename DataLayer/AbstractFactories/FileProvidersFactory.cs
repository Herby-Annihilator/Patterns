using DataLayer.AbstractFactories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;

namespace DataLayer.AbstractFactories
{
	public class FileProvidersFactory : IProviderFactory
	{
		private string exersicesFile = "exersices.txt";
		private string testsFile = "tests.txt";
		public IExersiceDataProvider CreateExerciseDataProvider() => new FileExerciseDataProvider(exersicesFile);

		public ITestDataProvider CreateTestDataProvider() => new FileTestDataProvider(testsFile);
	}
}
