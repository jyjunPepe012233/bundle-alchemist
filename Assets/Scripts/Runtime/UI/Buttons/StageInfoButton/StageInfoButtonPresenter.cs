using UnityEngine;

public class StageInfoButtonPresenter : UIPresenter<StageInfoButtonView>
{
	// 버튼이 오른쪽에 있는지 여부
	// 버튼이 오른쪽에 있으면 왼쪽 모달이 사용됨 
	[SerializeField] private bool _isRightSide;
	
	
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
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked?.Invoke(_stage, _isRightSide);
	}
}
