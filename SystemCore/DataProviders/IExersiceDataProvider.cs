using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exersices;

namespace SystemCore.DataProviders
{
	public interface IExersiceDataProvider
	{
		string GetInstruction(int exersiceID);
		string GetWording(int exersiceID);
		Skill GetTestableSkill(int exersiceID);
		string GetRequiredAnswer(int exersiceID);
		List<string> GetVariants(int exersiceID);
	}
}
