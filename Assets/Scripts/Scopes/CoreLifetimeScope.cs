using Composition.Core;
using VContainer;

namespace Composition
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
//		protected override void AddInfrastructure()
		{
			base.Configure(builder);
			base.AddInfrastructure();
			RegisterSingleSystem<LoadingTransitionManager>();
		}
	}

}