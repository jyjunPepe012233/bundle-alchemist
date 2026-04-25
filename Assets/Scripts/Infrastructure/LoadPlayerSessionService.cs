using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadPlayerSessionService : ILoadPlayerSessionPort
	{
		public PlayerSession LoadPlayerSession()
		{
			return PlayerSessionHolder.PlayerSession;
		}
	}

}