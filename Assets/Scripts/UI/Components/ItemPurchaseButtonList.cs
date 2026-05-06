using System;
using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class ItemPurchaseButtonList : MonoBehaviour
	{
		[SerializeField] private Transform _contentRoot;
		[SerializeField] private ItemPurchaseButton _buttonPrefab;

		private readonly List<ItemPurchaseButton> _buttonPool = new(8);
		
		// UpdateAllItems 호출 시 ShopItem 배열을 이 변수에 저장하여
		// 버튼이 클릭되었을 때 버튼의 인덱스를 통해 특정 ShopItem을 이벤트로 전달함
		private IReadOnlyList<IShopItem> _currentShopItems;

		public event Action<IShopItem> PurchaseButtonClicked;

		public void UpdateAllItems(IReadOnlyList<IShopItem> shopItems)
		{
			if (!_contentRoot)
			{
				Debug.LogError(gameObject.name + "의 content Root가 설정되지 않았습니다");
				return;
			}

			if (!_buttonPrefab)
			{
				Debug.LogError(gameObject.name + "의 button Prefab이 설정되지 않았습니다");
				return;
			}
			
			GenerateButtonInstance(shopItems.Count);
			_currentShopItems = shopItems;

			for (int i = 0; i < _buttonPool.Count; i++)
			{
				if (i >= shopItems.Count)
				{
					_buttonPool[i].gameObject.SetActive(false);
					continue;
				}
				
				var shopItem = shopItems[i];
				var button = _buttonPool[i];

				button.SetItemNameText(shopItem.ItemData.ItemName);
				button.SetItemQuantityText(shopItem.Quantity.ToString());
				button.SetPriceText(shopItem.Price.ToString());
			}
		}

		void GenerateButtonInstance(int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (i < _buttonPool.Count)
				{
					_buttonPool[i].gameObject.SetActive(true);
					continue;
				}

				var button = Instantiate(_buttonPrefab, _contentRoot);
				int capturedIndex = i;
				button.PurchaseButtonClicked += () => OnPurchaseButtonClicked(capturedIndex);
				_buttonPool.Add(button);
			}
		}

		void OnPurchaseButtonClicked(int index)
		{
			if (index < 0 || index >= _buttonPool.Count)
			{
				Debug.LogError("버튼 인덱스가 유효하지 않음: " + index);
				return;
			}

			// 현재 활성화된 버튼의 인덱스에 해당하는 shopItem을 이벤트로 전달하기 위해
			// UpdateAllItems 호출 시 shopItems를 캐싱해야 하므로 _currentShopItems를 유지
			if (index < _currentShopItems.Count)
			{
				PurchaseButtonClicked?.Invoke(_currentShopItems[index]);
			}
		}
	}

}
