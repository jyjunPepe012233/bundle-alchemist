using System.Collections.Generic;

namespace ProjectB.Data.Static.Character
{

	public interface ISoldierList
	{
		IReadOnlyCollection<ISoldierData> Soldiers { get; }
	}

}