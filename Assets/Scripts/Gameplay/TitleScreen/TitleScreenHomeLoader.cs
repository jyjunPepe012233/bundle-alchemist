using Gameplay.Ports;
using Gameplay.Ports.Inbound;
using Gameplay.Ports.Outbound;

namespace Gameplay.TitleScreen
{

	public class TitleScreenHomeLoader : ITitleScreenTouchPort
	{
		private readonly ILoadHomeScenePort _loadHomeScenePort;
		
		public TitleScreenHomeLoader(ILoadHomeScenePort loadHomeScenePort)
		{
			_loadHomeScenePort = loadHomeScenePort;
		}

		public void Touched()
		{
			_loadHomeScenePort.LoadHome();
		}
	}

}