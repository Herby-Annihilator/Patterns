using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.DataProviders
{
	public interface IUserDataProvider
	{
		bool WriteUserName(int userID, string userName);
		string GetUserName(int userID);
		bool WriteUserPassword(int userID, string password);

	}
}
