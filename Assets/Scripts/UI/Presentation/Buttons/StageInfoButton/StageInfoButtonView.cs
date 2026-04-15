using System;
using TMPro;
using UI.Presentation.Buttons.Common;
using UnityEngine;

namespace UI.Presentation.Buttons.StageInfoButton
{

	[Serializable]
	public class StageInfoButtonView : ButtonView
	{
		[SerializeField] private string _stageLevelFormat = "{0}-{1}";
		[SerializeField] private TextMeshProUGUI _stageLevelText;
		[SerializeField] private TextMeshProUGUI _stageNameText;

		public void InitializeStageInfo(int chapterNumber, int stageNumber, string stageName)
		{
			_stageLevelText.text = string.Format(_stageLevelFormat, chapterNumber, stageNumber);
			_stageNameText.text = stageName;
		}
	}

}