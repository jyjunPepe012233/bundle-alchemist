using System.Collections.Generic;

namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerData
	{
		IReadOnlyCollection<PlayerSoldier> Soldiers { get; }
		
		void AddSoldier(PlayerSoldier soldier);
		
		void AddSoldiers(IEnumerable<PlayerSoldier> soldiers);
	}

}