using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure
{

	public class SceneLoadingTask : ILoadingTaskPort
	{
		public bool IsDone => asyncOperation?.isDone ?? false;

		public float Progress => asyncOperation?.progress ?? 0;

		private readonly string sceneName;
	
		private AsyncOperation asyncOperation;

		public SceneLoadingTask(string sceneName)
		{
			this.sceneName = sceneName;
		}

		public void Load()
		{
			IEnumerator Coroutine()
			{
				Scene oldScene = SceneManager.GetActiveScene();
		
				// 다음 씬 로딩
				asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
				yield return asyncOperation;
			
				Scene nextScene = SceneManager.GetSceneByName(sceneName);
				if (!nextScene.IsValid())
				{
					// 씬 로드 실패 시 함수 종료
					Debug.LogError($"[{nameof(SceneLoadingTask)}] 씬 로드 실패: {sceneName}");
					yield break;
				}
				SceneManager.SetActiveScene(nextScene);
			
				// 이전 씬 언로드
				if (oldScene.isLoaded)
				{
					AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(oldScene);
					yield return unloadOp;
				}
				else
				{
					Debug.LogWarning("[{nameof(SceneLoadingContextHolder)}] 이전 씬이 로드되지 않았음: " + oldScene.name);
				}
			}
		
			CoroutineHandler.StartAndAdd(Coroutine());
		}
	}

}
