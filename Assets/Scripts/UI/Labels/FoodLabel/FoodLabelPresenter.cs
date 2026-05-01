using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using ProjectB.UI.Labels.Common;
using UnityEngine;

namespace ProjectB.UI.Labels.FoodLabel
{

	public class FoodLabelPresenter : UIPresenter<JustTextLabelView>
	{
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().FoodsChanged += OnFoodsChanged;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			_playerDataServicePortInstaller.Port.GetPlayerData().FoodsChanged -= OnFoodsChanged;
		}
		
		void OnFoodsChanged()
		{
			UpdateFood();
		}
		
		protected override void InitializeView()
		{
			base.InitializeView();
			UpdateFood();
		}
		
		void UpdateFood()
		{
			view.SetText(_playerDataServicePortInstaller.Port.GetPlayerData().Foods.ToString());
		}
	}

}