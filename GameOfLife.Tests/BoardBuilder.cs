using System.Collections.Generic;
using System.Linq;

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
			return new Board(cells);
		}

		public BoardBuilder WithCells(params Cell[] cells)
		{
			this.cells = cells.ToList();
			return this;
		}
	}
}