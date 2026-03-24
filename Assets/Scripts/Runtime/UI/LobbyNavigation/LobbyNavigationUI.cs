using UnityEngine;

public class LobbyNavigationUI : MonoBehaviour
{
	[SerializeField] private LobbyNavigationView _view;
	
	private ILoadGameScenes _gameSceneLoader = GameSceneManager.Singleton;

	public void Awake()
	{
		_view.OnSetupUICallbacks();
		
		_view.SummonNavigatorClicked += OnSummonNavigatorClicked;
		_view.ShopNavigatorClicked += OnShopNavigatorClicked;
		_view.SoldierListNavigatorClicked += OnSoldierListNavigatorClicked;
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
