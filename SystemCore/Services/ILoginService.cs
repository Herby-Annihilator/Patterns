using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.Users;

namespace SystemCore.Services
{
	public interface ILoginService
	{
		Account LoginUser(string userName, string password);
	}
}
