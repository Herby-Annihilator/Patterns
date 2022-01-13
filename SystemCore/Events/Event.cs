using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Events
{
	public class Event<T>
	{
		protected List<IEventHandler<T>> eventHandlers;
		public virtual void AddHandler(IEventHandler<T> eventHandler)
		{
			if (!eventHandlers.Contains(eventHandler))
			{
				eventHandlers.Add(eventHandler);
			}
		}

		public Event()
		{
			eventHandlers = new List<IEventHandler<T>>();
		}

		public virtual void RemoveHandler(IEventHandler<T> eventHandler)
		{
			eventHandlers.Remove(eventHandler);
		}

		public virtual void Invoke(object sender, T eventArgs)
		{
			foreach (var item in eventHandlers)
			{
				item.Handle(sender, eventArgs);
			}
		}
	}
}
