using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Exersices
{
	public class Subject
	{
		public string Name { get; set; }
		public List<Skill> Skills { get; set; }

		public Subject(string name, List<Skill> skills)
		{
			Name = name;
			Skills = skills;
		}
	}
}
