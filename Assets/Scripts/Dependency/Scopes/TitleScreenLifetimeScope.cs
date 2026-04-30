using ProjectB.Gameplay;
using ProjectB.Gameplay.Ports.Inbound;

namespace ProjectB.Dependency.Scopes
{

	public class TitleScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<ITitleScreenManagerPort, TitleScreenManager>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddInboundAdapters();
		}
	}

}