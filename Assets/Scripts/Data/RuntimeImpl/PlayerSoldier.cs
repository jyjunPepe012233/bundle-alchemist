using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;

namespace ProjectB.Data.RuntimeImpl
{

	public class PlayerSoldier : IPlayerSoldier
	{
		public string SoldierId { get; }
		
		public int Exp { get; private set; }

		public short Level { get; private set; }
		
		public event Action ExpChanged;
		public event Action LevelChanged;


		public PlayerSoldier(ISoldierData soldierData, int exp, short level)
		{
			SoldierId = soldierData.SoldierId;
			Exp = exp;
			Level = level;
		}

		public void SetExp(int exp)
		{
			Exp = exp;
			ExpChanged?.Invoke();
		}

		public void SetLevel(short level)
		{
			Level = level;
			LevelChanged?.Invoke();
		}
	}

}