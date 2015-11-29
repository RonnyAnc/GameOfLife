namespace GameOfLife.rules
{
	public class ACellDeadWhenHasMoreThanThreeNeighbors : Rule
	{
		public CellState NextStateFor(Cell cell)
		{
			if (cell.AliveNeighborsAmount > 3)
				return CellState.Dead;
			return cell.State;
		}
	}
}