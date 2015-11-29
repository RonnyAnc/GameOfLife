using static GameOfLife.CellState;

namespace GameOfLife
{
	public class ACellLiveWhenHasThreeNeighbors : Rule
	{
		public CellState NextStateFor(Cell cell)
		{				 
			if (cell.AliveNeighborsAmount == 3)
				return Alive;
			return cell.State;
		}
	}
}