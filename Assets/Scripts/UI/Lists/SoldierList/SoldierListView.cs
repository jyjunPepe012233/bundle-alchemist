using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.SoldierList
{

	[Serializable]
	public class SoldierListView : UIView
	{
		[SerializeField] private SimpleSoldierCardList _soldierCardList;
		
		public void UpdateAllSoldiers(IReadOnlyList<ISoldierData> soldiers) // 카운팅, 인덱스 접근 등이 필요하므로 리스트(읽기 전용)로 받음
		{
			_soldierCardList.UpdateAllSoldiers(soldiers);
		}
	}

}