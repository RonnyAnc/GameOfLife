using System.Collections.Generic;
using System.Linq;

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
				var aliveNeighbors = cell.NeighborsIds.Count(id => GetCellById(id).IsAlive());
				cell.Configure(aliveNeighbors);
			}
		}

		private Cell GetCellById(string cellId)
		{
			return cells.First(c => c.Id == cellId);
		}
	}
}