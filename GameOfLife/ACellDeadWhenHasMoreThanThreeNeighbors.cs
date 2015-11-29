namespace GameOfLife
{
	public class ACellDeadWhenHasMoreThanThreeNeighbors
	{
		public CellState NextStateFor(Cell cell)
		{
			return CellState.Dead;
		}
	}
}