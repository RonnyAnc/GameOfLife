using static GameOfLife.CellState;

namespace GameOfLife
{
	public class Cell
	{
		public int AliveNeighborsAmount { get; }
		public CellState State { get; }

		public Cell(int aliveNeighborsAmount, CellState state = Alive)
		{
			AliveNeighborsAmount = aliveNeighborsAmount;
			State = state;
		}
	}
}