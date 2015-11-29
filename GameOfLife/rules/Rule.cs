namespace GameOfLife.rules
{
	public interface Rule
	{
		CellState NextStateFor(Cell cell);
	}
}