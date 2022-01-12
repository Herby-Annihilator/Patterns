using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace PresentationLayer.Views
{
	public class PatternsWorkPresentation : Presentation
	{
		private IDescribedEntity _compositeTree;

		public PatternsWorkPresentation(Presentator presentator)
		{
			this.presentator = presentator;
		}

		public override bool StartPresentation()
		{
			ConsoleKey key;
			bool validAnswer = false;
			do
			{
				Console.Clear();
				Console.WriteLine("Показать работу адаптера - 1");
				Console.WriteLine("Показать работу декоратора - 2");
				Console.WriteLine("Показать работу итератора и композита - 3");
				Console.WriteLine("Выйти - ESC");
				Console.Write("Ваш выбор: ");
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.D1:
						{
							validAnswer = true;
							break;
						}
					case ConsoleKey.D2:
						{
							validAnswer = true;
							break;
						}
					case ConsoleKey.D3:
						{
							validAnswer = true;
							break;
						}
					case ConsoleKey.Escape:
						{
							validAnswer = true;
							break;
						}
				}
			} while (!validAnswer);			
			return true;
		}
	}
}
