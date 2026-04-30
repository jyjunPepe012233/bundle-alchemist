using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IPlayerDataServicePort
	{ 
		// UI 등의 외부 시스템에서 PlayerData를 조작할 수 없도록
		// PlayerData를 IReadOnlyPlayerData로 추상화해서 제공하였음
		IReadOnlyPlayerData GetPlayerData();
	}

}