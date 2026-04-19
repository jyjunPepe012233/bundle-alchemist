using System.Linq;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Soldier;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.SoldierList
{

	public class SoldierListPresenter : UIPresenter<SoldierListView>
	{
		[SerializeField]
		private InterfaceRef<ISoldierListProvider> _soldierListProvider;

		protected override void InitializeView()
		{
			base.InitializeView();
			view.UpdateAllSoldiers(_soldierListProvider.Value.Soldiers.ToArray());
		}
	}

}