using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
	class MainPresentation : Presentation
	{
		public MainPresentation(Presentator presentator)
		{
			this.presentator = presentator;
		}
		public override bool StartPresentation()
		{
			Console.Clear();
			Console.WriteLine("Добро пожаловать в главную форму. Выберите действие");
			Console.WriteLine("1 - Пройти экзамен");
			Console.WriteLine("ESC - Перейти в начало");
			bool validAnswer = false;
			do
			{
				Console.Write("Ваш выбор: ");
				var key = Console.ReadKey(true).Key;
				switch (key)
				{
					case ConsoleKey.D1:
						{
							//presentator.PresentationRepository.PassExamPresentation.ExamToShow =
								//presentator.ServiceRepository.ExamGenerator.GenerateExam();
							presentator.ChangePresentation(presentator.PresentationRepository.PassExamPresentation);
							validAnswer = true;
							break;
						}
					case ConsoleKey.Escape:
						{
							presentator.ChangePresentation(presentator.PresentationRepository.HelloPresentation);
							validAnswer = true;
							break;
						}
				}
			} while (!validAnswer);
			return true;
		}
	}
}
