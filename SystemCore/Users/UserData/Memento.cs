using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SystemCore.Users.UserData
{
	internal class Memento : IMemento
	{
		internal string FirstName { get; private set; }
		internal string LastName { get; private set; }
		internal string Patronymic { get; private set; }
		internal DateTime Birthday { get; private set; }
		internal Address Address { get; private set; }
		internal Memento(string firstName, string lastName, string patronymic, DateTime birthday, Address address)
		{
			FirstName = (string)firstName.Clone();
			LastName = (string)lastName.Clone();
			Patronymic = (string)patronymic.Clone();
			Birthday = birthday;
			Address = address.Clone();
		}
	}
}
