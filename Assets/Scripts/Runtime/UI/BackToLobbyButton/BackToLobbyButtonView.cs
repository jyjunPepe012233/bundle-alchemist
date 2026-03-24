using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BackToLobbyButtonView
{
	[SerializeField] private Button _button;
	
	public event Action ButtonClicked;

	public void OnSetupUICallbacks()
	{
		if (_button == null)
		{
			Debug.LogError($"[{nameof(BackToLobbyButtonView)}] 버튼이 할당되지 않았음");
			return;
		}
		
		_button.onClick.AddListener(OnButtonClicked);
	}
	
	private void OnButtonClicked() => ButtonClicked?.Invoke();
}
