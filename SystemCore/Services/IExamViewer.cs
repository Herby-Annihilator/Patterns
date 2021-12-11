using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exams;

namespace SystemCore.Services
{
	public interface IExamViewer
	{
		void ShowExam(Exam exam);
	}
}
