using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	// TODO: 삭제하기. 화면 Unload는 LoadSummonAnimationScreenService와 같이 구현되고 사용되어야 함.
	public class UnloadScreenService : IUnloadScreenPort
	{
		public void UnloadCurrentScreen()
		{
			var uiService = Object.FindObjectsOfType<HomeOverlaysControlService>();
			if (uiService.Length > 0)
			{
				uiService[0].CloseOverlay();
			}
			else
			{
				Debug.LogError("현재 Home 씬이 아닙니다. UnloadScreenService는 Home 씬에서만 사용할 수 있습니다.");
			}
		}
	}

}