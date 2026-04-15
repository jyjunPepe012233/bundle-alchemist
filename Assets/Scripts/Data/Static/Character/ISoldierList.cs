using System.Collections.Generic;

namespace Data.Character
{

	public interface ISoldierList
	{
		IReadOnlyCollection<ISoldierData> Soldiers { get; }
	}

}