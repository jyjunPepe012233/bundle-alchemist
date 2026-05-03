using UnityEngine;

namespace ProjectB.Data.Static.SoldierRole
{

	public interface ISoldierRoleData
	{
		string SoldierRoleName { get; }
		
		Sprite Icon64 { get; }
	}

}