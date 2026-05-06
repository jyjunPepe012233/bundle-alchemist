using ProjectB.Data.Static.ItemTier;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectB.Authoring.ScriptableObject.ItemTier
{

	[CreateAssetMenu(fileName = "Item Tier", menuName = "Project B/Item/Tier")]
	public class ItemTierDataSO : UnityEngine.ScriptableObject, IItemTierData
	{
		[SerializeField] private string _itemTierName;
		public string ItemTierName => _itemTierName;
		
		[SerializeField] private int _itemTierLevel;
		public int ItemTierLevel => _itemTierLevel;
		
		[SerializeField] private GameObject _backgroundPrefab128;
		public GameObject BackgroundPrefab128 => _backgroundPrefab128;
	}

}