using ProjectB.UI.Modals.StageInfoModal;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.Screens.WorldMapScreen
{

	public class WorldMapScreenController : MonoBehaviour
	{
		[SerializeField] private string _chapterNameFormat = "침략 ({0})";
		[SerializeField] private TextMeshProUGUI _chapterNameText;
	
		[SerializeField] private StageInfoModalPresenter _stageInfoModalRight;
		[SerializeField] private StageInfoModalPresenter _stageInfoModalLeft;
	
//		private StageSO _lastStageInfo;
	
		public void Awake()
		{
//			HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked += OnStageInfoButtonClicked;
		
			_stageInfoModalRight.Hide();
			_stageInfoModalLeft.Hide();
		}

		public void OnDestroy()
		{
//			HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked -= OnStageInfoButtonClicked;
		}

//		private void OnStageInfoButtonClicked(StageSO stage, bool isRightSide)
//		{
//			if (_stageInfoModalRight.IsOpen || _stageInfoModalLeft.IsOpen)
//			{
//				_stageInfoModalRight.Hide();
//				_stageInfoModalLeft.Hide();
//
//				if (_lastStageInfo != stage)
//				{
//					_lastStageInfo = stage;
//					OpenStageInfoModal(stage, isRightSide);
//				}
//				else
//				{
//					_lastStageInfo = null;
//				}
//			}
//			else
//			{
//				_lastStageInfo = stage;
//				OpenStageInfoModal(stage, isRightSide);
//			}
//		}
//	
//		private void OpenStageInfoModal(StageSO stage, bool isRightSide)
//		{
//			var stageModal = isRightSide ? _stageInfoModalLeft : _stageInfoModalRight;
//		
//			stageModal.InitializeStageInfo(stage);
//			stageModal.Show();
//		
//			_lastStageInfo = stage;
//		}
//	
//		public void InitializeChapter(ChapterSO chapter)
//		{
//			UpdateChapterName(chapter.ChapterName);
//		}
	
		private void UpdateChapterName(string chapterName)
		{
			_chapterNameText.text = string.Format(_chapterNameFormat, chapterName);
		}
	}

}
