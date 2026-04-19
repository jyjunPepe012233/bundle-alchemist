using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier Database")]
	public class SoldierDatabaseSO : UnityEngine.ScriptableObject, ISoldierListProvider
	{
		[SerializeField] private InterfaceRefs<ISoldierData> _soldiers;
		public IEnumerable<ISoldierData> Soldiers => _soldiers.Value;
	}

}
