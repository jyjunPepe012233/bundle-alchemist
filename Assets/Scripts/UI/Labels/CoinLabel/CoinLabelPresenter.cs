using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.CoinLabel
{

	public class CoinLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().CoinsChanged += OnCoinsChanged;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().CoinsChanged -= OnCoinsChanged;
		}

		void OnCoinsChanged()
		{
			UpdateCoin();
		}

		protected override void InitializeView()
		{
			base.InitializeView();
			UpdateCoin();
		}

		void UpdateCoin()
		{
			view.SetText(_playerDataServicePortInstaller.Port.GetPlayerData().Coins.ToString());
		}
	}

}