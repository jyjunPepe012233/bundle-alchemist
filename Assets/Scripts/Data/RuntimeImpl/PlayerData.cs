using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using UnityEngine;

namespace ProjectB.Data.RuntimeImpl
{

	[Serializable]
	public class PlayerData : IPlayerData
	{
		[SerializeField] private readonly List<PlayerSoldier> _soldiers = new List<PlayerSoldier>();

		public IReadOnlyCollection<PlayerSoldier> Soldiers => _soldiers;


		public void AddSoldier(PlayerSoldier soldier)
		{
			_soldiers.Add(soldier);
		}

		public void AddSoldiers(IEnumerable<PlayerSoldier> soldiers)
		{
			_soldiers.AddRange(soldiers);
		}
	}

}