using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
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