using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.SoldierDetailNavigateButton;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	public class SoldierDetailScreenPresenter : UIPresenter<SoldierDetailScreenView>
	{
		// TODO:
		// 이 클래스는 현재 병사 상세 정보 화면의 "모든 로직"을 담당하고 있음 
		// 병사 정보(_soldierData, _playerSoldierData)와 관련된 로직만 이 클래스가 담당하고
		// 정보를 바탕으로 화면을 업데이트하는 로직은 SoldierDetailScreenView가 담당하게 만들어도 됨
		
		// TODO:
		// 망했다 이 클래스 너무 방대함
		// 리팩토링 필요!!
		
		
		[SerializeField] private SoldierDatabaseInstaller _soldierDatabaseInstaller;
		[SerializeField] private SoldierDetailServicePortInstaller _soldierDetailServicePortInstaller;
		[SerializeField] private SoldierLevelUpServicePortInstaller _soldierLevelUpServicePortInstaller;

		private ISoldierData _soldierData;
		private IReadOnlyPlayerSoldier _playerSoldierData;

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
			_soldierLevelUpServicePortInstaller.Port.ConsumeFoods(_playerSoldierData.SoldierId);
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
			if (_playerSoldierData != null)
			{
				UnsubscribePlayerSoldierData();
			}
			
			_playerSoldierData = playerSoldier;
			SubscribePlayerSoldierData();
			
			_soldierData = _soldierDatabaseInstaller.Port.GetSoldierById(playerSoldier.SoldierId);


			// 레벨업 페이지 업데이트
			var nextStatus = _soldierLevelUpServicePortInstaller.Port.GetNextLevelStatus(playerSoldier.SoldierId);
			view.LevelUpPageView.SetStatus(_playerSoldierData.Status, nextStatus);
			
			view.LevelUpPageView.SetCurrentLevel(_playerSoldierData.Level);
			view.LevelUpPageView.SetCurrentExperience(_playerSoldierData.Exp);
			view.LevelUpPageView.SetTargetExperience(_soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(_playerSoldierData.Level));
			view.LevelUpPageView.SetConsumeFoodAmount(_soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(playerSoldier.SoldierId));
		}

		void SubscribePlayerSoldierData()
		{
			_playerSoldierData.ExpChanged += OnPlayerSoldierExpChanged;
			_playerSoldierData.LevelChanged += OnPlayerSoldierLevelChanged;
			_playerSoldierData.StatusChanged += OnPlayerSoldierStatusChanged;
		}

		void UnsubscribePlayerSoldierData()
		{
			_playerSoldierData.ExpChanged -= OnPlayerSoldierExpChanged;
			_playerSoldierData.LevelChanged -= OnPlayerSoldierLevelChanged;
			_playerSoldierData.StatusChanged -= OnPlayerSoldierStatusChanged;
		}

		void OnPlayerSoldierExpChanged()
		{
			view.LevelUpPageView.SetCurrentExperience(_playerSoldierData.Exp);
		}

		void OnPlayerSoldierLevelChanged()
		{
			view.LevelUpPageView.SetCurrentLevel(_playerSoldierData.Level);
			view.LevelUpPageView.SetTargetExperience(_soldierData.LevelUpExpSetting.GetLevelUpExpOfLevel(_playerSoldierData.Level));
			
			view.LevelUpPageView.SetConsumeFoodAmount(_soldierLevelUpServicePortInstaller.Port.GetConsumeFoodAmount(_playerSoldierData.SoldierId));
		}

		void OnPlayerSoldierStatusChanged()
		{
			var nextStatus = _soldierLevelUpServicePortInstaller.Port.GetNextLevelStatus(_playerSoldierData.SoldierId);
			view.LevelUpPageView.SetStatus(_playerSoldierData.Status, nextStatus);
		}
	}

}