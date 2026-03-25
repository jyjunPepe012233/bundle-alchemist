using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
	private IProvideTouchInfo _touchInfoProvider;
	private ILoadGameScenes _loadGameScenes;

	public void Awake()
	{
		_touchInfoProvider = ClickService.Singleton;
		_loadGameScenes = GameSceneManager.Singleton;

		_touchInfoProvider.TouchBegan += OnTouchBegan;
	}
	
	public void OnDestroy()
	{
		_touchInfoProvider.TouchBegan -= OnTouchBegan;
	}
	
	private void OnTouchBegan(Touch touch)
	{
		_loadGameScenes.LoadLobby();
		_touchInfoProvider.TouchBegan -= OnTouchBegan;
	}
}
