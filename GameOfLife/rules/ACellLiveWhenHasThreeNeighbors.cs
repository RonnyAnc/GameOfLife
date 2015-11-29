namespace GameOfLife.rules
{
	public class ACellLiveWhenHasThreeNeighbors : Rule
	{
		public CellState NextStateFor(Cell cell)
		{				 
			if (cell.AliveNeighborsAmount == 3)
				return CellState.Alive;
			return cell.State;
		}
	}
}