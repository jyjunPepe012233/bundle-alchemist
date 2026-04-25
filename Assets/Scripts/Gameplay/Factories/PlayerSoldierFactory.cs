using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Factories
{

	public static class PlayerSoldierFactory
	{
		public static PlayerSoldier Create(ISoldierData soldierData)
		{
			return new PlayerSoldier(soldierData, 1);
		}
	}

}