using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure
{

	public class LoadHomeService : ILoadHomePort
	{
		public ILoadingTaskPort GetLoadingHomeTask()
		{
			return new SceneLoadingTask("Home");
		}
	}

}