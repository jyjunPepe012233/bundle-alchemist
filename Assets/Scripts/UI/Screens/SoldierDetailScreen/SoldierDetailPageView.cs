using System;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	[Serializable]
	public class SoldierDetailPageView : UIView
	{
		[SerializeField] private string _pageId;
		public string PageId => _pageId;
	}

}