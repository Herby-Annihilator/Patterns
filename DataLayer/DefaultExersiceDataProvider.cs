using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;
using SystemCore.Exersices;

namespace DataLayer
{
	public class DefaultExersiceDataProvider : IExersiceDataProvider
	{
		private List<MultipleChoiceExersice> _exersices;
		public DefaultExersiceDataProvider()
		{
			_exersices = new List<MultipleChoiceExersice>();
			MultipleChoiceExersice exersice;
			for (int i = 0; i < 10; i++)
			{
				exersice = new MultipleChoiceExersice();
				exersice.Instruction = $"Инструкция к заданию c id = {i}";
				exersice.Wording = $"Формулировка задания с id = {i}";
				exersice.TestableSkill = new Skill(i, $"Skill {i}");
				exersice.Variants = new List<string>();
				for (int j = 0; j < 3; j++)
				{
					exersice.Variants.Add(i.ToString());
				}
				exersice.RequairedAnswer = "0";
				_exersices.Add(exersice);
			}
		}
		public string GetInstruction(int exersiceID) => _exersices[exersiceID].Instruction;

		public string GetRequiredAnswer(int exersiceID) => _exersices[exersiceID].RequairedAnswer;

		public Skill GetTestableSkill(int exersiceID) => _exersices[exersiceID].TestableSkill;

		public List<string> GetVariants(int exersiceID) => _exersices[exersiceID].Variants;

		public string GetWording(int exersiceID) => _exersices[exersiceID].Wording;
	}
}
