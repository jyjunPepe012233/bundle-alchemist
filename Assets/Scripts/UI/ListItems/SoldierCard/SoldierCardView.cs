using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Components;
using TMPro;
using UnityEngine;

namespace ProjectB.UI.ListItems.SoldierCard
{
	
	public class SoldierCardView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _soldierNameText;
		[SerializeField] private Transform _soldierDisplayParent;
		[SerializeField] private SimpleIconView _roleIcon;
		[SerializeField] private SimpleIconView _styleIcon;

		private GameObject _displaySoldier;
		
		public void ApplySoldierData(ISoldierData soldierData)
		{
			_soldierNameText.text = soldierData.SoldierName;
			
			
			if (_displaySoldier != null)
			{
				Destroy(_displaySoldier);
			}
			_displaySoldier = Instantiate(
				soldierData.CardDisplaySetting.DisplayedSoldierPrefab,
				_soldierDisplayParent
			);
			
			_roleIcon.SetIcon(soldierData.Role.Icon64);
			_roleIcon.SetBackgroundColor(soldierData.Role.Color);
			
			_styleIcon.SetIcon(soldierData.Spirit.Icon64);
			_styleIcon.SetBackgroundColor(soldierData.Spirit.Color);
		}
	}

}