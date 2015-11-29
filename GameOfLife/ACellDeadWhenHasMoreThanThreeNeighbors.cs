using static GameOfLife.CellState;

namespace GameOfLife
{
	public interface Rule
	{
		CellState NextStateFor(Cell cell);
	}

	public class ACellDeadWhenHasMoreThanThreeNeighbors : Rule
	{
		public CellState NextStateFor(Cell cell)
		{
			if (cell.AliveNeighborsAmount > 3)
				return Dead;
			return cell.State;
		}
	}
}