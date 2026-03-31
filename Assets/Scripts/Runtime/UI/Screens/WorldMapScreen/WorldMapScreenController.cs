using TMPro;
using UnityEngine;

public class WorldMapScreenController : MonoBehaviour
{
	[SerializeField] private string _chapterNameFormat = "침략 ({0})";
	[SerializeField] private TextMeshProUGUI _chapterNameText;
	
	[SerializeField] private StageInfoModalPresenter _stageInfoModal;

	private bool _isStageInfoModalOpen;

	public void Awake()
	{
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked += OnStageInfoButtonClicked;
		
		_stageInfoModal.Hide();
	}

	public void OnDestroy()
	{
		HomeUIEventBus.WorldMapScreen.StageInfoButtonClicked -= OnStageInfoButtonClicked;
	}

	private void OnStageInfoButtonClicked(StageSO stage)
	{
		if (_stageInfoModal.IsOpen)
		{
			_stageInfoModal.Hide();
		}
		else
		{
			_stageInfoModal.InitializeStageInfo(stage);
			_stageInfoModal.Show();
		}
	}
}
