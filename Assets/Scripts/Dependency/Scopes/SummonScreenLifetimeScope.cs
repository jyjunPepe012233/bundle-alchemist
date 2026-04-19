using ProjectB.Gameplay.Ports.Inbound.Summon;
using ProjectB.Gameplay.Summon;

namespace ProjectB.Dependency.Scopes
{

	public class SummonScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<ISummonServicePort, SummonService>();
		}
	}

}