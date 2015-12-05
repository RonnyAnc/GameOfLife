using System.Collections.Generic;
using System.Linq;
using GameOfLife.rules;

namespace GameOfLife.Tests
{
	public class BoardBuilder
	{
		private List<Cell> cells;

		public BoardBuilder()
		{
			cells = new List<Cell>();
		}

		public Board Build()
		{
			return new Board(new NoRuleEngine(), cells);
		}

		public BoardBuilder WithCells(params Cell[] cells)
		{
			this.cells = cells.ToList();
			return this;
		}
	}

	public class NoRuleEngine : RuleEngine
	{
		public NoRuleEngine() : base(new List<Rule>())
		{
		}
	}
}