using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;

namespace Infrastructure.Services
{
	public class DefaultEncryptor : IEncryptor<string, string>
	{
		public string DecryptData(string data) => data;

		public string EncryptData(string data) => data;
	}
}
