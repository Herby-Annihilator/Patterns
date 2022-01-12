using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Iterators;

namespace SystemCore.Entities
{
	public interface IDescribedEntity : IEnumerable<IDescribedEntity>, ICloneable<IDescribedEntity>
	{
		string GetDescription();
	}
}
