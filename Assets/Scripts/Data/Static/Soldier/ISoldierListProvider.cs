using System.Collections.Generic;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierListProvider
	{
		IEnumerable<ISoldierData> Soldiers { get; }
	}

}