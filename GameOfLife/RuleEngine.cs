using System.Collections.Generic;
using GameOfLife.rules;

namespace GameOfLife
{
	public class RuleEngine
	{
		private readonly List<Rule> ruleSet;

		public RuleEngine(List<Rule> ruleSet)
		{
			this.ruleSet = ruleSet;
		}

		public virtual CellState ApplyRulesTo(Cell cell)
		{
			var cellState = cell.State;
			foreach (var rule in ruleSet)
			{
				if(cellState == cell.State)
					cellState = rule.NextStateFor(cell);
			}

			return cellState;
		}
	}
}