using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Users.UserData
{
	public class PersonalData
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public DateTime Birthday { get; set; }
		public Address Address { get; set; }

		public PersonalData(string firstName, string lastName, string patronymic, DateTime birthday, Address address)
		{
			FirstName = firstName;
			LastName = lastName;
			Patronymic = patronymic;
			Birthday = birthday;
			Address = address;
		}
	}
}
