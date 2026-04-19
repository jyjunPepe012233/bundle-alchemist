using ProjectB.Data.Static.SoldierRole;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier Role")]
	public class SoldierRoleSO : UnityEngine.ScriptableObject, ISoldierRoleData
	{
		[SerializeField] private string _soldierRoleName;
		public string SoldierRoleName => _soldierRoleName;
		
		[SerializeField] private Color _color;
		public Color Color => _color;
		
		[SerializeField] private Sprite _icon64;
		public Sprite Icon64 => _icon64;
	}

}
