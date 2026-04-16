using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface ILoadingServicePort
	{
		void StartLoadingWithTransition(ILoadingTaskPort loadingTaskPort);
	}

}