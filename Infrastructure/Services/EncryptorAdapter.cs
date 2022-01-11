using Infrastructure.ExistingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;

namespace Infrastructure.Services
{
	public class EncryptorAdapter : IEncryptor<string, string>
	{
		private ExistingEncryptor _adaptableEncryptor;
		public EncryptorAdapter(ExistingEncryptor existingEncryptor)
		{
			_adaptableEncryptor = existingEncryptor;
		}
		public string DecryptData(string data)
		{
			int num = StrToInt(data);			
			return _adaptableEncryptor.GetTextFromHashCode(num);
		}

		public string EncryptData(string data)
		{
			int hashCode = _adaptableEncryptor.GetHashCodeFromData(data);
			return hashCode.ToString();
		}

		private int StrToInt(string str)
		{
			StringBuilder builder = new StringBuilder(str.Length);
			for (int i = str.Length - 1; i >= 0; i--)
			{
				builder.Append(str[i]);
			}
			string reverced = builder.ToString();
			int currentNum;
			int sum = 0;
			for (int i = 0; i < reverced.Length; i++)
			{
				currentNum = Convert.ToInt32(reverced[i]);
				sum += currentNum + (int)Math.Pow(10, i);
			}
			return sum;
		}
	}
}
