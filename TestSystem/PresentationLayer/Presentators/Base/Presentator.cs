using PresentationLayer.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presentators.Base
{
	public abstract class Presentator
	{
		protected Presentation _presentation;

		internal PresentationRepository PresentationRepository { get; set; }
		internal ServiceRepository ServiceRepository { get; set; }

		public virtual void ChangePresentation(Presentation presentation) => _presentation = presentation;
		public abstract void StartPresentation();
	}
}
