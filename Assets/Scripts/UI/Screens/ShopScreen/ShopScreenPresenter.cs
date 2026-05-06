using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Shop;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.ShopPageNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.ShopScreen
{

	public class ShopScreenPresenter : UIPresenter<ShopScreenView>
	{
		[SerializeField] private InterfaceRef<IShopSetting> _shopSetting;
		[SerializeField] private ShopServiceInstaller _shopServiceInstaller;

		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			
			ShopPageNavigateButtonEvents.Clicked += OnShopPageNavigateButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			
			ShopPageNavigateButtonEvents.Clicked -= OnShopPageNavigateButtonClicked;
		}
		
		void OnShopPageNavigateButtonClicked(string pageId)
		{
			var pageData = _shopSetting.Value.ShopPages.FirstOrDefault(page => page.ShopPageId == pageId);
			if (pageData != null)
			{
				view.OpenPage(pageData);
			}
			else
			{
				Debug.LogError("해당 페이지 ID에 대한 페이지 데이터를 찾을 수 없습니다: " + pageId);
			}
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			view.InitializeShopPages(_shopSetting.Value.ShopPages);
			
			// IEnumerator는 사용 후 Dispose 해야 하므로 using문 사용 
			using var enumerator = _shopSetting.Value.ShopPages.GetEnumerator();
			view.OpenPage(enumerator.Current); // 첫 번째 페이지를 기본으로 열도록 설정. 필요에 따라 다른 페이지를 열도록 수정 가능
		}
	}

}