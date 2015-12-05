using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
	public class Board
	{
		private readonly RuleEngine ruleEngine;
		private readonly IEnumerable<Cell> cells;

		public Board(RuleEngine ruleEngine, IEnumerable<Cell> cells)
		{
			this.ruleEngine = ruleEngine;
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

		public void NextGeneration()
		{
			cells.ToList().ForEach(c => ruleEngine.ApplyRulesTo(c));
		}
	}
}