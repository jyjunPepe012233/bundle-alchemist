using System;
using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.PlayerSoldierList
{

	[Serializable]
	public class PlayerSoldierListView : UIView
	{
		[SerializeField] private SimplePlayerSoldierCardList _cardList;

		public void UpdateAllPlayerSoldiers(IReadOnlyList<(IPlayerSoldier playerSoldier,
			ISoldierData soldierData)> data) // 카운팅, 인덱스 접근 등이 필요하므로 리스트(읽기 전용)로 받음
		{
			_cardList.UpdateAllSoldiers(data);
		}
	}

}