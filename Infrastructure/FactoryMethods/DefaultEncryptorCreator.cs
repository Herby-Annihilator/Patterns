using Infrastructure.FactoryMethods.Base;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;

namespace Infrastructure.FactoryMethods
{
	public class DefaultEncryptorCreator : EncryptorCreator<string, string>
	{
		public override IEncryptor<string, string> CreateEncryptor() => new DefaultEncryptor();
	}
}
