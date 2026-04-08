using System.Collections.Generic;
using Core.Type;
using Data.Character;
using UnityEngine;

namespace Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier Database")]
	public class SoldierDatabaseSO : UnityEngine.ScriptableObject, ISoldierList
	{
		[SerializeField] private InterfaceRefs<ISoldierData> _soldiers;
		public IReadOnlyCollection<ISoldierData> Soldiers => _soldiers.Value;
	}

}
