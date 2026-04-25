using System.Collections.Generic;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimplePlayerSoldierCardList : MonoBehaviour
	{
		[SerializeField] private Transform _contentRoot;
		[SerializeField] private SimplePlayerSoldierCard _cardPrefab;

		
		private readonly List<SimplePlayerSoldierCard> _cardPool = new(8); // 게임 규모가 작아서 초기 풀을 작게 설정

		
		public void UpdateAllSoldiers(IReadOnlyList<(IPlayerSoldier playerSoldier,
			ISoldierData soldierData)> data) // 카운팅, 인덱스 접근 등이 필요하므로 리스트(읽기 전용)로 받음
		{
			if (!_contentRoot)
			{
				Debug.LogError(gameObject.name + "의 content Root가 설정되지 않았습니다");
				return;
			}

			if (!_cardPrefab)
			{
				Debug.LogError(gameObject.name + "의 card Prefab이 설정되지 않았습니다");
				return;
			}
			
			foreach (var c in _cardPool)
			{
				c.gameObject.SetActive(false);
			}
			 
			GenerateCardInstance(data.Count); // 필요한 개수만큼 카드 인스턴스를 확보
			for (int i = 0; i < data.Count; i++)
			{
				
				_cardPool[i].ApplySoldierData(data[i].soldierData);
				_cardPool[i].ApplyPlayerSoldierData(data[i].playerSoldier);
			}
		}

		// 필요한 개수만큼 카드 인스턴스를 확보
		void GenerateCardInstance(int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (i < _cardPool.Count)
				{
					_cardPool[i].gameObject.SetActive(true);
					continue;
				}
				
				var card = Instantiate(_cardPrefab, _contentRoot);
				_cardPool.Add(card);
			}
		}
	}

}