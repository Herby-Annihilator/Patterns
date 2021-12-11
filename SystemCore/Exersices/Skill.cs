using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Exersices
{
	public class Skill
	{
		public int ID { get; private set; }
		public string Description { get; set; }

		public Skill(int iD, string description)
		{
			ID = iD;
			Description = description;
		}
	}
}
