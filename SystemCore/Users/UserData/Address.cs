using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Users.UserData
{
	public class Address
	{
		public Address(string countryName, Locality locality, string streetName, int houseNumber)
		{
			CountryName = countryName;
			Locality = locality;
			StreetName = streetName;
			HouseNumber = houseNumber;
		}

		public string CountryName { get; set; }
		public Locality Locality { get; set; }
		public string StreetName { get; set; }
		public int HouseNumber { get; set; }
	}
}
