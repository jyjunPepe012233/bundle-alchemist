using UI.Presentation.Buttons.Common;
using UI.Presentation.Core;

namespace UI.Presentation.Buttons.HomeCloseOverlayButton
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
