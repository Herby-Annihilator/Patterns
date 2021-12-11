using PresentationLayer.Presentators.Base;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presentators
{
	internal class PresentationRepository
	{
		private Presentator _presentator;
		internal PresentationRepository(Presentator presentator)
		{
			_presentator = presentator;
		}
		private HelloPresentation _helloPresentation;
		internal HelloPresentation HelloPresentation => _helloPresentation  ??= new HelloPresentation(_presentator);

		private LoginPresentation _loginPresentation;
		internal LoginPresentation LoginPresentation => _loginPresentation ??= 
			new LoginPresentation(_presentator.ServiceRepository.LoginService, _presentator);

		private MainPresentation _mainPresentation;
		internal MainPresentation MainPresentation => _mainPresentation ??= new MainPresentation(_presentator);

		private PassExamPresentation _passExamPresentation;
		internal PassExamPresentation PassExamPresentation => _passExamPresentation ??= new PassExamPresentation(_presentator);

		private RegisterPresentation _registerPresentation;
		internal RegisterPresentation RegisterPresentation => _registerPresentation ??= 
			new RegisterPresentation(_presentator.ServiceRepository.AccountManager, _presentator);
	}
}
