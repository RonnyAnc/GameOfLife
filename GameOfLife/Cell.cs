using System.Collections.Generic;
using static GameOfLife.CellState;

namespace GameOfLife
{
	public class Cell
	{
		public string Id { get; }
		public List<string> NeighborsIds { get; }
		public CellState State { get; }
		public int AliveNeighborsAmount { get; private set; }

		public Cell(string id, List<string> neighborsIds, CellState state = Alive)
		{
			this.Id = id;
			NeighborsIds = neighborsIds;
			State = state;
		}

		public void Configure(int numberOfAliveNeighbors)
		{
			AliveNeighborsAmount = numberOfAliveNeighbors;
		}

		public bool IsAlive()
		{
			return State == CellState.Alive;
		}
	}
}