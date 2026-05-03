using UnityEngine;

namespace ProjectB.Data.Static.Spirit
{

	public interface ISpiritData
	{
		string SpiritName { get; }
		
		GameObject IconPrefab64 { get; }
	}

}