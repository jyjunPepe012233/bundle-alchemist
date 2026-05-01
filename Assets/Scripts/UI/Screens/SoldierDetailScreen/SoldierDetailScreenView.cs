using System;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{
	
	[Serializable]
	public class SoldierDetailScreenView : UIView
	{
		[SerializeField] private LevelUpPageView _levelUpPageView; // 외부에서 사용할 수 있게 해야함.
		
		public event Action ConsumeFoodButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_levelUpPageView.ConsumeFoodButtonClicked += ConsumeFoodButtonClicked;
		}

		public override void Dispose()
		{
			base.Dispose();
			_levelUpPageView.ConsumeFoodButtonClicked -= ConsumeFoodButtonClicked;
		}
		
		public void SetConsumeFoodAmount(int amount)
		{
			_levelUpPageView.SetConsumeFoodAmount(amount);
		}
	}

}