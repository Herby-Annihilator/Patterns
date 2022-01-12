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
		private ConsolePresentator _consolePresentator;
		public ConsolePresentator Init(AccountManager accountManager, ILoginService loginService, IExamGenerator examGenerator)
			=> _consolePresentator ??= new ConsolePresentator(accountManager, loginService, examGenerator);
		private ConsolePresentator(AccountManager accountManager, ILoginService loginService, IExamGenerator examGenerator)
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
