using ProjectB.Data.Runtime.Player;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	public class SoldierDetailScreenPresenter : UIPresenter<SoldierDetailScreenView>
	{
		[SerializeField] private SoldierDetailServicePortInstaller _soldierDetailServicePortInstaller;
		[SerializeField] private SoldierLevelUpServicePortInstaller _soldierLevelUpServicePortInstaller;

		private IReadOnlyPlayerSoldier _data;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ConsumeFoodButtonClicked += OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback += OnSoldierDataUpdateCallback;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ConsumeFoodButtonClicked -= OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback -= OnSoldierDataUpdateCallback;
		}

		void OnConsumeFoodButtonClicked()
		{
			_soldierLevelUpServicePortInstaller.Port.ConsumeFoods(_data.SoldierId);
		}

		void OnSoldierDataUpdateCallback(IReadOnlyPlayerSoldier playerSoldier)
		{
			UpdateData(playerSoldier);
		}

		void UpdateData(IReadOnlyPlayerSoldier playerSoldier)
		{
			_data = playerSoldier;

			int consumeFoodAmount = _soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(playerSoldier.SoldierId);
			view.SetConsumeFoodAmount(consumeFoodAmount);
		}
	}

}