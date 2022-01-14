using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SystemCore.Users.UserData
{
	public class PersonalData : IOriginator
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Patronymic { get; private set; }
		public DateTime Birthday { get; private set; }
		public Address Address { get; set; }

		public PersonalData(string firstName, string lastName, string patronymic, DateTime birthday, Address address)
		{
			FirstName = firstName;
			LastName = lastName;
			Patronymic = patronymic;
			Birthday = birthday;
			Address = address;
		}

		public void Restore(string firstName, string lastName, string patronymic, DateTime birthday, Address address)
		{
			FirstName = firstName;
			LastName = lastName;
			Patronymic = patronymic;
			Birthday = birthday;
			Address = address;
		}

		public IMemento GetMemento()
		{
			return new Memento(this, FirstName, LastName, Patronymic, Birthday, Address);
		}
	}
}
