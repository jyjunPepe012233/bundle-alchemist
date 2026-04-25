using ProjectB.Data.Runtime.Player;

namespace ProjectB.Data.Runtime.Summon
{

	public class PlayerSession : IPlayerSession
	{
		public IPlayerData PlayerData { get; }

		public PlayerSession(IPlayerData playerData)
		{
			PlayerData = playerData;
		}
	}

}