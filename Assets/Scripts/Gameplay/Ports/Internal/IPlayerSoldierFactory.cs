using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IPlayerSoldierFactory // TODO: 이름 뒤에 Port 붙이기
	{
		IPlayerSoldier Create(ISoldierData soldierData);
	}

}