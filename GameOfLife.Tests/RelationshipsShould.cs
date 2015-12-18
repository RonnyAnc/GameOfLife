using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class RelationshipsShould
	{
		[Test]
		public void generate_a_list_of_cells_using_defined_rels()
		{
			var relationships = new Relationships();

			relationships.Add("1", new List<string> {"2", "3"});

			relationships["1"].Should().BeEquivalentTo(new List<string> {"2", "3"});
			relationships["2"].Should().BeEquivalentTo(new List<string> {"1"});
			relationships["3"].Should().BeEquivalentTo(new List<string> {"1"});
		}		 
	}

	public class Relationships
	{
		private Dictionary<string, List<string>> reltationshipsByCell;

		public Relationships()
		{
			reltationshipsByCell = new Dictionary<string, List<string>>();
		}

		public void Add(string cellId, List<string> neighboursIds)
		{
			reltationshipsByCell.Add(cellId, neighboursIds);
		}

		public List<string> this[string cellId]
		{
			get { return reltationshipsByCell[cellId]; }
		}
	}
}