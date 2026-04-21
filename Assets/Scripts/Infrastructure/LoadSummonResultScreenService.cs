using System.Collections;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure
{

	public class LoadSummonResultScreenService : ILoadSummonResultScreenPort
	{
		private HomeOverlaysControlService _homeOverlaysControlService;
		
		public IEnumerator LoadSummonResultScreen(SummonResult result)
		{
			if (_homeOverlaysControlService != null)
			{
				_homeOverlaysControlService.OpenOverlay("SummonResult");
				yield return null; // HomeOverlay는 내부적으로 오브젝트 활성화/비활성화 기반으로 구현되있음. 따라서 한 프레임을 쉬어서 완벽히 활성화된 상태로 만듬
				yield break;
			}
			
			var uiService = Object.FindObjectsOfType<HomeOverlaysControlService>();
			if (uiService.Length > 0)
			{
				_homeOverlaysControlService = uiService[0];
				_homeOverlaysControlService.OpenOverlay("SummonResult");
				yield return null; // 한 프레임을 쉬어서 완벽히 활성화된 상태로 만듬
			}
			else
			{
				Debug.LogError("현재 Home 씬이 아닙니다. LoadSummonScreenService는 Home 씬에서만 사용할 수 있습니다.");
			}
		}

		public IEnumerator UnloadSummonResultScreen()
		{
			if (_homeOverlaysControlService != null)
			{
				_homeOverlaysControlService.CloseOverlay();
				yield break;
			}

			var uiService = Object.FindObjectsOfType<HomeOverlaysControlService>();
			if (uiService.Length > 0)
			{
				_homeOverlaysControlService = uiService[0];
				_homeOverlaysControlService.CloseOverlay();
			}
			else
			{
				Debug.LogError("현재 Home 씬이 아닙니다. LoadSummonScreenService는 Home 씬에서만 사용할 수 있습니다.");
			}
		}
	}

}