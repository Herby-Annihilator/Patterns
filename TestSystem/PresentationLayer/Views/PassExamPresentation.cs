using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exams;
using SystemCore.Exersices;
using SystemCore.Tests;

namespace PresentationLayer.Views
{
	class PassExamPresentation : Presentation
	{
		public Exam ExamToShow { get; set; }
		internal PassExamPresentation(Presentator presentator)
		{
			this.presentator = presentator;
		}
		public override bool StartPresentation()
		{
			Console.Clear();
			Console.WriteLine(ExamToShow.Description);
			Console.WriteLine($"Продолжительность экзамена: {ExamToShow.Duration} минут\n\n");
			foreach (var test in ExamToShow.Tests)
			{
				ShowTest(test);
			}
			Console.Write("Вы ответили на вопросы экзамена. Нажмите любую клавишу...");
			Console.ReadKey(true);
			presentator.ChangePresentation(presentator.PresentationRepository.MainPresentation);
			return true;
		}

		private void ShowTest(Test test)
		{
			Console.WriteLine(test.Description);
			Console.WriteLine($"Продолжительность теста: {test.Duration} минут\n\n\n");
			for (int i = 0; i < test.Exersices.Count; i++)
			{
				ShowMultipleChoiceExersice(i + 1, test.Exersices[i]);
			}
		}
		private void ShowMultipleChoiceExersice(int exersiceNumber, MultipleChoiceExersice multipleChoiceExersice)
		{
			Console.WriteLine($"Задание № {exersiceNumber}");
			Console.WriteLine($"Инструкция: {multipleChoiceExersice.Instruction}");
			Console.WriteLine($"Задание: {multipleChoiceExersice.Wording}");
			Console.WriteLine("Варианты:");
			for (int i = 0; i < multipleChoiceExersice.Variants.Count; i++)
			{
				Console.WriteLine($"{i + 1} - {multipleChoiceExersice.Variants[i]}");
			}
			int answerNumber;
			do
			{
				Console.Write("Ваш ответ №: ");
			} while (!int.TryParse(Console.ReadLine(), out answerNumber) && !IsAnswerValid(answerNumber, multipleChoiceExersice));
			multipleChoiceExersice.RecievedAnswer = multipleChoiceExersice.Variants[answerNumber - 1];
		}

		private bool IsAnswerValid(int answerNumber, MultipleChoiceExersice exersice) =>
			answerNumber > 0
			&& (answerNumber - 1) < exersice.Variants.Count
			;
	}
}
