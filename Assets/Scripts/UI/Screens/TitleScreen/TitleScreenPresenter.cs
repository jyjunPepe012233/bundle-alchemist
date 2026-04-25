using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.TitleScreen
{

	public class TitleScreenPresenter : UIPresenter<TitleScreenTouchAreaView>
	{
		[SerializeField]
		private TitleScreenManagerPortInstaller _titleScreenManagerPortInstaller;

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
			_titleScreenManagerPortInstaller.Port.Touched();
		}
	}

}
