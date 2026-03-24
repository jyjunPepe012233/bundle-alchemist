using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable] // unity 엔진에서 직렬화를 통해 객체를 자동 주입시키기 위함
public class LobbyNavigationView
{
	[SerializeField] private Button _summonNavigator;
	[SerializeField] private Button _shopNavigator;
	[SerializeField] private Button _soldierListNavigator;

	public event Action SummonNavigatorClicked;
	public event Action ShopNavigatorClicked;
	public event Action SoldierListNavigatorClicked;

	public void OnSetupUICallbacks()
	{
		if (_summonNavigator == null || _shopNavigator == null || _soldierListNavigator == null)
		{
			Debug.LogError($"[{nameof(LobbyNavigationView)}] 하나 이상의 네비게이터가 할당되지 않았음");
			return;
		}
		
		_summonNavigator.onClick.AddListener(OnSummonNavigatorClicked);
		_shopNavigator.onClick.AddListener(OnShopNavigatorClicked);
		_soldierListNavigator.onClick.AddListener(OnSoldierNavigatorClicked);
	}

	private void OnSummonNavigatorClicked() => SummonNavigatorClicked?.Invoke();
	private void OnShopNavigatorClicked() => ShopNavigatorClicked?.Invoke();
	private void OnSoldierNavigatorClicked() => SoldierListNavigatorClicked?.Invoke();
}
