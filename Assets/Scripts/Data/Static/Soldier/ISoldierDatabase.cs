namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierDatabase : ISoldierListProvider
	{
		ISoldierData GetSoldierById(string soldierId);

		bool VerifySoldierId(string soldierId);
	}

}