using PresentationLayer.Presentators.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Base
{
	public abstract class Presentation
	{
		protected Presentator presentator;
		public abstract bool StartPresentation();
	}
}
