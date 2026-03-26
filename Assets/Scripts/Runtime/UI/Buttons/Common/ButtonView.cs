using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ButtonView : UIView
{
	[SerializeField]
	private Button _button;
	
	public event Action ButtonClicked;

	public override void RegisterUICallbacks()
	{
		base.RegisterUICallbacks();
		
		if (_button == null)
		{
			Debug.LogError($"[{nameof(ButtonView)}] Button 컴포넌트가 할당되지 않았습니다.");
			return;
		}
		
		_button.onClick.AddListener(OnButtonClicked);
	}

	public override void Dispose()
	{
		base.Dispose();
		
		if (_button == null)
			return;
		
		_button.onClick.RemoveListener(OnButtonClicked);
	}
	
	private void OnButtonClicked()
	{
		ButtonClicked?.Invoke();
	}
}
