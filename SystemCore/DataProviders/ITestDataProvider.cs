using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exersices;

namespace SystemCore.DataProviders
{
	public interface ITestDataProvider
	{
		string GetDescription(int testID);
		int GetDuration(int testID);
		//List<Exersice> GetExersices(int testID);
	}
}
