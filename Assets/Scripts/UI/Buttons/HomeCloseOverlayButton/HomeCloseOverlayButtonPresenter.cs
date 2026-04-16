using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using ProjectB.UI.Screens.Home;

namespace ProjectB.UI.Buttons.HomeCloseOverlayButton
{

	public class HomeCloseOverlayButtonPresenter : UIPresenter<ButtonView>
	{
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
			HomeOverlaysController.CloseOverlay?.Invoke();
		}
	}

}
