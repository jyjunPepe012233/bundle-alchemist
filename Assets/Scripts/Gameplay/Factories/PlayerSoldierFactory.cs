using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Factories
{

	public static class PlayerSoldierFactory
	{
		public static IPlayerSoldier Create(ISoldierData soldierData)
		{
			return new PlayerSoldier(soldierData: soldierData,
				exp: 0,
				level: 1);
		}
	}

}