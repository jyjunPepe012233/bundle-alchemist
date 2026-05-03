using ProjectB.Data.Static.SoldierAttackType;
using ProjectB.Data.Static.SoldierPosition;
using ProjectB.Data.Static.SoldierRole;
using ProjectB.Data.Static.Spirit;
using ProjectB.Data.Types;

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
		
		ISoldierAttackType AttackType { get; }
		
		ISoldierPosition Position { get; }
		
		SoldierStatus BaseStatus { get; }
		
		SoldierStatusf StatusGrowth { get; }
	}

}