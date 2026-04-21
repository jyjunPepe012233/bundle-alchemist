using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Data.Runtime.Summon
{

	public struct SummonResult
	{
		public ISoldierData[] summonedSoldiers;

		public SummonType type;

		public SummonResult(ISoldierData[] summonedSoldiers, SummonType type)
		{
			this.summonedSoldiers = summonedSoldiers;
			this.type = type;
		}
	}

}