using Composition.Core;
using Gameplay.Ports.Inbound;
using Gameplay.Ports.Outbound;
using Gameplay.TitleScreen;
using VContainer;
using VContainer.Unity;

namespace Composition
{

	public class TitleScreenLifetimeScope : StructuredLifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
//		protected override void AddInboundAdapters()
		{
			base.Configure(builder);
			RegisterPortAdapter<ITitleScreenTouchPort, TitleScreenHomeLoader>();
//		}

//		protected override void AddOutboundAdapters()
//		{
			RegisterPortAdapter<ILoadHomeScenePort, GameSceneLoader>();
		}
	}

}