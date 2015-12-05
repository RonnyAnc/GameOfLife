using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Tests
{
	internal class CellBuilder
	{
		private string cellId;
		private CellState state;
		private List<string> neighboursIds;

		public CellBuilder WithId(string id)
		{
			cellId = id;
			return this;
		}

		public CellBuilder WithState(CellState state)
		{
			this.state = state;
			return this;
		}

		public CellBuilder WithNeighbours(params string[] neighboursIds)
		{
			this.neighboursIds = neighboursIds.ToList();
			return this;
		}

		public Cell Build()
		{
			return new Cell(cellId, neighboursIds, state);
		}
	}
}