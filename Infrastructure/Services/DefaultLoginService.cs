using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.DataProviders;
using SystemCore.Services;

namespace Infrastructure.Services
{
	public class DefaultLoginService : ILoginService
	{
		protected IAccountDataManager _dataManager;
		protected IEncryptor<string, string> _encryptor;
		public DefaultLoginService(IAccountDataManager dataManager, IEncryptor<string, string> encryptor)
		{
			_dataManager = dataManager;
			_encryptor = encryptor;
		}
		public Account LoginUser(string userName, string password) => 
			_dataManager.GetAccount(userName, _encryptor.EncryptData(password));
	}
}
