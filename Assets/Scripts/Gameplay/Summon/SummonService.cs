using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Soldier;
using ProjectB.Gameplay.Ports.Inbound.Summon;

namespace ProjectB.Gameplay.Summon
{

	public class SummonService : ISummonServicePort
	{
		private readonly ISoldierDatabase _soldierDatabase;
		
		public SummonService(ISoldierDatabase soldierDatabase)
		{
			_soldierDatabase = soldierDatabase;
		}

		public SummonResult Summon1x()
		{
			// 단수 모집
			int i = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
			var soldier = _soldierDatabase.Soldiers[i];
			
			return new SummonResult{ SummonedSoldiers = new []{ soldier } };
		}

		public SummonResult Summon10x()
		{
			ISoldierData[] summonedSoldiers = new ISoldierData[10];
			for (int i = 0; i < 10; i++)
			{
				int random = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
				summonedSoldiers[i] = _soldierDatabase.Soldiers[i];
			}
			return new SummonResult{ SummonedSoldiers = summonedSoldiers };
		}
	}

}