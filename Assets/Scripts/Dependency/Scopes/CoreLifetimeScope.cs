using Composition.Core;
using Gameplay.Ports.Inbound;
using Gameplay.Ports.Outbound;
using Gameplay.TitleScreen;
using Infrastructure.LoadHome;
using Infrastructure.Loading;
using VContainer;

namespace Composition
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
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
			RegisterPortAdapter<ILoadLoadingOverlayPort, LoadLoadingOverlayService>();
			RegisterPortAdapter<ILoadHomePort, LoadHomeService>();
		}
	}

}