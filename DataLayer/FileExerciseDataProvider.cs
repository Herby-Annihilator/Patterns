using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;
using SystemCore.Exersices;

namespace DataLayer
{
	public class FileExerciseDataProvider : IExersiceDataProvider
	{
		public string FilePath { get; set; }
		public FileExerciseDataProvider(string path)
		{
			FilePath = path;
		}
		public string GetInstruction(int exersiceID)
		{
			return $"Инструкция к заданию {exersiceID} из файла {FilePath}";
		}

		public string GetRequiredAnswer(int exersiceID)
		{
			return $"Требуемый ответ к заданию {exersiceID} из файла {FilePath}";
		}

		public Skill GetTestableSkill(int exersiceID)
		{
			return new Skill(exersiceID, $"Описание скилла задания {exersiceID} из файла {FilePath}");
		}

		public List<string> GetVariants(int exersiceID)
		{
			List<string> result = new List<string>();
			for (int i = 0; i < exersiceID + 1; i++)
			{
				result.Add($"Вариант {i} к заданию {exersiceID} из файла {FilePath}");
			}
			return result;
		}

		public string GetWording(int exersiceID)
		{
			return $"Формулировка задания {exersiceID} из файла {FilePath}";
		}
	}
}
