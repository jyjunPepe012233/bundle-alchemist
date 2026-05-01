using ProjectB.Data.Static.SoldierRole;
using ProjectB.Data.Static.Spirit;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierData
	{
		ISoldierCardDisplaySetting CardDisplaySetting { get; }
		
		ISoldierLevelUpExpSetting LevelUpExpSetting { get; }
		
		
		string SoldierId { get; }
		
		string SoldierName { get; }
		
		ISpiritData Spirit { get; }
		
		ISoldierRoleData Role { get; }
	}

}