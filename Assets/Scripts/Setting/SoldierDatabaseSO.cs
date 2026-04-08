using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Soldier Database")]
public class SoldierDatabaseSO : ScriptableObject
{
	[SerializeField] private SoldierSO[] _soldiers;
	public IReadOnlyList<SoldierSO> Soldiers => _soldiers;
}
