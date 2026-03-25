using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BackToLobbyButtonView : UIView
{
	[SerializeField] private Button _button;
	
	public event Action ButtonClicked;

	public override void RegisterUICallbacks()
	{
		base.RegisterUICallbacks();
		
		if (_button == null)
		{
			Debug.LogError($"[{nameof(BackToLobbyButtonView)}] 버튼이 할당되지 않았음");
			return;
		}
		
		_button.onClick.AddListener(OnButtonClicked);
	}

	public override void Dispose()
	{
		base.Dispose();
		
		if (_button == null)
		{
			Debug.LogError($"[{nameof(BackToLobbyButtonView)}] 버튼이 할당되지 않았음");
			return;
		}
		
		_button.onClick.RemoveListener(OnButtonClicked);
	}
	
	private void OnButtonClicked() => ButtonClicked?.Invoke();
}
