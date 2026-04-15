using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Character;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier Database")]
	public class SoldierDatabaseSO : UnityEngine.ScriptableObject, ISoldierList
	{
		[SerializeField] private InterfaceRefs<ISoldierData> _soldiers;
		public IReadOnlyCollection<ISoldierData> Soldiers => _soldiers.Value;
	}

}
