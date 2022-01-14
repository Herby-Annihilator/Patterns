using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SystemCore.Users.UserData
{
	public class Memento : IMemento
	{
		private PersonalData _originator;
		private string _firstName;
		private string _lastName;
		private string _patronymic;
		private DateTime _birthday;
		private Address _address;
		internal Memento(PersonalData originator, string firstName, string lastName, string patronymic, DateTime birthday, Address address)
		{
			_originator = originator;
			_firstName = (string)firstName.Clone();
			_lastName = (string)lastName.Clone();
			_patronymic = (string)patronymic.Clone();
			_birthday = birthday;
			_address = address.Clone();
		}

		public void Restore()
		{
			_originator.Restore(_firstName, _lastName, _patronymic, _birthday, _address);
		}
	}
}
