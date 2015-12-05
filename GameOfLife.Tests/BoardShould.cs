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
			var aCell = new Cell("1", new List<string> {"2"});
			var anotherCell = new Cell("2", new List<string> {"1"});
			var cells = new List<Cell>
			{
				aCell,
				anotherCell
			};
			var board = new Board(cells);

			board.PrepareForNextState();

			aCell.AliveNeighborsAmount.Should().Be(1);
			anotherCell.AliveNeighborsAmount.Should().Be(1);
		}	 
	}

	public class Board
	{
		private readonly IEnumerable<Cell> cells;

		public Board(IEnumerable<Cell> cells)
		{
			this.cells = cells;
		}

		public void PrepareForNextState()
		{
			foreach (var cell in cells)
			{
				cell.Configure(1);
			}
		}
	}
}