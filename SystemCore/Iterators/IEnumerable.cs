﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Iterators
{
	public interface IEnumerable<T>
	{
		IEnumerator<T> GetEnumerator();
	}
}
