using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.GemLabel
{

	public class GemLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().GemsChanged += OnGemsChanged;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().GemsChanged -= OnGemsChanged;
		}

		void OnGemsChanged()
		{
			UpdateGem();
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			UpdateGem();
		}

		void UpdateGem()
		{
			view.SetText(_playerDataServicePortInstaller.Port.GetPlayerData().Gems.ToString());
		}
	}

}
