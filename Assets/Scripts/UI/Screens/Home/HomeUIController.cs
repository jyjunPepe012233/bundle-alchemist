using System.Collections.Generic;
using UnityEngine;

namespace ProjectB.UI.Screens.Home
{

	public class HomeUIController : MonoBehaviour
	{
		private readonly Dictionary<string, IHomeOverlay> _screens = new(); // overlayID, overlay

		private readonly Stack<IHomeOverlay> _overlayStack = new(2);

		private void Awake()
		{
//			HomeUIEventBus.OpenOverlay += OnOpenOverlay;
//			HomeUIEventBus.CloseOverlay += OnCloseOverlay;
		}

		private void OnDestroy()
		{
//			HomeUIEventBus.OpenOverlay -= OnOpenOverlay;
//			HomeUIEventBus.CloseOverlay -= OnCloseOverlay;
		}

		private void OnOpenOverlay(string overlayID)
		{
			if (!_screens.ContainsKey(overlayID))
			{
				Debug.LogError($"[{nameof(HomeUIController)}] 등록되지 않은 OverlayID: {overlayID}");
				return;
			}

			IHomeOverlay overlay = _screens[overlayID];
			OpenOverlay(overlay);
		}
	
		private void OnCloseOverlay()
		{
			CloseOverlay();
		}

		private void OpenOverlay(IHomeOverlay overlay)
		{
			if (_overlayStack.Count != 0)
			{
				IHomeOverlay currentOverlay = _overlayStack.Peek();
				currentOverlay.Hide();
			}
		
			_overlayStack.Push(overlay);
			overlay.Open();
		}

		private void CloseOverlay()
		{
			if (_overlayStack.Count == 0)
			{
				Debug.LogWarning($"[{nameof(HomeUIController)}] 닫을 Overlay가 없음");
				return;
			}
		
			IHomeOverlay overlay = _overlayStack.Pop();
			overlay.Close();
		
			if (_overlayStack.Count != 0)
			{
				IHomeOverlay nextOverlay = _overlayStack.Peek();
				nextOverlay.Show();
			}
		}
	
		public void RegisterOverlay(IHomeOverlay overlay)
		{
			if (overlay == null)
			{
				Debug.LogError($"[{nameof(HomeUIController)}] Overlay가 null임");
				return;
			}
		
			if (_screens.ContainsKey(overlay.OverlayID))
			{
				Debug.LogWarning($"[{nameof(HomeUIController)}] 이미 등록된 Overlay임: {overlay.GetType().Name}");
				return;
			}
		
			_screens.Add(overlay.OverlayID, overlay);
			overlay.Hide();
		}
	}

}
