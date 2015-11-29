namespace GameOfLife
{
	public class ACellLiveWhenHasThreeNeighbors
	{
		public CellState NextStateFor(Cell cell)
		{				 
			if (cell.AliveNeighborsAmount == 3)
				return CellState.Alive;
			return CellState.Dead;
		}
	}
}