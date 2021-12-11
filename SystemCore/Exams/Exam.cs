using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Tests;

namespace SystemCore.Exams
{
	public class Exam
	{
		public string Description { get; set; }
		public int Duration
		{
			get
			{
				int duration = 0;
				foreach (var item in Tests)
				{
					duration += item.Duration;
				}
				return duration;
			}
		}
		public List<Test> Tests;
	}
}
