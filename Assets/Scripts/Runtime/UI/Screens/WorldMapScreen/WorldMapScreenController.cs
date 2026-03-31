using TMPro;
using UnityEngine;

public class WorldMapScreenController : MonoBehaviour
{
	[SerializeField] private string _chapterNameFormat = "침략 ({0})";
	[SerializeField] private TextMeshProUGUI _chapterNameText;
	
	[SerializeField] private StageInfoModalPresenter _stageInfoModalRight;
	[SerializeField] private StageInfoModalPresenter _stageInfoModalLeft;

	private bool _isStageInfoModalOpen;

	public void Awake()
	{
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked += OnStageInfoButtonClicked;
		
		_stageInfoModalRight.Hide();
		_stageInfoModalLeft.Hide();
	}

	public void OnDestroy()
	{
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked -= OnStageInfoButtonClicked;
	}

	private void OnStageInfoButtonClicked(StageSO stage, bool isRightSide)
	{
		if (_isStageInfoModalOpen)
		{
			_stageInfoModalRight.Hide();
			_stageInfoModalLeft.Hide();
			_isStageInfoModalOpen = false;
		}
		else
		{
			// 오른쪽에 있는 버튼이 클릭되면 왼쪽 모달을 사용함
			var stageModal = isRightSide ? _stageInfoModalLeft : _stageInfoModalRight;
			
			stageModal.InitializeStageInfo(stage);
			stageModal.Show();
			_isStageInfoModalOpen = true;
		}
	}
	
	public void InitializeChapter(ChapterSO chapter)
	{
		UpdateChapterName(chapter.ChapterName);
	}
	
	private void UpdateChapterName(string chapterName)
	{
		_chapterNameText.text = string.Format(_chapterNameFormat, chapterName);
	}
}
