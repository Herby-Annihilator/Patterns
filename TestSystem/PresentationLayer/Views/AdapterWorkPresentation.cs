using PresentationLayer.Presentators.Base;
using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
	public class AdapterWorkPresentation : Presentation
	{
		public AdapterWorkPresentation(Presentator presentator)
		{
			this.presentator = presentator;
		}
		public override bool StartPresentation()
		{
			Console.Clear();
			Console.WriteLine("Работа адаптера");

			return true;
		}
	}
}
