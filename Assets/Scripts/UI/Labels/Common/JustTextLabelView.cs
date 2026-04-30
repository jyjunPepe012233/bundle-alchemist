using System;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Labels.Common
{

	[Serializable]
	public class JustTextLabelView : UIView
	{
		[SerializeField] private TextMeshProUGUI _tmp;

		public void SetText(string text)
		{
			_tmp.text = text;
		}
	}

}