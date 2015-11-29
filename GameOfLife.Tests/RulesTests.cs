using FluentAssertions;
using NUnit.Framework;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class RulesTests
	{
		// TODO:
		//   - Get an alive cell when the given one has 3 neighbors	 
		//   - Get a dead cell when the given one has more than 3 neighbors	 
		//   - Get a dead cell when the given one has less than 2 neighbors	 

		[Test]
		public void get_previous_state_when_cell_has_two_neighbors()
		{
			var aliveCell = new Cell(2);

			var rule = new ACellMantainsItsStateWhenHasTwoNeighborsRule();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Alive);
		}

		[Test]
		public void get_alive_state_when_cell_has_3_neighbors()
		{
			var aliveCell = new Cell(3);

			var rule = new ACellLiveWhenHasThreeNeighbors();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Alive);
		}

		[Test]
		public void get_dead_state_when_cell_has_more_than_3_neighbors()
		{
			var aliveCell = new Cell(5);

			var rule = new ACellDeadWhenHasMoreThanThreeNeighbors();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Dead);
		}
	}
}