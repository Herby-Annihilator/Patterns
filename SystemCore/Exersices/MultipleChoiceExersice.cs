using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SystemCore.Exersices
{
	public class MultipleChoiceExersice : ShortAnswerExersice
	{
		public List<string> Variants { get; set; } = new List<string>();

		public override IDescribedEntity Clone()
		{
			MultipleChoiceExersice exersice = new MultipleChoiceExersice();
			exersice.Instruction = (string)Instruction.Clone();
			exersice.Wording = (string)Wording.Clone();
			exersice.TestableSkill = new Skill(TestableSkill.ID, (string)TestableSkill.Description.Clone());

			exersice.RecievedAnswer = (string)RecievedAnswer.Clone();
			exersice.RequairedAnswer = (string)RequairedAnswer.Clone();

			exersice.Variants = new List<string>();
			foreach (var item in Variants)
			{
				exersice.Variants.Add((string)item.Clone());
			}
			return exersice;
		}
	}
}
