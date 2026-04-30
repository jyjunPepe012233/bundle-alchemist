using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ISoldierDetailServicePort
	{
		void ShowSoldierDetail(ISoldierData soldierData);
	}

}