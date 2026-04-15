using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;

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
		}
	}

}
