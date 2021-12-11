using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Exams;
using SystemCore.Services;

namespace Infrastructure.Services
{
	public class ExamGeneratorProxy : IExamGenerator
	{
		private Exam _generatedExam;
		private IExamGenerator _generator;

		public ExamGeneratorProxy(DefaultExamGenerator generator)
		{
			_generator = generator;
		}
		public Exam GenerateExam() => _generatedExam ??= _generator.GenerateExam();
	}
}
