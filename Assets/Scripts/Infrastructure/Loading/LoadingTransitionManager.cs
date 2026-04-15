using System;
using System.Collections;
using Core.Handlers;
using Core.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTransitionManager
{
	private const string LOADING_OVERLAY_SCENE_NAME = "LoadingOverlay";
	
	
	
	public event Action LoadingStarted;
	public Action TransitionReadied { get; private set; }
	public event Action LoadingFinished;
	public Action TransitionDisposed { get; private set; }
	
	
	
	private ILoadingTask _currentLoadingTask;
	
	

	public void StartLoadingWithTransition(ILoadingTask loadingTask)
	{
		CoroutineHandler.StartAndAdd(Coroutine(loadingTask));
	}

	IEnumerator Coroutine(ILoadingTask loadingTask)
	{
		if (_currentLoadingTask != null)
		{
			Debug.LogWarning($"[{nameof(LoadingTransitionManager)}] 이미 로딩이 진행 중입니다.");
			yield break;
		}

		_currentLoadingTask = loadingTask;


		// 로딩 화면을 Additive 씬으로 추가
		SceneManager.LoadScene(LOADING_OVERLAY_SCENE_NAME, LoadSceneMode.Additive);

		yield return null; // 로딩 화면 씬의 게임오브젝트가 모두 로딩되도록 한 프레임 대기 
		LoadingStarted?.Invoke();


		// 로딩 화면이 트랜지션의 fade-in이 끝낼 때까지 대기 후 실제 로딩 시작
		bool isTransitionReadied = false;
		TransitionReadied += () => isTransitionReadied = true;
		yield return new WaitUntil(() => isTransitionReadied);

		loadingTask.Load(); // 실제 로딩 시작


		// 실제 로딩이 끝날 때까지 대기
		yield return new WaitUntil(() => loadingTask.IsDone);
		LoadingFinished?.Invoke();


		// 실제 로딩이 끝나면 트랜지션의 fade-out이 끝날 때까지 대기 후 로딩 화면 씬 Unload
		bool isTransitionDisposed = false;
		TransitionDisposed += () => isTransitionDisposed = true;
		yield return new WaitUntil(() => isTransitionDisposed);
		SceneManager.UnloadSceneAsync(LOADING_OVERLAY_SCENE_NAME); // 로딩 화면 씬 Unload


		_currentLoadingTask = null;
	}
}
