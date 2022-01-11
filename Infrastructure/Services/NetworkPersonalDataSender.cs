using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;
using SystemCore.Users.UserData;

namespace Infrastructure.Services
{
	public class NetworkPersonalDataSender : IPersonalDataSender
	{
		public void SendData(PersonalData data)
		{
			Console.WriteLine("Данные отправлены. Нажмите любую клавишу, чтобы продолжить");
			Console.ReadKey(true);
		}
	}
}
