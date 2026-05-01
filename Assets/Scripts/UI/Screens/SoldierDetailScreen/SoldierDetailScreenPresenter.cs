using ProjectB.Data.Runtime.Player;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.SoldierDetailNavigateButton;
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
			view.LevelUpPageView.ConsumeFoodButtonClicked += OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback += OnSoldierDataUpdateCallback;
			
			SoldierDetailNavigateButtonEvents.Clicked += OnSoldierDetailNavigateButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.LevelUpPageView.ConsumeFoodButtonClicked -= OnConsumeFoodButtonClicked;

			_soldierDetailServicePortInstaller.Port.SoldierDataUpdateCallback -= OnSoldierDataUpdateCallback;
			
			SoldierDetailNavigateButtonEvents.Clicked -= OnSoldierDetailNavigateButtonClicked;
		}

		void OnConsumeFoodButtonClicked()
		{
			_soldierLevelUpServicePortInstaller.Port.ConsumeFoods(_data.SoldierId);
		}

		void OnSoldierDataUpdateCallback(IReadOnlyPlayerSoldier playerSoldier)
		{
			UpdateData(playerSoldier);
		}
		
		void OnSoldierDetailNavigateButtonClicked(string pageId)
		{
			void SetActivePage(SoldierDetailPageView page)
			{
				if (pageId == page.PageId)
				{
					page.Show();
				}
				else
				{
					page.Hide();
				}
			}
			
			SetActivePage(view.InfoPageView);
			SetActivePage(view.LevelUpPageView);
		}

		void UpdateData(IReadOnlyPlayerSoldier playerSoldier)
		{
			_data = playerSoldier;

			// 레벨업 페이지 업데이트
			int consumeFoodAmount = _soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(playerSoldier.SoldierId);
			view.LevelUpPageView.SetConsumeFoodAmount(consumeFoodAmount);
		}
	}

}