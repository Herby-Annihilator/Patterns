using SystemCore.DataProviders;

namespace DataLayer.AbstractFactories.Base
{
	public interface IProviderFactory
	{
		IExersiceDataProvider CreateExerciseDataProvider();
		ITestDataProvider CreateTestDataProvider();
	}
}
