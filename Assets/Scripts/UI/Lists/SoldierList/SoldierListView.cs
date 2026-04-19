using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Core;
using ProjectB.UI.ListItems.SoldierCard;
using UnityEngine;

namespace ProjectB.UI.Lists.SoldierList
{

	[Serializable]
	public class SoldierListView : UIView
	{
		[SerializeField] private Transform _contentRoot;
		[SerializeField] private SoldierCardView _soldierCardPrefab;

		private readonly List<SoldierCardView> _soldierCardPool = new List<SoldierCardView>(8); // 게임 규모가 작아서 초기 풀을 작게 설정

		public void UpdateAllSoldiers(IReadOnlyList<ISoldierData> soldiers) // 카운팅, 인덱스 접근 등이 필요하므로 리스트(읽기 전용)로 받음
		{
			foreach (var c in _soldierCardPool)
			{
				c.gameObject.SetActive(false);
			}
			 
			GenerateCardInstance(soldiers.Count); // 필요한 개수만큼 카드 인스턴스를 확보
			for (int i = 0; i < soldiers.Count; i++)
			{
				_soldierCardPool[i].ApplySoldierData(soldiers[i]);
			}
		}

		// 필요한 개수만큼 카드 인스턴스를 확보
		void GenerateCardInstance(int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (i < _soldierCardPool.Count)
				{
					_soldierCardPool[i].gameObject.SetActive(true);
					continue;
				}
				
				var card = UnityEngine.Object.Instantiate(_soldierCardPrefab, _contentRoot);
				_soldierCardPool.Add(card);
			}
		}
	}

}