using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimpleSoldierStatusUpgradeList : MonoBehaviour
	{
		[Header("꼭 모든 아이템을 할당하지는 않아도 됨")]
		[SerializeField] private SimpleSoldierStatusUpgradeItem _hpStatusItem;
		[SerializeField] private SimpleSoldierStatusUpgradeItem _spStatusItem;
		[SerializeField] private SimpleSoldierStatusUpgradeItem _physicalAttackStatusItem;
		[SerializeField] private SimpleSoldierStatusUpgradeItem _magicalAttackStatusItem;
		[SerializeField] private SimpleSoldierStatusUpgradeItem _physicalDefenseStatusItem;
		[SerializeField] private SimpleSoldierStatusUpgradeItem _magicalDefenseStatusItem;

//		private List<SoldierStatusItem> _items;

//		private void Awake()
//		{
//			_items = new List<SoldierStatusItem>
//			{
//				_hpStatusItem,
//				_spStatusItem,
//				_physicalAttackStatusItem,
//				_magicalAttackStatusItem,
//				_physicalDefenseStatusItem,
//				_magicalDefenseStatusItem
//			};
//		}

		public void SetStatus(SoldierStatus currentStatus, SoldierStatus nextStatus)
		{
			SetStatusOfItem(_hpStatusItem, currentStatus.hp, nextStatus.hp);
			SetStatusOfItem(_spStatusItem, currentStatus.sp, nextStatus.sp);
			SetStatusOfItem(_physicalAttackStatusItem, currentStatus.physicalAttack, nextStatus.physicalAttack);
			SetStatusOfItem(_magicalAttackStatusItem, currentStatus.magicalAttack, nextStatus.magicalAttack);
			SetStatusOfItem(_physicalDefenseStatusItem, currentStatus.physicalDefense, nextStatus.physicalDefense);
			SetStatusOfItem(_magicalDefenseStatusItem, currentStatus.magicalDefense, nextStatus.magicalDefense);
		}
		
		void SetStatusOfItem(SimpleSoldierStatusUpgradeItem item, int currentStatus, int nextStatus)
		{
			// 아이템이 null이 아닌 경우에만 값을 설정
			if (item != null)
			{
				item.SetValue(currentStatus);
				item.SetUpgradeValue(nextStatus - currentStatus);
			}
		}
	}

}
