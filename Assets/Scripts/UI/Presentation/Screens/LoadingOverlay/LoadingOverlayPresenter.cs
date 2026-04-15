using System.Collections;
using UI.Presentation.Core;

namespace UI.Presentation.Screens.LoadingOverlay
{

	public class LoadingOverlayPresenter : UIPresenter<LoadingOverlayView>
	{
//		[SerializeField]
//		private InterfaceRef<IObjectContext> _objectContext;
		
//		private ILoadingTransitionPort _loadingTransitionPort;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();

//			_loadingTransitionPort = _objectContext.Value.Resolve<ILoadingTransitionPort>();

//			_loadingTransitionPort.LoadingStarted += OnLoadingStarted;
//			_loadingTransitionPort.LoadingFinished += OnLoadingFinished;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			
//			_loadingTransitionPort.LoadingStarted -= OnLoadingStarted;
//			_loadingTransitionPort.LoadingFinished -= OnLoadingFinished;
		}

		private void OnLoadingStarted()
		{
			IEnumerator Coroutine()
			{
				yield return view.OpenTransitionCoroutine();
//				_loadingTransitionPort.TransitionReadied?.Invoke();
			}
			StartCoroutine(Coroutine());
		}

		private void OnLoadingFinished()
		{
			IEnumerator Coroutine()
			{
				yield return view.CloseTransitionCoroutine();
//				_loadingTransitionPort.TransitionDisposed?.Invoke();
			}
			StartCoroutine(Coroutine());
		}
	}

}
