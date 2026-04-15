using System.Collections;
using Gameplay.Ports.Inbound;
using UI.Installers;
using UI.Presentation.Core;
using UnityEngine;

namespace UI.Presentation.Screens.LoadingOverlay
{

	public class LoadingOverlayPresenter : UIPresenter<LoadingOverlayView>
	{
		[SerializeField] private LoadingOverlayManagerPortInstaller _loadingOverlayManagerPortInstaller;

		private ILoadingOverlayManagerPort _loadingOverlayManager;
		
		protected override void SetupReferences()
		{
			base.SetupReferences();
			_loadingOverlayManager = _loadingOverlayManagerPortInstaller.Port;
		}

		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			_loadingOverlayManager.LoadingStarted += OnLoadingStarted;
			_loadingOverlayManager.LoadingFinished += OnLoadingFinished;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			
			_loadingOverlayManager.LoadingStarted -= OnLoadingStarted;
			_loadingOverlayManager.LoadingFinished -= OnLoadingFinished;
		}

		private void OnLoadingStarted()
		{
			IEnumerator Coroutine()
			{
				yield return view.OpenTransitionCoroutine();
				_loadingOverlayManager.TransitionReadied();
			}
			StartCoroutine(Coroutine());
		}

		private void OnLoadingFinished()
		{
			IEnumerator Coroutine()
			{
				yield return view.CloseTransitionCoroutine();
				_loadingOverlayManager.TransitionDisposed();
			}
			StartCoroutine(Coroutine());
		}
	}

}
