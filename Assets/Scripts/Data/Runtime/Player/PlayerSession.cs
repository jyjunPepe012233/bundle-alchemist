namespace ProjectB.Data.Runtime.Player
{

	public class PlayerSession
	{
		public IPlayerData PlayerData { get; }

		public PlayerSession(IPlayerData playerData)
		{
			PlayerData = playerData;
		}
	}

}