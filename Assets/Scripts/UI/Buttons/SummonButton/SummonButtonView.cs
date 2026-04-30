using System;
using ProjectB.UI.Buttons.Common;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Buttons.SummonButton
{

	[Serializable]
	public class SummonButtonView : ButtonView
	{
		[SerializeField] private TextMeshProUGUI _summonCostText;

		public void SetSummonCost(int cost)
		{
			_summonCostText.text = cost.ToString();
		}
	}

}