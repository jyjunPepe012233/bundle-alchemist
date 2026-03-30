public class GameSceneManager : ILoadGameScenes
{
	private const string HOME_SCENE_NAME = "Home";

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

	public void LoadHome()
	{
		var loadingContextHolder = new SceneLoadingContextHolder(HOME_SCENE_NAME);
		CommandBuffer.AddCommand(new LoadingCommands.StartLoadingCommand(loadingContextHolder));
	}
}
