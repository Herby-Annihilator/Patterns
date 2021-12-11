using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;

namespace DataLayer
{
	public class DefaultTestDataProvider : ITestDataProvider
	{
		public string GetDescription(int testID) => "Тест из DefaultTestDataProvider - заглушка";

		public int GetDuration(int testID) => 100;
	}
}
