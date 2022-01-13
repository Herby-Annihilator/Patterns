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
		public string Instruction { get; set; } = "";
		public string Wording { get; set; } = "";
		public Skill TestableSkill { get; set; } = new Skill(0, "");

		public virtual IDescribedEntity Clone()
		{
			Exersice exersice = new Exersice();
			exersice.Instruction = (string)Instruction.Clone();
			exersice.Wording = (string)Wording.Clone();
			exersice.TestableSkill = new Skill(TestableSkill.ID, (string)TestableSkill.Description.Clone());
			return exersice;
		}

		public string GetDescription() => Instruction + Wording;

		public IEnumerator<IDescribedEntity> GetEnumerator() => new DescribedEntityEnumerator(this);
	}
}
