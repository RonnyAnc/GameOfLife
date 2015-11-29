using FluentAssertions;
using NUnit.Framework;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class RulesTests
	{
		// TODO:
		//   - Get the given cell when it has 2 neighbors
		//   - Get an alive cell when the given one has 3 neighbors	 
		//   - Get a dead cell when the given one has more than 3 neighbors	 
		//   - Get a dead cell when the given one has less than 2 neighbors	 

		[Test]
		public void when_a_cell_has_two_neighbors_it_should_mantain_its_state()
		{
			var aliveCell = new Cell(2);

			var rule = new ACellMantainsItsStateWhenHasTwoNeighborsRule();
			var nextState = rule.NextStateFor(aliveCell);

			nextState.Should().Be(Alive);
		}
	}
}