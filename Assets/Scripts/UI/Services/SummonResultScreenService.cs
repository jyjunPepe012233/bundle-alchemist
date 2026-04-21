using ProjectB.Data.Runtime.Summon;
using ProjectB.UI.Screens.SummonResultOverlay;
using UnityEngine;

namespace ProjectB.UI.Services
{

	public class SummonResultScreenService : MonoBehaviour
	{
		[SerializeField] private SummonResultScreenPresenter _summonResultScreen;
		
		void OpenSummonResultScreen(SummonResult result)
		{
			_summonResultScreen.SetSummonResult(result);
			_summonResultScreen.Show();
		}
	}

}