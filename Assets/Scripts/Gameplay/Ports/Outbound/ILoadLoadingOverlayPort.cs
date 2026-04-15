using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadLoadingOverlayPort
	{
		IEnumerator LoadLoadingOverlay();

		IEnumerator UnloadLoadingOverlay();
	}

}