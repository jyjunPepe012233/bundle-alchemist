using System.Collections;

namespace Gameplay.Ports.Outbound
{

	public interface ILoadLoadingOverlayPort
	{
		IEnumerator LoadLoadingOverlay();

		IEnumerator UnloadLoadingOverlay();
	}

}