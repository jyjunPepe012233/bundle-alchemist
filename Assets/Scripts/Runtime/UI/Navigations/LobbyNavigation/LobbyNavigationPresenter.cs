public class LobbyNavigationPresenter : UIPresenter<LobbyNavigationView>
{
	private ILoadGameScenes _gameSceneLoader = GameSceneManager.Singleton;

	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();
		
		view.SummonNavigatorClicked += OnSummonNavigatorClicked;
		view.ShopNavigatorClicked += OnShopNavigatorClicked;
		view.SoldierListNavigatorClicked += OnSoldierListNavigatorClicked;
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		
		view.SummonNavigatorClicked -= OnSummonNavigatorClicked;
		view.ShopNavigatorClicked -= OnShopNavigatorClicked;
		view.SoldierListNavigatorClicked -= OnSoldierListNavigatorClicked;
	}

	private void OnSummonNavigatorClicked()
	{
		_gameSceneLoader.LoadSummonScreen();
	}
	
	private void OnShopNavigatorClicked()
	{
		_gameSceneLoader.LoadShopScreen();
	}
	
	private void OnSoldierListNavigatorClicked()
	{
		_gameSceneLoader.LoadSoldierListScreen();
	}
}
