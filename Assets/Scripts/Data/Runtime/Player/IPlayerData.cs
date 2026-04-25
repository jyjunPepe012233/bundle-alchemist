using System.Collections.Generic;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerData : IReadOnlyPlayerData
	{
		void AddSoldier(IPlayerSoldier soldier);
		
		void AddSoldiers(IEnumerable<IPlayerSoldier> soldiers);
	}

}