﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Entities
{
	public interface IObserver
	{
		void ProcessEvent(ISubject sender);
	}
}