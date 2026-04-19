using UnityEngine;

namespace ProjectB.Data.Static.SoldierRole
{

	public interface ISoldierRoleData
	{
		string SoldierRoleName { get; }
		
		Color Color { get; }
		
		Sprite Icon64 { get; }
	}

}