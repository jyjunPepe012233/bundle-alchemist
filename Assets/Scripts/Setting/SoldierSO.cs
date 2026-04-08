using UnityEngine;

[CreateAssetMenu(menuName = "Soldier")]
public class SoldierSO : ScriptableObject, IDeckSelectableData
{
	[SerializeField] private GameObject _worldIdlePrefab;
	
	public GameObject WorldDeckPrefab => _worldIdlePrefab;
}
