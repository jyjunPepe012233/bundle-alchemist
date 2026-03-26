using UnityEngine;

public class HomeOpenOverlayButtonPresenter : UIPresenter<ButtonView>
{
	[SerializeField] private string _overlayID;
	
	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();
		view.ButtonClicked += OnButtonClicked;
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		view.ButtonClicked -= OnButtonClicked;
	}

	private void OnButtonClicked()
	{
		HomeUIEventBus.OpenOverlay?.Invoke(_overlayID);
	}
}
