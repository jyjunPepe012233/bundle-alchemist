using ProjectB.Data.Types;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.SummonButton
{

	public class SummonButtonPresenter : UIPresenter<SummonButtonView>
	{
		[SerializeField] private SummonType _type;

		[SerializeField] private SummonCostSettingInstaller _summonCostSettingInstaller;
		[SerializeField] private SummonServicePortInstaller _summonServicePortInstaller;
		
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

		void OnButtonClicked()
		{
			_summonServicePortInstaller.Port.Summon(_type);
		}

		protected override void InitializeView()
		{
			base.InitializeView();

			var setting = _summonCostSettingInstaller.Port;
			
			switch (_type)
			{
				case SummonType.Summon1x: 
					view.SetSummonCost(setting.Price1x);
					break;
				
				case SummonType.Summon10x:
					view.SetSummonCost(setting.Price10x);
					break;
			}
		}
	}

}