using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class BoardShould
	{
		[Test]
		public void calculate_number_of_alive_neighbours_for_a_cell()
		{
			var firstCell = new Cell("1", new List<string> {"2", "3"});
			var secondCell = new Cell("2", new List<string> {"1"});
			var thirdCell = new Cell("3", new List<string> {"1"});
			var cells = new List<Cell>
			{
				firstCell,
				secondCell,
				thirdCell
			};
			var board = new Board(cells);

			board.PrepareForNextState();

			firstCell.AliveNeighborsAmount.Should().Be(2);
			secondCell.AliveNeighborsAmount.Should().Be(1);
			thirdCell.AliveNeighborsAmount.Should().Be(1);
		}	 
	}
}