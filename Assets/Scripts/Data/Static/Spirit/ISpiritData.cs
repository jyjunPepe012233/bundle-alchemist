using UnityEngine;

namespace ProjectB.Data.Static.Spirit
{

	public interface ISpiritData
	{
		string SpiritName { get; }
		
		Color Color { get; }
		
		Sprite Icon64 { get; }
	}

}