using UI.Installers;
using UI.Presentation.Core;
using UnityEngine;

namespace UI.Presentation.Screens.TitleScreen
{

	public class TitleScreenPresenter : UIPresenter<TitleScreenTouchAreaView>
	{
		[SerializeField]
		private TitleScreenTouchPortInstaller _titleScreenTouchPortInstaller;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.Touched += OnTouched;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.Touched -= OnTouched;
		}

		void OnTouched()
		{
			_titleScreenTouchPortInstaller.Port.Touched();
		}
	}

}
