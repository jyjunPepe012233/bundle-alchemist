using System;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{
	
	[Serializable]
	public class SoldierDetailScreenView : UIView
	{
		// 페이지는 외부에서 사용할 수 있게 함
		
		[SerializeField] private InfoPageView _infoPageView;
		public InfoPageView InfoPageView => _infoPageView;
		
		[SerializeField] private LevelUpPageView _levelUpPageView;
		public LevelUpPageView LevelUpPageView => _levelUpPageView;
	}

}