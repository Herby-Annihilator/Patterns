using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Entities;
using SystemCore.Exersices;
using SystemCore.Tests;

namespace SystemCore.Iterators
{
	public class DescribedEntityEnumerator : IEnumerator<IDescribedEntity>
	{
		private IDescribedEntity _collection;
		private int _currentTest;
		private int _currentExersice;
		private bool _testsWasVisited;
		private bool _exersicesWasVisited;

		private List<IDescribedEntity> _tests;
		private List<IDescribedEntity> _exersices;

		public DescribedEntityEnumerator(IDescribedEntity collection)
		{
			_collection = collection;
			_currentExersice = -1;
			_currentTest = -1;
			_tests = new List<IDescribedEntity>();
			_exersices = new List<IDescribedEntity>();
			_testsWasVisited = false;
			_exersicesWasVisited = false;
			Init();
		}
		public IDescribedEntity GetCurrent()
		{
			if (!_exersicesWasVisited)
				return _exersices[_currentExersice];
			else
				return _tests[_currentTest];
		}

		public bool MoveNext()
		{
			if (_currentExersice >= _exersices.Count)
			{
				_exersicesWasVisited = true;
				if (_currentTest >= _tests.Count)
				{
					_testsWasVisited = true;
					return false;
				}
				else
				{
					_currentTest++;
					return true;
				}
			}
			else
			{
				_currentExersice++;
				return true;
			}
		}

		private void Init()
		{
			var test = _collection as Test;
			Queue<Test> qtest = new Queue<Test>();
			if (test == null)
				return;
			qtest.Enqueue(test);
			_tests.Add(test);
			while (qtest.Count > 0)
			{
				test = qtest.Dequeue();
				foreach (var item in test.Entities)
				{
					if (item is Exersice)
					{
						_exersices.Add(item);
					}
					else
					{
						qtest.Enqueue(item as Test);
						_tests.Add(item);
					}
				}
			}
		}

		public void Reset()
		{
			_currentExersice = -1;
			_currentTest = -1;
			_tests.Clear();
			_exersices.Clear();
			_testsWasVisited = false;
			_exersicesWasVisited = false;
			Init();
		}
	}
}
