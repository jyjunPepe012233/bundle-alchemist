using System.Collections;
using System.Collections.Generic;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadRewardGainPopupPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load(IEnumerable<ItemGain> itemGains);
	}

}