using System;
using UI.Presentation.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Presentation.Screens.TitleScreen
{

	[Serializable]
	public class TitleScreenTouchAreaView : UIView
	{
		[SerializeField] private Button _touchAreaButton;
		
		public event Action Touched;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_touchAreaButton.onClick.AddListener(OnTouchAreaClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_touchAreaButton.onClick.RemoveListener(OnTouchAreaClicked);
		}
		
		void OnTouchAreaClicked()
		{
			Touched?.Invoke();
		}
	}

}