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
				var aliveNeighbors = 0;
				foreach (var neighborsId in cell.NeighborsIds)
				{
					var neighbour = GetCellById(neighborsId);
					if (neighbour.State == CellState.Alive)
					{
						aliveNeighbors += 1;
					}
				}
				cell.Configure(aliveNeighbors);
			}
		}

		private Cell GetCellById(string cellId)
		{
			return cells.First(c => c.Id == cellId);
		}
	}
}