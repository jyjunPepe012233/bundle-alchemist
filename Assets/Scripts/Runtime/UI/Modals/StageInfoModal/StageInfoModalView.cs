using System;
using TMPro;
using UnityEngine;

[Serializable]
public class StageInfoModalView : UIView
{
	[SerializeField] private TextMeshProUGUI _stageNameText;
	
	public void InitializeStageInfo(string stageName)
	{
		_stageNameText.text = stageName;
	}
}
