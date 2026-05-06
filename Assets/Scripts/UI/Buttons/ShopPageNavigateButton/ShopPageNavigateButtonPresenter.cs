using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.ShopPageNavigateButton
{

	public class ShopPageNavigateButtonPresenter : UIPresenter<ButtonView>
	{
		[SerializeField] private string _pageId;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ButtonClicked += OnButtonClicked;
		}
		
		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ButtonClicked -= OnButtonClicked;
		}
		
		void OnButtonClicked()
		{
			ShopPageNavigateButtonEvents.Clicked?.Invoke(_pageId);
		}
	}

}