using ProjectB.Data.Runtime.Player;

namespace ProjectB.Infrastructure
{

	public static class PlayerSessionHolder
	{
		public static PlayerSession PlayerSession { get; private set; }

		public static bool HasInitialized { get; private set; }

		public static PlayerSession Initialize(PlayerData playerData)
		{
			PlayerSession = new PlayerSession(playerData);
			HasInitialized = true;
			return PlayerSession;
		}
	}

}