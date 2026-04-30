using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Buttons.Common;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Buttons.SoldierDetailButton
{

	public class SoldierDetailButtonPresenter : UIPresenter<ButtonView>
	{
		private ISoldierData _soldierData;

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.ButtonClicked += OnButtonClicked;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.ButtonClicked -= OnButtonClicked;
		}

		// 26.05.01. - ListItem_SoldierCard_Detail 프리팹이
		// SimpleSoldierData의 UnityEvent로 SoldierData를 얻는 구조로 만들어져있음
		public void SetSoldierData(ISoldierData soldierData)
		{
			_soldierData = soldierData;
		}

		void OnButtonClicked()
		{
			if (_soldierData != null)
			{
				SoldierDetailButtonEvents.Clicked?.Invoke(_soldierData);
			}
			else
			{
				Debug.LogError("Soldier Detail Button에 soldier Data가 할당되지 않았습니다");
			}
		}
	}

}