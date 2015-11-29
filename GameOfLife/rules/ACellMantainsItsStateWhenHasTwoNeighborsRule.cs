namespace GameOfLife.rules
{
	public class ACellMantainsItsStateWhenHasTwoNeighborsRule : Rule
	{
		public CellState NextStateFor(Cell cell)
		{
			return cell.State;
		}
	}
}