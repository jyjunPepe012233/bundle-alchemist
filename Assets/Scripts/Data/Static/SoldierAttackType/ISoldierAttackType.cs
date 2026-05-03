using UnityEngine;

namespace ProjectB.Data.Static.SoldierAttackType
{

	public interface ISoldierAttackType
	{
		string SoldierAttackTypeName { get; }
		
		GameObject IconPrefab64 { get; }
	}

}