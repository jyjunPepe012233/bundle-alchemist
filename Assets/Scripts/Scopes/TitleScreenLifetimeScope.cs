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
		protected override void AddInboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<ITitleScreenTouchPort, TitleScreenHomeLoader>();
		}

		protected override void AddOutboundAdapters()
		{
			base.AddInboundAdapters();
			RegisterPortAdapter<ILoadHomeScenePort, GameSceneLoader>();
		}
	}

}