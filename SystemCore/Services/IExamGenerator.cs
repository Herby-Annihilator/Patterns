using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;
using SystemCore.Exams;

namespace SystemCore.Services
{
	public interface IExamGenerator
	{
		IDescribedEntity GenerateExam();
	}
}
