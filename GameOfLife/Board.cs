using System.Collections.Generic;

namespace GameOfLife
{
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