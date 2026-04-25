using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface IPlayerSessionHolderPort
	{
		PlayerSession GetPlayerSession();
	}

}