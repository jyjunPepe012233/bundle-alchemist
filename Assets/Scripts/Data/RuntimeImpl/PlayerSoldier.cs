using System;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;

namespace ProjectB.Data.RuntimeImpl
{

	public class PlayerSoldier : IPlayerSoldier
	{
		public string SoldierId { get; }
		
		public byte Rank { get; private set; }
		
		public int Exp { get; private set; }

		public short Level { get; private set; }
		
		public SoldierStatus Status { get; private set; }
		
		public int CombatPower { get; private set; }

		public event Action RankChanged;
		public event Action ExpChanged;
		public event Action LevelChanged;
		public event Action StatusChanged;
		public event Action CombatPowerChanged;


		public PlayerSoldier(ISoldierData soldierData,
			byte rank,
			int exp,
			short level,
			SoldierStatus status,
			int combatPower)
		{
			SoldierId = soldierData.SoldierId;
			Rank = rank;
			Exp = exp;
			Level = level;
			Status = status;
			CombatPower = combatPower;
		}

		public void SetRank(byte rank)
		{
			Rank = rank;
			RankChanged?.Invoke();
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
		
		public void SetCombatPower(int combatPower)
		{
			CombatPower = combatPower;
			CombatPowerChanged?.Invoke();
		}
	}

}