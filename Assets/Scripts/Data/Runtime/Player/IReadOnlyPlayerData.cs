using System;
using System.Collections.Generic;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerData
	{
		int Coins { get; }
		
		int Gems { get; }
		
		int Foods { get; }
		
		IReadOnlyCollection<IPlayerSoldier> Soldiers { get; }

		event Action CoinsChanged;

		event Action GemsChanged;

		event Action FoodsChanged;
	}

}