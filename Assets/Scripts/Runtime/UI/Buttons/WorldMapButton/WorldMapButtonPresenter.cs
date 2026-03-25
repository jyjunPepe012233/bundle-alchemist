public class WorldMapButtonPresenter : UIPresenter<WorldMapButtonView>
{
	private ILoadGameScenes _gameSceneLoader = GameSceneManager.Singleton;
	
	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();

		view.ButtonClicked += OnButtonClicked;
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		
		view.ButtonClicked -= OnButtonClicked;
	}

	private void OnButtonClicked()
	{
		_gameSceneLoader.LoadWorldMapScreen();
	}
}
