using ProjectB.Gameplay;
using ProjectB.Gameplay.Ports.Inbound;

namespace ProjectB.Dependency.Scopes
{

	public class SoldierDetailScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<ISoldierLevelUpServicePort, SoldierLevelUpService>();
		}
	}

}