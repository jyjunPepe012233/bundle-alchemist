using ProjectB.Data.Types;
using ProjectB.Dependency.Installers.Summon;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.SummonButton
{

	public class SummonButtonPresenter : UIPresenter<ButtonView>
	{
		[SerializeField] private SummonType _type;
		
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
	}

}