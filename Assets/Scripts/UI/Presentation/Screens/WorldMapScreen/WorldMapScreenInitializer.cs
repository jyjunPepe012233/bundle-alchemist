using UnityEngine;

// 현재는 게임에 여러 개의 챕터가 존재하지 않으므로
// WorldMapScreenInitializer를 통해 WorldMapScreen에 챕터 정보를 주입함
namespace UI.Presentation.Screens.WorldMapScreen
{

	public class WorldMapScreenInitializer : MonoBehaviour
	{
		[SerializeField] private WorldMapScreenController _worldMapScreenController;
//		[SerializeField] private ChapterSO _chapter;
	
		public void Awake()
		{
//			_worldMapScreenController.InitializeChapter(_chapter);
		}
	}

}
