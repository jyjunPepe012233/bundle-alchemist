using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using ProjectB.UI.Screens.Home;
using UnityEngine;

namespace ProjectB.UI.Buttons.HomeOpenOverlayButton
{

	public class HomeOpenOverlayButtonPresenter : UIPresenter<ButtonView>
	{
		[SerializeField] private string _overlayID;
	
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

		private void OnButtonClicked()
		{
			HomeOverlaysController.OpenOverlay?.Invoke(_overlayID);
		}
	}

}
