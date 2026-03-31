public class StageInfoModalPresenter : UIPresenter<StageInfoModalView>
{
	public bool IsOpen { get; private set; }
	
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

	public void InitializeStageInfo(StageSO stage)
	{
		view.InitializeStageInfo(stage.StageName);
	}
}
