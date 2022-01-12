using Infrastructure.ExistingServices;
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
	public class AdapterEncryptorCreator : EncryptorCreator<string, string>
	{
		private ExistingEncryptor _existingEncryptor;
		public override IEncryptor<string, string> CreateEncryptor() => 
			new EncryptorAdapter(_existingEncryptor ??= new ExistingEncryptor());
	}
}
