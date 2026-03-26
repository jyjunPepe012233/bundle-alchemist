using UnityEngine;

public interface IHomeOverlay
{
	string OverlayID { get; }

	// 오버레이가 처음 열릴 때 호출됨
	void Open();

	// 오버레이가 화면에서 사라질 때 호출됨 (예: 다른 오버레이가 열려 덮어씌워짐)
	void Hide();

	// 오버레이가 다시 화면에 나타날 때 호출됨 (예: 덮어씌웠던 오버레이가 닫혀 다시 보임)
	void Show();
	
	// 오버레이가 완전히 닫힐 때 호출됨
	void Close();
}

public class HomeOverlay : MonoBehaviour, IHomeOverlay
{
	[SerializeField] private HomeUIController _homeUIController;
	[SerializeField] private GameObject _topElement;
	
	[SerializeField] private string _overlayID;
	public string OverlayID => _overlayID;

	public void Awake()
	{
		_homeUIController?.RegisterOverlay(this);
	}
	
	public void Open()
	{
		if (_topElement == null)
		{
			Debug.LogWarning($"[{nameof(HomeOverlay)}] Top Element가 할당되지 않았습니다.");
			return;
		}
		
		_topElement.SetActive(true);
	}

	public void Hide()
	{
		if (_topElement == null)
		{
			Debug.LogWarning($"[{nameof(HomeOverlay)}] Top Element가 할당되지 않았습니다.");
			return;
		}
		
		_topElement.SetActive(false);
	}

	public void Show()
	{
		if (_topElement == null)
		{
			Debug.LogWarning($"[{nameof(HomeOverlay)}] Top Element가 할당되지 않았습니다.");
			return;
		}
		
		_topElement.SetActive(true);
	}

	public void Close()
	{
		if (_topElement == null)
		{
			Debug.LogWarning($"[{nameof(HomeOverlay)}] Top Element가 할당되지 않았습니다.");
			return;
		}
		
		_topElement.SetActive(false);
	}
}
