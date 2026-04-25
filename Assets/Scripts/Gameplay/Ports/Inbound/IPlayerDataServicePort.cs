using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IPlayerDataServicePort
	{ 
		IReadOnlyPlayerData GetPlayerData();
	}

}