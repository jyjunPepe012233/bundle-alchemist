using ProjectB.Gameplay.Loading;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure.Loading;
using VContainer;

namespace ProjectB.Dependency.Scopes
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