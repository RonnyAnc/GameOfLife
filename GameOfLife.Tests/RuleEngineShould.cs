using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.rules;
using NUnit.Framework;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{		
	[TestFixture]
	public class RuleEngineShould
	{
		private List<Rule> ruleSet;
		private RuleEngine ruleEngine;

		[SetUp]
		public void Setup()
		{
			ruleSet = new List<Rule>
			{
				new ACellDeadWhenHasOneNeighbor(),
				new ACellDeadWhenHasMoreThanThreeNeighbors(),
				new ACellLiveWhenHasThreeNeighbors(),
				new ACellMantainsItsStateWhenHasTwoNeighborsRule()
			};
			ruleEngine = new RuleEngine(ruleSet);
		}

		[Test]
		public void get_dead_state_when_a_cell_has_1_neighbour()
		{
			var cell = new Cell("AnyId", new List<string>());
			cell.Configure(1);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(Dead);
		}

		[Test]
		public void keep_alive_state_when_an_alive_cell_has_2_neighbours()
		{
			var cell = new Cell("AnyId", new List<string>());
			cell.Configure(2);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(cell.State);
		}

		[Test]
		public void keep_dead_state_when_a_dead_cell_has_2_neighbours()
		{
			var cell = new Cell("AnyId", new List<string>(), Dead);
			cell.Configure(2);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(cell.State);
		}

		[Test]
		public void get_alive_state_when_a_cell_has_3_neighbours()
		{
			var cell = new Cell("AnyId", new List<string>());
			cell.Configure(3);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(Alive);
		}

		[Test]
		public void get_dead_state_when_a_cell_has_more_than_3_neighbours()
		{
			var cell = new Cell("AnyId", new List<string>());
			cell.Configure(4);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(Dead);
		}
	}
}