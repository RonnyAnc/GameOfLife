namespace GameOfLife.rules
{
	public class ACellDeadWhenHasOneNeighbor : Rule
	{
		public CellState NextStateFor(Cell cell)
		{
			if (cell.AliveNeighborsAmount == 1)
				return CellState.Dead;
			return cell.State;
		}
	}
}