using System.Collections;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.UI.Services;
using UnityEngine;

namespace ProjectB.Infrastructure.Loading
{

	public class LoadSummonScreenService : ILoadSummonScreenPort
	{
		public IEnumerator LoadSummonScreen()
		{
			var uiService = Object.FindObjectsOfType<HomeOverlaysControlService>();
			if (uiService.Length > 0)
			{
				uiService[0].OpenOverlay("SummonScreen");
			}
			else
			{
				Debug.LogError("현재 Home 씬이 아닙니다. LoadSummonScreenService는 Home 씬에서만 사용할 수 있습니다.");
			}
			
			yield break;
		}
	}

}