using ProjectB.Dependency.Installers.Summon;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.SummonButton
{

	public enum SummonButtonType
	{
		Summon1x,
		Summon10x
	}
	

	public class SummonButtonPresenter : UIPresenter<ButtonView>
	{
		[SerializeField] private SummonButtonType _type;
		
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
			if (_type == SummonButtonType.Summon1x)
			{
				_summonServicePortInstaller.Port.Summon1x();
			}
			else if (_type == SummonButtonType.Summon10x)
			{
				_summonServicePortInstaller.Port.Summon10x();
			}
		}
	}

}