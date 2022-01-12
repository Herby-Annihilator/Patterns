using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;
using SystemCore.Exersices;
using SystemCore.Iterators;

namespace SystemCore.Tests
{
	public class Test : IDescribedEntity
	{
		public string Description { get; set; }
		public int Duration { get; set; }
		public List<IDescribedEntity> Entities { get; }

		public Test(string description, int duration)
		{
			Duration = duration;
			Description = description;
			Entities = new List<IDescribedEntity>();
		}

		public void AddEntity(IDescribedEntity entity) => Entities.Add(entity);
		public void RemoveEntity(IDescribedEntity entity) => Entities.Remove(entity);

		public string GetDescription() => Description;

		public Iterators.IEnumerator<IDescribedEntity> GetEnumerator() => new DescribedEntityEnumerator(this);

		public IDescribedEntity Clone()
		{
			Test test = new Test((string)Description.Clone(), Duration);
			foreach (var item in Entities)
			{
				test.Entities.Add(item.Clone());
			}
			return test;
		}
	}
}
