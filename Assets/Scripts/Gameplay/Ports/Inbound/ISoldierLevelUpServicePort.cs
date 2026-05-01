using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierLevelUpServicePort
	{
		void ConsumeFoods(ISoldierData soldier);

		void LevelUpTo(ISoldierData soldier, short targetLevel);
	}

}