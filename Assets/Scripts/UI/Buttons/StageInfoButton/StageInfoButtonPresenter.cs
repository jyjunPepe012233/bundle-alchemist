using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Dependency.Installers.Data;
using ProjectB.UI.Core;
using ProjectB.UI.Screens.WorldMapScreen;
using UnityEngine;

namespace ProjectB.UI.Buttons.StageInfoButton
{

	public class StageInfoButtonPresenter : UIPresenter<StageInfoButtonView>
	{
		[SerializeField] private InterfaceRef<IStageData> _stage;
		[SerializeField] private InvasionSettingInstaller _invasionSettingInstaller;
		
		// 버튼이 오른쪽에 있는지 여부
		// 버튼이 오른쪽에 있으면 왼쪽 모달이 사용됨 
		[SerializeField] private bool _isRightSide;
		
	
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

		protected override void InitializeView()
		{
			base.InitializeView();
			

			_invasionSettingInstaller.Port.GetLevelsOfStage(_stage.Value, out int chapterLevel, out int stageLevel);
			view.InitializeStageInfo(chapterLevel, stageLevel, _stage.Value.StageName);
		}

		private void OnButtonClicked()
		{
			StageInfoButtonEvents.Clicked?.Invoke(_stage.Value, _isRightSide);
		}
	}

}
