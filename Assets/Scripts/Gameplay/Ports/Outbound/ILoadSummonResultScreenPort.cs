using System.Collections;
using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSummonResultScreenPort
	{
		IEnumerator LoadSummonResultScreen(SummonResult result);
		
		IEnumerator UnloadSummonResultScreen();
	}

}