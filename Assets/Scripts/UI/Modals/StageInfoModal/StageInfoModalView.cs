using System;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Modals.StageInfoModal
{

	[Serializable]
	public class StageInfoModalView : UIView
	{
		[SerializeField] private Button _closeButton;

		[SerializeField] private TextMeshProUGUI _stageNameText;

		public event Action CloseButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_closeButton?.onClick.AddListener(OnCloseButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_closeButton?.onClick.RemoveListener(OnCloseButtonClicked);
		}

		private void OnCloseButtonClicked()
		{
			CloseButtonClicked?.Invoke();
		}

		public void InitializeStageInfo(string stageName)
		{
			_stageNameText.text = stageName;
		}
	}

}
