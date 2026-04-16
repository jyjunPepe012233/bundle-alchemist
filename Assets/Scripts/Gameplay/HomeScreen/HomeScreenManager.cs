using ProjectB.Gameplay.Ports.Inbound;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay.HomeScreen
{

	public class HomeScreenManager : IHomeScreenManagerPort
	{
		private readonly ILoadSummonScreenPort _loadSummonScreenPort;
		private readonly IUnloadScreenPort _unloadScreenPort;
		
		public HomeScreenManager(ILoadSummonScreenPort loadSummonScreenPort, IUnloadScreenPort unloadScreenPort)
		{
			_loadSummonScreenPort = loadSummonScreenPort;
			_unloadScreenPort = unloadScreenPort;
		}

		public void OpenSummonScreen()
		{
			_loadSummonScreenPort.LoadSummonScreen();
		}

		public void CloseCurrentScreen()
		{
			_unloadScreenPort.UnloadCurrentScreen();
		}
	}

}