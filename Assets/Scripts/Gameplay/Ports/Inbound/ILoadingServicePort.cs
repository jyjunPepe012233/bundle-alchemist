using Core.Models;

namespace Gameplay.Ports.Inbound
{

	public interface ILoadingServicePort
	{
		void StartLoadingWithTransition(ILoadingTaskPort loadingTaskPort);
	}

}