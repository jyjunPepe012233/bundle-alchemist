using System;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierLevelUpServicePort
	{
		void ConsumeFoods(string soldierId);
		
		void ConsumeFoods(ISoldierData soldier);

		void LevelUpTo(string soldierId, short targetLevel);

		void LevelUpTo(ISoldierData soldier, short targetLevel);


		int GetConsumeFoodAmount(string soldierId);

		
		SoldierStatus GetNextLevelStatus(string soldierId);
	}

}