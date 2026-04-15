using UI.Presentation.Buttons.Common;
using UI.Presentation.Core;
using UnityEngine;

namespace UI.Presentation.Buttons.HomeOpenOverlayButton
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
		}
	}

}
