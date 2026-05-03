using ProjectB.Data.Static.SoldierRole;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.SoldierRole
{

	[CreateAssetMenu(menuName = "Soldier Role")]
	public class SoldierRoleSO : UnityEngine.ScriptableObject, ISoldierRoleData
	{
		[SerializeField] private string _soldierRoleName;
		public string SoldierRoleName => _soldierRoleName;
		
		[SerializeField] private GameObject _iconPrefab64;
		public GameObject IconPrefab64 => _iconPrefab64;
	}

}
