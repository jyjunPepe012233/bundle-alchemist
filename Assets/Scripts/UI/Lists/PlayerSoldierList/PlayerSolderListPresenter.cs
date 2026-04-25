using System;
using System.Linq;
using ProjectB.Dependency.Installers;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Lists.PlayerSoldierList
{

	public class PlayerSolderListPresenter : UIPresenter<PlayerSoldierListView>
	{
		[SerializeField] private SoldierDatabaseInstaller _soldierDatabaseInstaller;
		[SerializeField] private PlayerDataServicePortInstaller _playerDataServicePortInstaller;

		protected override void InitializeView()
		{
			base.InitializeView();
			
			var soldierDatabase = _soldierDatabaseInstaller.Port;

			var tupleArray = _playerDataServicePortInstaller.Port.GetPlayerData().Soldiers.Select(playerSoldier =>
			{
				var soldierData = soldierDatabase.GetSoldierById(playerSoldier.SoldierId);
				return (playerSoldier, soldierData);
			}).ToArray();
			
			view.UpdateAllPlayerSoldiers(tupleArray);
		}
	}

}