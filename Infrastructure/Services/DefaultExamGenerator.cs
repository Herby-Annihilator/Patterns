using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.DataProviders;
using SystemCore.Entities;
using SystemCore.Exams;
using SystemCore.Exersices;
using SystemCore.Services;
using SystemCore.Tests;

namespace Infrastructure.Services
{
	public class DefaultExamGenerator : IExamGenerator
	{
		protected ITestDataProvider testDataProvider;
		protected IExersiceDataProvider exersiceDataProvider;

		public DefaultExamGenerator(ITestDataProvider testDataProvider, IExersiceDataProvider exersiceDataProvider)
		{
			this.testDataProvider = testDataProvider;
			this.exersiceDataProvider = exersiceDataProvider;
		}

		public IDescribedEntity GenerateExam()
		{
			Exam exam = new Exam();
			exam.Description = "Стандартный экзамен, созданный генератором";
			List<Test> tests = new List<Test>();
			Test test = new Test("", 1);
			test.Description = testDataProvider.GetDescription(0);
			test.Duration = testDataProvider.GetDuration(0);
			MultipleChoiceExersice exersice;
			for (int i = 0; i < 5; i++)
			{
				exersice = new MultipleChoiceExersice();
				exersice.Instruction = exersiceDataProvider.GetInstruction(i);
				exersice.Wording = exersiceDataProvider.GetWording(i);
				exersice.RequairedAnswer = exersiceDataProvider.GetRequiredAnswer(i);
				exersice.TestableSkill = exersiceDataProvider.GetTestableSkill(i);
				exersice.Variants = exersiceDataProvider.GetVariants(i);
				test.Entities.Add(exersice);
			}
			tests.Add(test);
			exam.Tests = tests;
			return null;
		}
	}
}
