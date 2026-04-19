using ProjectB.Authoring.ScriptableObject.Invasion;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using ProjectB.Gameplay.Loading;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure.Loading;
using UnityEngine;
using VContainer;

namespace ProjectB.Dependency.Scopes
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
		[SerializeField] private InvasionSettingSO _invasionSettingSO;
		
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			Builder.Register<LoadingManager>(Lifetime.Singleton).As<
				ILoadingServicePort,
				ILoadingOverlayManagerPort
			>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddOutboundAdapters();
			RegisterPortAdapter<IControlLoadingOverlayPort, ControlLoadingOverlayService>();
			RegisterPortAdapter<ILoadHomePort, LoadHomeService>();
		}

		protected override void AddData()
		{
			base.AddData();
			RegisterPortInstance<IInvasionSetting, InvasionSettingSO>(_invasionSettingSO);
		}
	}

}