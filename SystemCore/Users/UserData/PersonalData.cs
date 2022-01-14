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

		public IMemento GetMemento()
		{
			return new Memento(FirstName, LastName, Patronymic, Birthday, Address);
		}

		public void Restore(IMemento memento)
		{
			Memento mem = memento as Memento;
			if (mem == null)
				throw new ArgumentException(nameof(memento));
			FirstName = mem.FirstName;
			LastName = mem.LastName;
			Patronymic = mem.Patronymic;
			Birthday = mem.Birthday;
			Address = mem.Address;
		}
	}
}
