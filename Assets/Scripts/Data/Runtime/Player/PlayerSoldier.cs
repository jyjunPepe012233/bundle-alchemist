using ProjectB.Data.Static.Soldier;

namespace ProjectB.Data.Runtime.Player
{

	public class PlayerSoldier
	{
		public string SoldierId { get; }
		
		public short Level { get; }


		public PlayerSoldier(ISoldierData soldierData, short level)
		{
			SoldierId = soldierData.SoldierId;
			Level = level;
		}
	}

}