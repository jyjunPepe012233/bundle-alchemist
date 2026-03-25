using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTransitionManager : MonoBehaviour, ICommandResolver<LoadingCommands.StartLoadingCommand>
{
	private const string LOADING_OVERLAY_SCENE_NAME = "LoadingOverlay";

	private static LoadingTransitionManager _singleton;
	
	private ILoadingContextHolder _currentLoadingContextHolder;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void InitializeSingleton()
	{
		if (_singleton == null)
		{
			GameObject go = new GameObject(nameof(LoadingTransitionManager), typeof(LoadingTransitionManager));
			_singleton = go.GetComponent<LoadingTransitionManager>();
			DontDestroyOnLoad(go);
		}
	}

	public void Awake()
	{
		CommandBuffer.RegisterExecutor<LoadingCommands.StartLoadingCommand>(this);
	}

	public void OnDestroy()
	{
		CommandBuffer.UnregisterExecutor<LoadingCommands.StartLoadingCommand>();
	}

	public IEnumerator Resolve(LoadingCommands.StartLoadingCommand command)
	{
		if (_currentLoadingContextHolder != null)
		{
			Debug.LogWarning($"[{nameof(LoadingTransitionManager)}] 이미 로딩이 진행 중입니다.");
			yield break;
		}

		_currentLoadingContextHolder = command.LoadingContextHolder;


		// 로딩 화면을 Additive 씬으로 추가
		SceneManager.LoadScene(LOADING_OVERLAY_SCENE_NAME, LoadSceneMode.Additive);

		yield return null; // 로딩 화면 씬의 게임오브젝트가 모두 로딩되도록 한 프레임 대기 
		LoadingTransitionEventBus.LoadingStarted?.Invoke();


		// 로딩 화면이 트랜지션을 준비할 때까지 대기 후 실제 로딩 시작
		bool isTransitionReadied = false;
		LoadingTransitionEventBus.TransitionReadied += () => isTransitionReadied = true;
		yield return new WaitUntil(() => isTransitionReadied);

		command.LoadingContextHolder.Load(); // 실제 로딩 시작


		// 실제 로딩이 끝날 때까지 대기
		yield return new WaitUntil(() => command.LoadingContextHolder.IsDone);
		LoadingTransitionEventBus.LoadingFinished?.Invoke();


		// 실제 로딩이 끝나면 트랜지션이 끝날 때까지 대기 후 로딩 화면 씬 Unload
		bool isTransitionDisposed = false;
		LoadingTransitionEventBus.TransitionDisposed += () => isTransitionDisposed = true;
		yield return new WaitUntil(() => isTransitionDisposed);
		SceneManager.UnloadSceneAsync(LOADING_OVERLAY_SCENE_NAME); // 로딩 화면 씬 Unload


		_currentLoadingContextHolder = null;
	}
}
