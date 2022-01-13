using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SystemCore.Exersices
{
	public class ShortAnswerExersice : Exersice
	{
		public string RequairedAnswer { get; set; } = "";
		public string RecievedAnswer { get; set; } = "";

		public override IDescribedEntity Clone()
		{
			ShortAnswerExersice exersice = new ShortAnswerExersice();
			exersice.Instruction = (string)Instruction.Clone();
			exersice.Wording = (string)Wording.Clone();
			exersice.TestableSkill = new Skill(TestableSkill.ID, (string)TestableSkill.Description.Clone());

			exersice.RecievedAnswer = (string)RecievedAnswer.Clone();
			exersice.RequairedAnswer = (string)RequairedAnswer.Clone();
			return exersice;
		}
	}
}
