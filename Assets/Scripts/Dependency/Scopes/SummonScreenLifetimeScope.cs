using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;
using ProjectB.Gameplay.Summon;
using ProjectB.Infrastructure;
using VContainer;

namespace ProjectB.Dependency.Scopes
{

	public class SummonScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			Builder.Register<SummonManager>(Lifetime.Singleton).As<
				ISummonServicePort,
				ISummonAnimationManagerPort
			>();
			RegisterPortAdapter<ILoadSummonScreenPort, LoadSummonScreenService>();
			RegisterPortAdapter<ILoadSummonAnimationScreenPort, LoadSummonAnimationScreenService>();
			RegisterPortAdapter<ILoadSummonResultScreenPort, LoadSummonResultScreenService>();
		}
	}

}