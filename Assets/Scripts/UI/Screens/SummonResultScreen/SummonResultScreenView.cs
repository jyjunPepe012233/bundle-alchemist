using System;
using System.Collections.Generic;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Screens.SummonResultOverlay
{

	[Serializable]
	public class SummonResultScreenView : UIView
	{
		[SerializeField] private SimpleSoldierCardList _soldierCardList;
		[SerializeField] private Button _closeButton;
		[SerializeField] private Button _summonAgainButton;
		
		public event Action CloseButtonClicked;
		public event Action SummonAgainButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_closeButton.onClick.AddListener(OnCloseButtonClicked);
			_summonAgainButton.onClick.AddListener(OnSummonAgainButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_closeButton.onClick.RemoveListener(OnCloseButtonClicked);
			_summonAgainButton.onClick.RemoveListener(OnSummonAgainButtonClicked);
		}

		void OnCloseButtonClicked()
		{
			CloseButtonClicked?.Invoke();
		}

		void OnSummonAgainButtonClicked()
		{
			SummonAgainButtonClicked?.Invoke();
			
		}

		public void UpdateSummonedSoldiers(IReadOnlyList<ISoldierData> summonedSoldiers)
		{
			_soldierCardList.UpdateAllSoldiers(summonedSoldiers);
		}
	}

}