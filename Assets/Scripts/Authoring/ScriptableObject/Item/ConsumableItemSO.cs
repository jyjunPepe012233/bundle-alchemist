using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Item
{

	// 이 클래스를 상속하여 소비 아이템을 정의할 것 (예: 재화를 얻는 아이템, 아이템을 얻는 아이템, 뽑기 아이템 등)
	// 이 때, 소비 아이템을 정의한 클래스는 개발자의 의도에 따라 sealed로 설정하는 것을 추천 
	public abstract class ConsumableItemSO : UnityEngine.ScriptableObject, IConsumableItem
	{
		[SerializeField] private string _itemId;
		public string ItemId => _itemId;
		
		[SerializeField] private string _itemName;
		public string ItemName => _itemName;
		
		// 인터페이스에서 요구하는 Item Category 정보를 코드에서 정의하여
		// enum 설정을 헷갈리는 문제를 방지함 (Enum 설정 안 해도 올바른 타입(Consumable)이 반환됨)
		public ItemCategory Category => ItemCategory.Consumable;

		public abstract void Consume();
	}

}