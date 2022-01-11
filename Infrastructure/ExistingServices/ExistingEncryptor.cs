using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExistingServices
{
	public class ExistingEncryptor
	{
		public int GetHashCodeFromData(string data) => data.GetHashCode();

		public string GetTextFromHashCode(int code) => code.ToString();
	}
}
