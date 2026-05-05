using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	[CreateAssetMenu(menuName = "Consumable Item")]
	public class ConsumableItemSO : UnityEngine.ScriptableObject, IConsumableItem
	{
		[SerializeField] private string _itemId;
		public string ItemId => _itemId;
		
		[SerializeField] private string _itemName;
		public string ItemName => _itemName;
		
		// 인터페이스에서 요구하는 Item Category 정보를 코드에서 정의하여
		// enum 설정을 헷갈리는 문제를 방지함 (Enum 설정 안 해도 올바른 타입(Consumable)이 반환됨)
		public ItemCategory Category => ItemCategory.Consumable;
		
		public void Consume()
		{
			Debug.Log($"Consumed {_itemName}!");
		}
	}

}