using ProjectB.Data.Runtime.Player;

namespace ProjectB.Data.RuntimeImpl
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