using UnityEngine;

namespace ProjectB.UI.Screens.Home
{
	// 260416-010025 현재 TitleScreen에서 Home으로 넘어가는 거 까지 개발했음.
	// Home에서 오버레이들 껐다 키는 시스템을 DI 구조 기반으로 리팩토링 할 차례임
			
	// 일단, homeUIController를 여기서 참조하지 못하게 하고 
	// 인스펙터에서 오버레이를 HomeUIController에 직접 등록할 수 있도록 변경하기
			
	// 그 뒤에 일단 오버레이 시스템 돌아가게 만들기
			
	// 오버레이 돌아가면 코드베이스 싹 훓고, 추가 개발 들어가면 됨(덱 편성 화면부터 개발하면 될 듯)
	
	// ㄴ 260416-214947 오버레이 시스템 어떻게 리팩토링 할 지 생각 했음?

	public class HomeFullScreenOverlay : MonoBehaviour, IHomeFullScreenOverlay
	{
		[SerializeField] private GameObject _topElement;
	
		[SerializeField] private string _overlayID;
		public string OverlayID => _overlayID;
		
	
		public void Open()
		{
			if (_topElement == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] Top Element가 할당되지 않았습니다.");
				return;
			}
		
			_topElement.SetActive(true);
		}

		public void Hide()
		{
			if (_topElement == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] Top Element가 할당되지 않았습니다.");
				return;
			}
		
			_topElement.SetActive(false);
		}

		public void Show()
		{
			if (_topElement == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] Top Element가 할당되지 않았습니다.");
				return;
			}
		
			_topElement.SetActive(true);
		}

		public void Close()
		{
			if (_topElement == null)
			{
				Debug.LogWarning($"[{nameof(HomeFullScreenOverlay)}] Top Element가 할당되지 않았습니다.");
				return;
			}
		
			_topElement.SetActive(false);
		}
	}

}