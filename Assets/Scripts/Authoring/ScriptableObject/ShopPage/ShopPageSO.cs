using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.ShopItem;
using ProjectB.Data.Static.ShopPage;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.ShopPage
{

	public class ShopPageSO : UnityEngine.ScriptableObject, IShopPage
	{
		[SerializeField] private string _shopPageId;
		public string ShopPageId => _shopPageId;
		
		[SerializeField] private string _shopPageName;
		public string ShopPageName => _shopPageName;

		[SerializeField] private InterfaceRefs<IShopItem> _shopItems;
		public IEnumerable<IShopItem> ShopItems => _shopItems.Value;
	}

}