using System;
using UnityEngine;

public class BackToLobbyButtonUI : MonoBehaviour
{
	[SerializeField] private BackToLobbyButtonView _view;
	
	private ILoadGameScenes _gameSceneLoader = GameSceneManager.Singleton;

	public void Awake()
	{
		_view.OnSetupUICallbacks();
		_view.ButtonClicked += OnButtonClicked;
	}
	
	private void OnButtonClicked()
	{
		_gameSceneLoader.LoadLobby();
	}

	private void OnDestroy()
	{
		_view.Dispose();
	}
}
