using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.SoldierRole;
using ProjectB.Data.Static.Spirit;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Soldier
{

	[CreateAssetMenu(menuName = "Soldier")]
	public class SoldierSO : UnityEngine.ScriptableObject, ISoldierData, ISoldierCardDisplaySetting
	{
		public ISoldierCardDisplaySetting CardDisplaySetting => this;
		
		public ISoldierLevelUpExpSetting LevelUpExpSetting => _soldierLevelUpExpSettingSo;
		
		
		[Header("Soldier Info")]
		[SerializeField] private string _soldierId;
		public string SoldierId => _soldierId;
		
		[SerializeField] private string _soldierName;
		public string SoldierName => _soldierName;

		[SerializeField] private InterfaceRef<ISpiritData> _spirit;
		public ISpiritData Spirit => _spirit.Value;
		
		[SerializeField] private InterfaceRef<ISoldierRoleData> _role;
		public ISoldierRoleData Role => _role.Value;


		
		[Header("Card Display Setting")]
		[SerializeField] private GameObject _displayedSoldierPrefab;
		public GameObject DisplayedSoldierPrefab => _displayedSoldierPrefab;



		[Header("LevelUp Exp Setting")]
		[SerializeField] private SoldierLevelUpExpSettingSO _soldierLevelUpExpSettingSo;
	}

}
