﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Events
{
	public interface IEventHandler<T>
	{
		void Handle(object sender, T eventArgs);
	}
}
