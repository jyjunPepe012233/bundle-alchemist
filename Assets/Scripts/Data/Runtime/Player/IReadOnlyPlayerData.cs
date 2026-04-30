using System;
using System.Collections.Generic;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerData
	{
		int Coins { get; }
		
		int Gems { get; }
		
		IReadOnlyCollection<IPlayerSoldier> Soldiers { get; }

		event Action CoinsChanged;

		event Action GemsChanged;
	}

}