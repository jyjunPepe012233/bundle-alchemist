using Gameplay.Ports;
using Gameplay.Ports.Outbound;
using UnityEngine;

public class GameSceneLoader : ILoadHomeScenePort
{
	private const string HOME_SCENE_NAME = "Home";
	
	private readonly LoadingTransitionManager _loadingTransitionManager;

	public GameSceneLoader(LoadingTransitionManager loadingTransitionManager)
	{
		_loadingTransitionManager = loadingTransitionManager;
	}

	public void LoadHome()
	{
		var loadingTask = new SceneLoadingTask(HOME_SCENE_NAME);
		_loadingTransitionManager.StartLoadingWithTransition(loadingTask);
	}
}
