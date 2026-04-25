using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Data.RuntimeImpl
{

	public class PlayerSoldier : IPlayerSoldier
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