using ProjectB.Gameplay;
using ProjectB.Gameplay.Ports.Inbound;

namespace ProjectB.Dependency.Scopes
{

	public class ShopScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<IShopServicePort, ShopService>();
		}
	}

}