using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.Data.Runtime.Player
{
	// PlayerData같은 런타임 데이터는 인터페이스가 아니라 구현체로 만들어둠
	// Data 어셈블리에 구현체를 둬서 Gameplay와 Infrastructure 어셈블리에서 모두 참조할 수 있도록 하는 게 목적임
	// 

	[Serializable]
	public class PlayerData
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