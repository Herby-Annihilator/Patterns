using PresentationLayer.Presentators.Base;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services;

namespace PresentationLayer.Presentators
{
	public class ConsolePresentator : Presentator
	{
		internal ConsolePresentator()
		{

		}
		public ConsolePresentator(AccountManager accountManager, ILoginService loginService, IExamGenerator examGenerator) : this()
		{
			ServiceRepository = new ServiceRepository()
			{
				AccountManager = accountManager,
				ExamGenerator = examGenerator,
				LoginService = loginService
			};
			PresentationRepository = new PresentationRepository(this);
			_presentation = PresentationRepository.HelloPresentation;
		}
		public override void StartPresentation() { while (_presentation.StartPresentation()) ; }
	}
}
