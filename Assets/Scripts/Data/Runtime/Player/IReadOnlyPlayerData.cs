using System.Collections.Generic;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerData
	{
		IReadOnlyCollection<IPlayerSoldier> Soldiers { get; }
	}

}