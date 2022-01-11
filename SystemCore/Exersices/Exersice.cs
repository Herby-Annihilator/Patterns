using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;
using SystemCore.Iterators;

namespace SystemCore.Exersices
{
	public class Exersice : IDescribedEntity
	{
		public string Instruction { get; set; }
		public string Wording { get; set; }
		public Skill TestableSkill { get; set; }

		public string GetDescription() => Instruction + Wording;

		public IEnumerator<IDescribedEntity> GetEnumerator() => new DescribedEntityEnumerator(this);
	}
}
