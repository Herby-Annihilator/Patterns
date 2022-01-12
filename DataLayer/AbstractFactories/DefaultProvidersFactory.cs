using DataLayer.AbstractFactories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;

namespace DataLayer.AbstractFactories
{
	public class DefaultProvidersFactory : IProviderFactory
	{
		public IExersiceDataProvider CreateExerciseDataProvider() => new DefaultExersiceDataProvider();

		public ITestDataProvider CreateTestDataProvider() => new DefaultTestDataProvider();
	}
}
