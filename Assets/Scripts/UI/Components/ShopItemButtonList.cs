using System;
using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class ShopItemButtonList : MonoBehaviour
	{
		[SerializeField] private Transform _contentRoot;
		[SerializeField] private ItemPurchaseButton _buttonPrefab;

		private readonly List<ItemPurchaseButton> _buttonInstances = new List<ItemPurchaseButton>();
		
		// CreateAllItems 호출 시 ShopItem 배열을 이 변수에 저장하여
		// 버튼이 클릭되었을 때 버튼의 인덱스를 통해 특정 ShopItem을 이벤트로 전달함
		private IReadOnlyList<IShopItem> _currentShopItems;

		public event Action<IShopItem> PurchaseButtonClicked;

		public void InitializeAllItems(IReadOnlyList<IShopItem> shopItems)
		{
			foreach (var button in _buttonInstances)
			{
				Destroy(button.gameObject);
			}
			_buttonInstances.Clear();
			
			
			
			_currentShopItems = shopItems;

			for (int i = 0; i < _currentShopItems.Count; i++)
			{
				var button = Instantiate(_buttonPrefab, _contentRoot);
				int capturedIndex = i;
				button.PurchaseButtonClicked += () => OnPurchaseButtonClicked(capturedIndex);
				
				var shopItem = shopItems[i];
				
				button.SetItemNameText(shopItem.ItemData.ItemName);
				button.SetItemQuantityText(shopItem.Quantity.ToString());
				button.SetPriceText(shopItem.Price.ToString());
				button.SetBackground128(shopItem.ItemData.ItemTier.BackgroundPrefab128);	
				
				_buttonInstances.Add(button);
			}
		}
		
		void OnPurchaseButtonClicked(int index)
		{
			if (index < 0 || index >= _currentShopItems.Count)
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
