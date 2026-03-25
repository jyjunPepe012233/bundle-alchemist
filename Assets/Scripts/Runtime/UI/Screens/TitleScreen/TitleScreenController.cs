using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
	private IProvideTouchInfo _touchInfoProvider;
	private ILoadGameScenes _loadGameScenes;

	public void Awake()
	{
		_touchInfoProvider = ClickService.Singleton;
		_touchInfoProvider.TouchBegan += OnTouchBegan;

		_loadGameScenes = GameSceneManager.Singleton;
	}
	
	private void OnTouchBegan(Touch touch)
	{
		_loadGameScenes.LoadLobby();
	}
}
