public class StageInfoModalPresenter : UIPresenter<StageInfoModalView>
{
	public bool IsOpen { get; private set; }

	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();
		view.CloseButtonClicked += OnCloseButtonClicked;
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		view.CloseButtonClicked -= OnCloseButtonClicked;
	}

	public override void Show()
	{
		base.Show();
		IsOpen = true;
	}

	public override void Hide()
	{
		base.Hide();
		IsOpen = false;
	}

	private void OnCloseButtonClicked()
	{
		Hide();
		IsOpen = false;
	}

	public void InitializeStageInfo(StageSO stage)
	{
		view.InitializeStageInfo(stage.StageName);
	}
}
