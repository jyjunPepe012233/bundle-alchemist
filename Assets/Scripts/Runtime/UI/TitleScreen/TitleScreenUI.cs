using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
	private IProvideTouchInfo _touchInfoProvider;

	public void Awake()
	{
		_touchInfoProvider = ClickService.Singleton;
		_touchInfoProvider.TouchBegan += OnTouchBegan;
	}
	
	private void OnTouchBegan(Touch touch)
	{
		GameSceneManager.Singleton.LoadLobby();
	}
}
