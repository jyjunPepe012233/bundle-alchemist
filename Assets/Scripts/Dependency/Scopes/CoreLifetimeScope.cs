using ProjectB.Authoring.ScriptableObject.Invasion;
using ProjectB.Authoring.ScriptableObject.Item;
using ProjectB.Authoring.ScriptableObject.Soldier;
using ProjectB.Authoring.ScriptableObject.Summon;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Data.Static.Item;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Static.Summon;
using ProjectB.Gameplay;
using ProjectB.Gameplay.Ports;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure;
using UnityEngine;
using VContainer;

namespace ProjectB.Dependency.Scopes
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
		[SerializeField] private SoldierDatabaseSO _soldierDatabaseSO;
		[SerializeField] private ItemDatabaseSO _itemDatabaseSO;
		[SerializeField] private InvasionSettingSO _invasionSettingSO;
		[SerializeField] private SummonCostSettingSO _summonCostSettingSo;

		protected override void Awake()
		{
			base.Awake();
			
			Container.Resolve<PlayerSessionInitializer>();
		}
		
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			Builder.Register<LoadingManager>(Lifetime.Singleton).As<
				ILoadingServicePort,
				ILoadingOverlayManagerPort
			>();

			RegisterPortAdapter<IPlayerDataServicePort, PlayerDataService>();

			// TODO:
			// PlayerSessionInitializer는 Inbound Adapter가 아니라 독립적으로 작동하는 게임 시스템에 가까움.
			// 이 사례처럼 클래스에 대한 분리 기준이 항상 명확하게 작용하지 않고 있으므로 StructureLifetimeScope를 리팩토링하여
			// 클래스 구분을 최대한 유연하게 만들거나 없애는 방안을 고려해볼 수 있음.
			// 지금은 임시로 Inbound Adapter를 등록하는 메서드에서 등록함
			Builder.Register<PlayerSessionInitializer>(Lifetime.Singleton);
			
			// 사도 정보는 대부분의 화면에서 열릴 수 있기 때문에 Core에 등록
			RegisterPortAdapter<ISoldierDetailServicePort, SoldierDetailService>();
		}

		protected override void AddInternalAdapters()
		{
			base.AddInternalAdapters();
			RegisterPortAdapter<ISoldierStatusComputerPort, SoldierStatusComputer>();
			RegisterPortAdapter<ISoldierCombatPowerComputerPort, SoldierCombatPowerComputer>();
			RegisterPortAdapter<IPlayerSoldierFactory, PlayerSoldierFactory>();
			RegisterPortAdapter<IPlayerInventoryServicePort, PlayerInventoryService>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddOutboundAdapters();
			RegisterPortAdapter<IControlLoadingOverlayPort, ControlLoadingOverlayService>();
			RegisterPortAdapter<ILoadHomePort, LoadHomeService>();
			RegisterPortAdapter<IPlayerSessionHolderPort, PlayerSessionHolderService>();
			RegisterPortAdapter<ILoadPlayerDataPort, LoadPlayerDataService>();
			RegisterPortAdapter<IInitializePlayerSessionPort, InitializePlayerSessionService>();
			RegisterPortAdapter<ILoadSoldierDetailScreenPort, LoadSoldierDetailScreenService>();
		}

		protected override void AddData()
		{
			base.AddData();
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
			RegisterPortInstance<ISoldierDatabase, SoldierDatabaseSO>(_soldierDatabaseSO);
			RegisterPortInstance<IItemDatabase, ItemDatabaseSO>(_itemDatabaseSO);
			RegisterPortInstance<ISummonCostSetting, SummonCostSettingSO>(_summonCostSettingSo);
		}
	}

}