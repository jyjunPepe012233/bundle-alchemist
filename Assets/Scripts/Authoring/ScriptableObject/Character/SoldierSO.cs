using Data.Character;
using UnityEngine;

namespace Authoring.ScriptableObject.Character
{

	[CreateAssetMenu(menuName = "Soldier")]
	public class SoldierSO : UnityEngine.ScriptableObject, ISoldierData, IDeckSelectableData
	{
		[SerializeField] private string _soldierName;
		public string SoldierName => _soldierName;
	
		[SerializeField] private GameObject _deckSelectedPrefab;
		public GameObject DeckSelectedPrefab => _deckSelectedPrefab;
	}

}
