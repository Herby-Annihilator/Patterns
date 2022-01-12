using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;

namespace DataLayer
{
	public class FileTestDataProvider : ITestDataProvider
	{
		public string FilePath { get; set; }

		public FileTestDataProvider(string filePath)
		{
			FilePath = filePath;
		}

		public string GetDescription(int testID)
		{
			return $"Описание теста {testID} из файла {FilePath}";
		}

		public int GetDuration(int testID)
		{
			return testID;
		}
	}
}
