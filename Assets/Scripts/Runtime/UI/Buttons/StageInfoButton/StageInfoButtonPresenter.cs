using UnityEngine;

public class StageInfoButtonPresenter : UIPresenter<StageInfoButtonView>
{
	[SerializeField] private StageSO _stage;
	
	private InvasionLevelQueryService _invasionModel;
	
	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();
		view.ButtonClicked += OnButtonClicked;

		_invasionModel = InvasionLevelQueryService.Inject();
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		view.ButtonClicked -= OnButtonClicked;
	}

	protected override void InitializeView()
	{
		base.InitializeView();
		
		_invasionModel.GetLevelsOfStage(_stage, out int chapterLevel, out int stageLevel);
		view.InitializeStageInfo(chapterLevel, stageLevel, _stage.StageName);
	}

	private void OnButtonClicked()
	{
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked?.Invoke(_stage);
	}
}
