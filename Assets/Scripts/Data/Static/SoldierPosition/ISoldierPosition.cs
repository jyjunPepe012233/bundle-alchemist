using UnityEngine;

namespace ProjectB.Data.Static.SoldierPosition
{

	public interface ISoldierPosition
	{
		string SoldierPositionName { get; }
		
		GameObject IconPrefab64 { get; }
		
		bool CanFront { get; }
		
		bool CanMid { get; }
		
		bool CanBack { get; }
	}

}