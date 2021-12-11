using SystemCore.Services;

namespace PresentationLayer.Presentators
{
	internal class ServiceRepository
	{
		internal AccountManager AccountManager { get; set; }

		internal IExamGenerator ExamGenerator { get; set; }
		internal ILoginService LoginService { get; set; }
	}
}