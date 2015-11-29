namespace GameOfLife
{
	public class ACellLiveWhenHasThreeNeighbors
	{
		public CellState NextStateFor(Cell cell)
		{
			return CellState.Alive;
		}
	}
}