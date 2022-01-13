using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Entities
{
	public interface ISubject
	{
		void Notify();
		void AddSubscriber(IObserver subscriber);
		void RemoveSubscriber(IObserver subscriber);
	}
}
