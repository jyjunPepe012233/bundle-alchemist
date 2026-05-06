using UnityEngine;

namespace ProjectB.Data.Static.ItemTier
{

	public interface IItemTierData
	{
		string ItemTierName { get; }
		
		int ItemTierLevel { get; }

		GameObject BackgroundPrefab256 { get; }
	}

}