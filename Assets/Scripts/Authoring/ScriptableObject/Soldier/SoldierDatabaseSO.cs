using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier Database")]
	public class SoldierDatabaseSO : UnityEngine.ScriptableObject, ISoldierDatabase
	{
		[SerializeField] private InterfaceRefs<ISoldierData> _soldiers;
		public IReadOnlyList<ISoldierData> Soldiers => _soldiers.Value;
	}

}
