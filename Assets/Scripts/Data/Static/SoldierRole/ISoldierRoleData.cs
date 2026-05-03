using UnityEngine;

namespace ProjectB.Data.Static.SoldierRole
{

	public interface ISoldierRoleData
	{
		string SoldierRoleName { get; }
		
		GameObject IconPrefab64 { get; }
	}

}