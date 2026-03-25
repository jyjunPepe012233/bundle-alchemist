using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : ILoadGameScenes
{
	private const string LOBBY_SCENE_NAME = "Lobby";
	private const string SUMMON_SCREEN_SCENE_NAME = "SummonScreen";
	private const string SHOP_SCREEN_SCENE_NAME = "ShopScreen";
	private const string SOLDIER_LIST_SCREEN_SCENE_NAME = "SoldierListScreen";

	private static GameSceneManager _singleton;
	public static GameSceneManager Singleton
	{
		get
		{
			if (_singleton == null)
			{
				_singleton = new GameSceneManager();
			}
			return _singleton;
		}
	}
	
	private GameSceneManager()
	{
		// 외부에서 인스턴스 생성 불허
	}

	public void LoadLobby()
	{
		var loadingContextHolder = new SceneLoadingContextHolder(LOBBY_SCENE_NAME);
		LoadingTransitionEventBus.StartLoading?.Invoke(loadingContextHolder);
	}
	
	public void LoadSummonScreen()
	{
		SceneManager.LoadScene(SUMMON_SCREEN_SCENE_NAME);
	}

	public void LoadShopScreen()
	{
		SceneManager.LoadScene(SHOP_SCREEN_SCENE_NAME);
	}
	
	public void LoadSoldierListScreen()
	{
		SceneManager.LoadScene(SOLDIER_LIST_SCREEN_SCENE_NAME);
	}
}
