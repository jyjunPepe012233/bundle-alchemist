namespace ProjectB.Data.Runtime.Player
{

	public class PlayerSession
	{
		public PlayerData PlayerData { get; }

		public PlayerSession(PlayerData playerData)
		{
			PlayerData = playerData;
		}
	}

}