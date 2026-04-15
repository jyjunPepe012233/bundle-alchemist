using Composition.Core;
using VContainer;

namespace Composition
{

	public class CoreLifetimeScope : StructuredLifetimeScope
	{
		protected override void AddInfrastructure()
		{
			base.AddInfrastructure();
			RegisterSingleSystem<LoadingTransitionManager>();
		}
	}

}