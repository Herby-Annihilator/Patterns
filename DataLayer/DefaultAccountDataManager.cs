using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Accounts;
using SystemCore.DataProviders;
using SystemCore.Users.UserData;

namespace DataLayer
{
	public class DefaultAccountDataManager : IAccountDataManager
	{
		private List<DataBaseAccount> dataBase;
		private int _freeID = 0;
		public DefaultAccountDataManager()
		{
			dataBase = new List<DataBaseAccount>();
			for (int i = 0; i < 5; i++)
			{
				dataBase.Add(new DataBaseAccount(i, $"user{i}", "123"));
				_freeID++;
			}
		}
		public bool ChangeUserName(string oldUserName, string userName)
		{
			for (int i = 0; i < dataBase.Count; i++)
			{
				if (dataBase[i].UserName == oldUserName)
				{
					dataBase[i].UserName = userName;
					return true;
				}
			}
			return false;
		}

		public bool ChangeUserPassword(string userName, string password)
		{
			for (int i = 0; i < dataBase.Count; i++)
			{
				if (dataBase[i].UserName == userName)
				{
					dataBase[i].Password = password;
					return true;
				}
			}
			return false;
		}

		public int CreateAccount(string userName, string password, PersonalData personalData)
		{
			int id = GetFreeAccountID();
			dataBase.Add(new DataBaseAccount(id, userName, password));
			_freeID++;
			return id;
		}

		public Account GetAccount(string userName, string password)
		{
			for (int i = 0; i < dataBase.Count; i++)
			{
				if (dataBase[i].UserName == userName && dataBase[i].Password == password)
				{
					return new Account(userName, password, dataBase[i].ID);
				}
			}
			return null;
		}

		public int GetFreeAccountID() => _freeID;
	}

	internal class DataBaseAccount
	{
		internal int ID { get; set; }
		internal string UserName { get; set; }
		internal string Password { get; set; }

		public DataBaseAccount(int id, string userName, string password)
		{
			ID = id;
			UserName = userName;
			Password = password;
		}
	}
}
