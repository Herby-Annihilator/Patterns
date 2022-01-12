using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;

namespace Infrastructure.FactoryMethods.Base
{
	public abstract class EncryptorCreator<TData, Tresult>
	{
		public abstract IEncryptor<TData, Tresult> CreateEncryptor();
	}
}
