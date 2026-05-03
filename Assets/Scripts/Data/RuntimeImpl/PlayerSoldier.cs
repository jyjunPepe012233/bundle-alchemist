using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Data.RuntimeImpl
{

	public class PlayerSoldier : IPlayerSoldier
	{
		public string SoldierId { get; }
		
		public int Exp { get; private set; }

		public short Level { get; private set; }
		
		public SoldierStatus Status { get; private set; }

		public event Action ExpChanged;
		public event Action LevelChanged;
		public event Action StatusChanged;


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

		public void SetStatus(SoldierStatus status)
		{
			Status = status;
			StatusChanged?.Invoke();
		}
	}

}