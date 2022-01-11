using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;
using SystemCore.Users.UserData;

namespace Infrastructure.Services
{
	public abstract class PersonalDataSenderDecorator : IPersonalDataSender
	{
		protected IPersonalDataSender _dataSender;
		public abstract void SendData(PersonalData data);
	}
}
