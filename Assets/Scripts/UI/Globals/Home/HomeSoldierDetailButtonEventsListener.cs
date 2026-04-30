using ProjectB.Data.Static.Soldier;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Buttons.SoldierDetailButton;
using UnityEngine;

namespace ProjectB.UI.Globals.Home
{

	public class HomeSoldierDetailButtonEventsListener : MonoBehaviour
	{
		[SerializeField] private SoldierDetailServicePortInstaller _soldierDetailServicePortInstaller;
		
		void Awake()
		{
			SoldierDetailButtonEvents.Clicked += OnClicked;
		}

		void OnDestroy()
		{
			SoldierDetailButtonEvents.Clicked -= OnClicked;
		}

		void OnClicked(ISoldierData soldierData)
		{
			_soldierDetailServicePortInstaller.Port.ShowSoldierDetail(soldierData);
		}
	}

}