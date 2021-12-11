using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Users.UserData
{
	public class Locality
	{
		public LocalityType Type { get; set; }
		public string Name { get; set; }

		public Locality(LocalityType type, string name)
		{
			Type = type;
			Name = name;
		}
	}

	public enum LocalityType
	{
		City, Town, Village
	}
}
