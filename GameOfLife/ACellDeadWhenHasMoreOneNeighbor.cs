namespace GameOfLife
{
	public class ACellDeadWhenHasMoreOneNeighbor : Rule
	{
		public CellState NextStateFor(Cell cell)
		{
			if (cell.AliveNeighborsAmount == 1)
				return CellState.Dead;
			return cell.State;
		}
	}
}