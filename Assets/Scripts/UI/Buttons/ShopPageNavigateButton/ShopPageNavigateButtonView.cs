using System;
using ProjectB.UI.Buttons.Common;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Buttons.ShopPageNavigateButton
{

	[Serializable]
	public class ShopPageNavigateButtonView : ButtonView
	{
		[SerializeField] private TextMeshProUGUI _pageNameText;
		
		public void SetPageName(string pageName)
		{
			if (_pageNameText != null)
			{
				_pageNameText.text = pageName;
			}
			else
			{
				Debug.LogWarning("페이지 이름 텍스트 컴포넌트가 할당되지 않았습니다.");
			}
		}
	}

}