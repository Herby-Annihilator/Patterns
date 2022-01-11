using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;
using SystemCore.Users.UserData;

namespace Infrastructure.Services
{
	public class PersonalDataSenderCompressionDecorator : PersonalDataSenderDecorator
	{
		public PersonalDataSenderCompressionDecorator(IPersonalDataSender personalDataSender)
		{
			_dataSender = personalDataSender;
		}
		public override void SendData(PersonalData data)
		{
			CompressData(data);
			_dataSender.SendData(data);
		}

		private void CompressData(PersonalData data)
		{

		}
	}
}
