using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Iterators
{
	public interface IEnumerator<T>
	{
		void Reset();
		bool MoveNext();
		T GetCurrent();
	}
}
