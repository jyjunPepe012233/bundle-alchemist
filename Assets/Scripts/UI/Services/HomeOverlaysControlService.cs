using ProjectB.UI.Screens.Home;
using UnityEngine;

namespace ProjectB.UI.Services
{

	public class HomeOverlaysControlService : MonoBehaviour
	{
		public string CurrentOverlayID => HomeOverlaysController.CurrentOverlayID;
		
		public void OpenOverlay(string overlayId)
		{
			HomeOverlaysController.OpenOverlay?.Invoke(overlayId);
		}
		
		public void CloseOverlay()
		{
			HomeOverlaysController.CloseOverlay?.Invoke();
		}
	}

}