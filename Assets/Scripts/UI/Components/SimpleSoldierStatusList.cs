using ProjectB.Data.Types;
using UnityEngine;

namespace ProjectB.UI.Components
{

	public class SimpleSoldierStatusList : MonoBehaviour
	{
		[Header("꼭 모든 아이템을 할당하지는 않아도 됨")]
		[SerializeField] private SimpleSoldierStatusItem _hpStatusItem;
		[SerializeField] private SimpleSoldierStatusItem _spStatusItem;
		[SerializeField] private SimpleSoldierStatusItem _physicalAttackStatusItem;
		[SerializeField] private SimpleSoldierStatusItem _magicalAttackStatusItem;
		[SerializeField] private SimpleSoldierStatusItem _physicalDefenseStatusItem;
		[SerializeField] private SimpleSoldierStatusItem _magicalDefenseStatusItem;

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

		public void SetStatus(SoldierStatus status)
		{
			// 각 아이템이 null이 아닌 경우에만 값을 설정
			_hpStatusItem?.SetValue(status.hp);
			_spStatusItem?.SetValue(status.sp);
			_physicalAttackStatusItem?.SetValue(status.physicalAttack);
			_magicalAttackStatusItem?.SetValue(status.magicalAttack);
			_physicalDefenseStatusItem?.SetValue(status.physicalDefense);
			_magicalDefenseStatusItem?.SetValue(status.magicalDefense);
		}
	}

}
