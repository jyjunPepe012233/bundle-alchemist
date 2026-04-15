using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Infrastructure.Loading
{

	public class LoadHomeService : ILoadHomePort
	{
		public ILoadingTaskPort GetLoadingHomeTask()
		{
			return new SceneLoadingTask("Home");
		}
	}

}