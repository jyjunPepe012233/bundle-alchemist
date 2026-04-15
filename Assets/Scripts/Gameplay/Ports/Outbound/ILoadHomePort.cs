using Core.Models;

namespace Gameplay.Ports.Outbound
{

	public interface ILoadHomePort
	{
		ILoadingTaskPort GetLoadingHomeTask();
	}

}