using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	[CreateAssetMenu(menuName = "Item")]
	public class ItemSO : UnityEngine.ScriptableObject, IItemData
	{
		[SerializeField] private string _itemId;
		public string ItemId => _itemId;
		
		[SerializeField] private string _itemName;
		public string ItemName => _itemName;
		
		[SerializeField] private ItemCategory _category;
		public ItemCategory Category => _category;
	}

}