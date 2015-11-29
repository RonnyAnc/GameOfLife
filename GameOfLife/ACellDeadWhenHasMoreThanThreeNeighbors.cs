using static GameOfLife.CellState;

namespace GameOfLife
{
	public class ACellDeadWhenHasMoreThanThreeNeighbors
	{
		public CellState NextStateFor(Cell cell)
		{
			if (cell.AliveNeighborsAmount > 3)
				return Dead;
			return cell.State;
		}
	}
}