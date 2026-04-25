using ProjectB.Gameplay.HomeScreen;
using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Infrastructure;

namespace ProjectB.Dependency.Scopes
{

	public class HomeScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<IHomeScreenManagerPort, HomeScreenManager>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddOutboundAdapters();
			RegisterPortAdapter<ILoadSummonScreenPort, LoadSummonScreenService>();
			RegisterPortAdapter<IUnloadScreenPort, UnloadScreenService>();
		}
	}

}