using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;
using SystemCore.Users.UserData;

namespace Infrastructure.Services
{
	public class PersonalDataSenderEncryptorDecorator : PersonalDataSenderDecorator
	{
		public PersonalDataSenderEncryptorDecorator(IPersonalDataSender personalDataSender)
		{
			_dataSender = personalDataSender;
		}
		public override void SendData(PersonalData data)
		{
			EncryptData(data);
			_dataSender.SendData(data);
		}

		public void EncryptData(PersonalData data)
		{

		}
	}
}
