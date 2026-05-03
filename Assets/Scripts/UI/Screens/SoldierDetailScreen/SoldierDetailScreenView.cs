using System;
using ProjectB.Data.Static.SoldierRole;
using ProjectB.Data.Static.Spirit;
using ProjectB.UI.Components;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{
	
	[Serializable]
	public class SoldierDetailScreenView : UIView
	{
		// 페이지는 외부에서 사용할 수 있게 함

		[SerializeField] private PrefabIconParent _spiritIconParent;
		[SerializeField] private PrefabIconParent _soldierRoleIconParent;
		
		[Header("Pages")]
		
		[SerializeField] private InfoPageView _infoPageView;
		public InfoPageView InfoPageView => _infoPageView;
		
		[SerializeField] private LevelUpPageView _levelUpPageView;
		public LevelUpPageView LevelUpPageView => _levelUpPageView;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_infoPageView.RegisterUICallbacks();
			_levelUpPageView.RegisterUICallbacks();
		}

		public override void Dispose()
		{
			base.Dispose();
			_infoPageView.Dispose();
			_levelUpPageView.Dispose();
		}
		
		public void SetSpiritIcon(ISpiritData spirit)
		{
			_spiritIconParent.SetIcon(spirit.IconPrefab64);
		}
		
		public void SetSoldierRoleIcon(ISoldierRoleData soldierRole)
		{
			_soldierRoleIconParent.SetIcon(soldierRole.IconPrefab64);
		}
	}

}