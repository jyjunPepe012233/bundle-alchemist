using ProjectB.Data.Runtime.Player;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class InitializePlayerSessionService : IInitializePlayerSessionPort
	{
		public void Initialize(PlayerData playerData)
		{
			PlayerSessionHolder.Initialize(playerData);
		}
	}

}