using TMPro;
using UnityEngine;

public class WorldMapScreenController : MonoBehaviour
{
	[SerializeField] private string _chapterNameFormat = "침략 ({0})";
	[SerializeField] private TextMeshProUGUI _chapterNameText;
	
	[SerializeField] private StageInfoModalPresenter _stageInfoModalRight;
	[SerializeField] private StageInfoModalPresenter _stageInfoModalLeft;
	
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
		// StageInfoModal 스스로 UI를 닫을 수 있으므로
		// 본 클래스의 내부적인 상태가 아닌 Modal의 실제 상태를 참조하여 모달이 열려있는지 확인해야 했음
		if (_stageInfoModalRight.IsOpen || _stageInfoModalLeft.IsOpen)
		{
			_stageInfoModalRight.Hide();
			_stageInfoModalLeft.Hide();
		}
		else
		{
			// 오른쪽에 있는 버튼이 클릭되면 왼쪽 모달을 사용함
			var stageModal = isRightSide ? _stageInfoModalLeft : _stageInfoModalRight;
			
			stageModal.InitializeStageInfo(stage);
			stageModal.Show();
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
