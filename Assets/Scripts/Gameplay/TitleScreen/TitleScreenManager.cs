using Gameplay.Ports.Inbound;
using Gameplay.Ports.Outbound;

namespace Gameplay.TitleScreen
{

	public class TitleScreenManager : ITitleScreenManagerPort
	{
		private readonly ILoadHomePort _loadHomeScenePort;
		private readonly ILoadingServicePort _loadingServicePort;
		
		public TitleScreenManager(ILoadHomePort loadHomePort, ILoadingServicePort loadingServicePort)
		{
			_loadHomeScenePort = loadHomePort;
			_loadingServicePort = loadingServicePort;
		}

		public void Touched()
		{
			var loadingTask = _loadHomeScenePort.GetLoadingHomeTask();
			_loadingServicePort.StartLoadingWithTransition(loadingTask);
		}
	}

}