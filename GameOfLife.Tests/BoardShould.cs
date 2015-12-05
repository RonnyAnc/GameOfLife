using FluentAssertions;
using GameOfLife.rules;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class BoardShould
	{
		[Test]
		public void calculate_number_of_alive_neighbours_for_a_cell()
		{
			var firstCell = AliveCell("1").WithNeighbours("2", "3", "4").Build();
			var secondCell = AliveCell("2").WithNeighbours("1").Build();
			var thirdCell = AliveCell("3").WithNeighbours("1").Build();
			var deadCell = DeadCell("4").WithNeighbours("1").Build();
			var board = ABoard()
						.WithCells(firstCell, secondCell, thirdCell, deadCell)
						.Build();

			board.PrepareForNextState();

			firstCell.AliveNeighborsAmount.Should().Be(2);
			secondCell.AliveNeighborsAmount.Should().Be(1);
			thirdCell.AliveNeighborsAmount.Should().Be(1);
		}

		private CellBuilder DeadCell(string id)
		{
			return new CellBuilder().WithId(id).WithState(Dead);
		}

		private static CellBuilder AliveCell(string id)
		{
			return new CellBuilder().WithId(id).WithState(Alive);
		}

		private static BoardBuilder ABoard()
		{
			return new BoardBuilder();
		}
	}
}