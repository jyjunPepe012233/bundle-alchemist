using System.Collections;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface IControlLoadingOverlayPort
	{
		IEnumerator LoadLoadingOverlay();

		IEnumerator UnloadLoadingOverlay();
	}

}