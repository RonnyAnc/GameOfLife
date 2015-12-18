using System.Collections.Generic;
using FluentAssertions;
using GameOfLife.rules;
using NSubstitute;
using NUnit.Framework;
using static GameOfLife.CellState;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class BoardShould
	{
		private RuleEngine ruleEngine;

		[SetUp]
		public void SetUp()
		{
			ruleEngine = Substitute.For<RuleEngine>(new List<Rule>());
		}

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

		[Test]
		public void should_apply_rules_foreach_cell_contained_in()
		{
			var firstCell = AliveCell("AnyId").Build();
			var secondCell = AliveCell("AnyOtherId").Build();
			var board = new Board(ruleEngine, new List<Cell> {firstCell, secondCell});

			board.NextGeneration();

			ruleEngine.Received(1).ApplyRulesTo(firstCell);
			ruleEngine.Received(1).ApplyRulesTo(secondCell);
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