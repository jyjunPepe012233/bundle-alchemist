using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Shop;
using ProjectB.Data.Static.ShopPage;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Shop
{

	public class ShopSettingSO : UnityEngine.ScriptableObject, IShopSetting
	{
		[SerializeField] private InterfaceRefs<IShopPage> _shopPages;
		public IReadOnlyList<IShopPage> ShopPages => _shopPages.Value;
	}

}