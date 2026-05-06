using System;
using System.Collections.Generic;
using System.Linq;
using ProjectB.Data.Static.ShopPage;
using ProjectB.UI.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectB.UI.Screens.ShopScreen
{

	[Serializable]
	public class ShopScreenView : UIView
	{
		[SerializeField] private ShopPageView _shopPageViewPrefab;
		[SerializeField] private Transform _shopPageParent;

		private List<(ShopPageView pageView, IShopPage pageData)> _shopPageInstances;

		public void InitializeShopPages(IEnumerable<IShopPage> shopPageData)
		{ 
			foreach (var pageData in shopPageData)
			{
				var pageView = Object.Instantiate(_shopPageViewPrefab, _shopPageParent);
				pageView.CreateShopItems(pageData.ShopItems.ToArray()); // 메서드가 IReadOnlyList를 요구하므로 배열로 변환하여 전달
				_shopPageInstances.Add((pageView, pageData));
			}
		}

		public void OpenPage(IShopPage pageData)
		{
			var pageInstance = _shopPageInstances.FirstOrDefault(instance => instance.pageData == pageData);
			if (pageInstance.pageView != null)
			{
				pageInstance.pageView.gameObject.SetActive(true);
			}
			else
			{
				Debug.LogError("해당 페이지 데이터에 대한 페이지 뷰 인스턴스를 찾을 수 없습니다: " + pageData.ShopPageId);
			}
		}
	}

}