using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.rules;
using NUnit.Framework;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class RulesTests
	{
		[Test]
		public void get_previous_state_when_cell_has_two_neighbors()
		{
			var aliveCell = new Cell("AnyId", new List<string>());
			aliveCell.Configure(2);
			
			var rule = new ACellMantainsItsStateWhenHasTwoNeighborsRule();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Alive);
		}
			   
		[Test]
		public void get_alive_state_when_cell_has_3_neighbors()
		{
			var aliveCell = new Cell("AnyId", new List<string>());
			aliveCell.Configure(3);

			var rule = new ACellLiveWhenHasThreeNeighbors();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Alive);
		}

		[Test]
		public void get_dead_state_when_cell_has_more_than_3_neighbors()
		{
			var aliveCell = new Cell("AnyId", new List<string>());
			aliveCell.Configure(5);

			var rule = new ACellDeadWhenHasMoreThanThreeNeighbors();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Dead);
		}

		[Test]
		public void get_dead_state_when_cell_has_1_neighbor()
		{
			var aliveCell = new Cell("AnyId", new List<string>());
			aliveCell.Configure(1);

			var rule = new ACellDeadWhenHasOneNeighbor();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Dead);
		}
	}
}