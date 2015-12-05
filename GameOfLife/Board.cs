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
			cells.ToList().ForEach(ConfigureCell);
		}

		private void ConfigureCell(Cell cell)
		{
			var aliveNeighbors = AliveNeighboursAmountFor(cell);
			cell.Configure(aliveNeighbors);
		}

		private int AliveNeighboursAmountFor(Cell cell)
		{
			return cell.NeighborsIds.Count(id => GetCellById(id).IsAlive());
		}

		private Cell GetCellById(string cellId)
		{
			return cells.First(c => c.Id == cellId);
		}
	}
}