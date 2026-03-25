using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class WorldMapButtonView : UIView
{
	[SerializeField] private Button _button;

	public event Action ButtonClicked;
	
	public override void RegisterUICallbacks()
	{
		base.RegisterUICallbacks();
		
		_button.onClick.AddListener(OnButtonClicked);
	}

	public override void Dispose()
	{
		base.Dispose();
		
		_button.onClick.RemoveListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		ButtonClicked?.Invoke();
	}
}
