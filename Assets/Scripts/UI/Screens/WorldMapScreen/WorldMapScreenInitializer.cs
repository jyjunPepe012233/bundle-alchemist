using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using UnityEngine;

// 현재는 게임에 여러 개의 챕터가 존재하지 않으므로
// 임시적으로 WorldMapScreenInitializer를 통해 WorldMapScreen에 챕터 정보를 주입함

// 챕터가 여러 개로 늘어나면 챕터 선택 페이지를 통해 UI를 조작하면 될 것 같음

// 아직은 이 클래스 사용
namespace ProjectB.UI.Screens.WorldMapScreen
{

	public class WorldMapScreenInitializer : MonoBehaviour
	{
		[SerializeField] private WorldMapScreenController _worldMapScreenController;
		[SerializeField] private InterfaceRef<IChapterData> _chapter;
	
		public void Awake()
		{
			_worldMapScreenController.InitializeChapter(_chapter.Value);
		}
	}

}
