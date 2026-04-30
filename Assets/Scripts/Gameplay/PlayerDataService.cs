using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{

	public class PlayerDataService : IPlayerDataServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;
		
		public PlayerDataService(IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
		}

		public IReadOnlyPlayerData GetPlayerData()
		{
			// IPlayerData가 IReadOnlyPlayerData로 캐스팅
			return _playerSessionHolderPort.GetPlayerSession().PlayerData;
		}
	}

}