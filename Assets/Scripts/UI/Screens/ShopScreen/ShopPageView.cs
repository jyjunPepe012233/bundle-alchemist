using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;
using ProjectB.UI.Components;
using UnityEngine;

namespace ProjectB.UI.Screens.ShopScreen
{

	public class ShopPageView : MonoBehaviour
	{
		[SerializeField] private ShopItemButtonList _shopItemButtonList;
		
		public void CreateShopItems(IReadOnlyList<IShopItem> shopItems)
		{
			_shopItemButtonList.CreateAllItems(shopItems);
		}
	}

}