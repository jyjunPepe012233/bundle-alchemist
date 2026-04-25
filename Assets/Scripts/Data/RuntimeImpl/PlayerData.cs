using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Runtime.Summon;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{

	[Serializable]
	public class PlayerData : IPlayerData
	{
		[SerializeField] private readonly List<IPlayerSoldier> _soldiers = new List<IPlayerSoldier>();

		public IReadOnlyCollection<IPlayerSoldier> Soldiers => _soldiers;


		public void AddSoldier(IPlayerSoldier soldier)
		{
			_soldiers.Add(soldier);
		}

		public void AddSoldiers(IEnumerable<IPlayerSoldier> soldiers)
		{
			_soldiers.AddRange(soldiers);
		}
	}

}