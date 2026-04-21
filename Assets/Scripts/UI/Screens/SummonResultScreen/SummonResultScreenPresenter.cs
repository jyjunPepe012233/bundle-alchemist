using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Types;
using ProjectB.Dependency.Installers.Summon;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SummonResultOverlay
{

	public class SummonResultScreenPresenter : UIPresenter<SummonResultScreenView>
	{
		[SerializeField]
		private SummonServicePortInstaller _summonServicePortInstaller;
		
		private SummonType _currentSummonType;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.CloseButtonClicked += OnCloseButtonClicked;
			view.SummonAgainButtonClicked += OnSummonAgainButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.CloseButtonClicked -= OnCloseButtonClicked;
			view.SummonAgainButtonClicked -= OnSummonAgainButtonClicked;
		}
		
		void OnCloseButtonClicked()
		{
			// Close Button은 HomeCloseOverlayButton으로 대체됨
//			view.Hide();
		}

		void OnSummonAgainButtonClicked()
		{
			_summonServicePortInstaller.Port.Summon(_currentSummonType);
		}

		public void SetSummonResult(SummonResult result)
		{
			_currentSummonType = result.type;
			
			view.UpdateSummonedSoldiers(result.summonedSoldiers);
		}
	}

}