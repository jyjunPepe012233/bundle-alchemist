using Core.Models;
using Gameplay.Ports.Outbound;

namespace Infrastructure.LoadHome
{

	public class LoadHomeService : ILoadHomePort
	{
		public ILoadingTaskPort GetLoadingHomeTask()
		{
			return new SceneLoadingTask("Home");
		}
	}

}