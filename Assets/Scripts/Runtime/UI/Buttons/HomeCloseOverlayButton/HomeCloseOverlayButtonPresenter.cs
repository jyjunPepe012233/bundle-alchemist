public class HomeCloseOverlayButtonPresenter : UIPresenter<ButtonView>
{
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
		HomeUIEventBus.CloseOverlay?.Invoke();
	}
}
