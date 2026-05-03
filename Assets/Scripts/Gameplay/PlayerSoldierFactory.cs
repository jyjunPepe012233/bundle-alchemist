using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Ports.Internal;

namespace ProjectB.Gameplay
{

	public class PlayerSoldierFactory : IPlayerSoldierFactory
	{
		private readonly ISoldierCombatPowerComputerPort _soldierCombatPowerComputerPort;
		
		public IPlayerSoldier Create(ISoldierData soldierData)
		{
			return new PlayerSoldier(soldierData: soldierData,
				exp: 0,
				level: 1,
				status: soldierData.BaseStatus,
				combatPower: _soldierCombatPowerComputerPort.ComputeCombatPower(soldierData, soldierData.BaseStatus));
		}
	}

}