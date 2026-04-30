using ProjectB.Core.Supports;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay
{

	public class SoldierDetailService : ISoldierDetailServicePort
	{
		private readonly ILoadSoldierDetailScreenPort _loadSoldierDetailScreenPort;

		public SoldierDetailService(ILoadSoldierDetailScreenPort loadSoldierDetailScreenPort)
		{
			_loadSoldierDetailScreenPort = loadSoldierDetailScreenPort;
		}

		public void ShowSoldierDetail(ISoldierData soldierData)
		{
			CoroutineHandler.StartAndAdd(_loadSoldierDetailScreenPort.Load());
		}
	}

}