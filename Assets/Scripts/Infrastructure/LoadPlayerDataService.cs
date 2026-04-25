using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadPlayerDataService : ILoadPlayerDataPort
	{
		public IPlayerData LoadPlayerData()
		{
			return new PlayerData();
		}
	}

}