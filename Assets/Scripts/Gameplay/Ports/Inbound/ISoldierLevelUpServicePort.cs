using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierLevelUpServicePort
	{
		void ConsumeFoods(string soldierId);
		
		void ConsumeFoods(ISoldierData soldier);

		void LevelUpTo(string soldierId, short targetLevel);

		void LevelUpTo(ISoldierData soldier, short targetLevel);
	}

}