namespace GameOfLife
{
	public class ACellMantainsItsStateWhenHasTwoNeighborsRule
	{
		public CellState NextStateFor(Cell cell)
		{
			return cell.State;
		}
	}
}