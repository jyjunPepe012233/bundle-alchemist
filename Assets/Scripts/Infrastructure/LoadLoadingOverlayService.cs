using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectB.Infrastructure.Loading
{

	public class LoadLoadingOverlayService : ILoadLoadingOverlayPort // TODO: Load보다 Control이 더 적합함 (Load, Unload를 모두 담당하기 때문)
	{
		private const string LOADING_OVERLAY_SCENE_NAME = "LoadingOverlay";
		
		public IEnumerator LoadLoadingOverlay()
		{
			SceneManager.LoadScene(LOADING_OVERLAY_SCENE_NAME, LoadSceneMode.Additive);
			yield return null; // 로딩 화면 씬의 게임오브젝트가 모두 로딩되도록 한 프레임 대기
		}

		public IEnumerator UnloadLoadingOverlay()
		{
			SceneManager.UnloadSceneAsync(LOADING_OVERLAY_SCENE_NAME); // 로딩 화면 씬 Unload
			yield break; // 대기하지 않고 함수 호출 후 바로 스킵
		}
	}

}