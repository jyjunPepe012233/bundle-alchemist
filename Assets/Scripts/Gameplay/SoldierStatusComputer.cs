using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Internal;

namespace ProjectB.Gameplay
{
	
	public class SoldierStatusComputer : ISoldierStatusComputerPort
	{
		public SoldierStatus ComputeSoldierStatus(ISoldierData soldierData, IPlayerSoldier playerSoldier)
		{
			// 레벨 당 BaseStatus에 StatusGrowth를 계속 곱하는 방식
			// (레벨이 오를수록 레벨 업을 통한 스탯 증가량이 커짐)
			
			var baseStatus = soldierData.BaseStatus;
			var growth = soldierData.StatusGrowth;
			var level = playerSoldier.Level;

			var growthLevel = level - 1; // 레벨 1에는 성장 효과가 없다고 가정하는 처리 (레벨 2부터 곱함)
			var multiplier = new SoldierStatusf
			{
				hp = 1f + growth.hp * growthLevel,
				sp = 1f + growth.sp * growthLevel,
				physicalAttack = 1f + growth.physicalAttack * growthLevel,
				magicalAttack = 1f + growth.magicalAttack * growthLevel,
				physicalDefense = 1f + growth.physicalDefense * growthLevel,
				magicalDefense = 1f + growth.magicalDefense * growthLevel
			};

			return baseStatus * multiplier;
		}
	}

}