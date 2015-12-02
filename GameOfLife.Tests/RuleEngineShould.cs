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
		public void apply_the_one_neighbour_rule()
		{
			var cell = new Cell("AnyId", new List<string>());
			cell.Configure(1);

			var newState = ruleEngine.ApplyRulesTo(cell);

			newState.Should().Be(Dead);
		}

	}
}