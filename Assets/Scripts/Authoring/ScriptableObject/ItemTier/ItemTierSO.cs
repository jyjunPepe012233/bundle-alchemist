using ProjectB.Data.Static.ItemTier;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.ItemTier
{

	[CreateAssetMenu(fileName = "Item Tier", menuName = "Project B/Item/Tier")]
	public class ItemTierDataSO : UnityEngine.ScriptableObject, IItemTierData
	{
		[SerializeField] private string _itemTierName;
		public string ItemTierName => _itemTierName;
		
		[SerializeField] private int _itemTierLevel;
		public int ItemTierLevel => _itemTierLevel;
		
		[SerializeField] private GameObject _backgroundPrefab256;
		public GameObject BackgroundPrefab256 => _backgroundPrefab256;
	}

}