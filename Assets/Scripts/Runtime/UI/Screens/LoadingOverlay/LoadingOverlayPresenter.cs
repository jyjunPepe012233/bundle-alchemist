using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingOverlayPresenter : UIPresenter<LoadingOverlayView>
{
	protected override void SetupSubscriptions()
	{
		base.SetupSubscriptions();
		
		LoadingTransitionEventBus.LoadingStarted += OnLoadingStarted;
		LoadingTransitionEventBus.LoadingFinished += OnLoadingFinished;
	}

	protected override void DisposeSubscriptions()
	{
		base.DisposeSubscriptions();
		
		LoadingTransitionEventBus.LoadingStarted -= OnLoadingStarted;
		LoadingTransitionEventBus.LoadingFinished -= OnLoadingFinished;
	}

	private void OnLoadingStarted()
	{
		IEnumerator Coroutine()
		{
			yield return view.OpenTransitionCoroutine();
			LoadingTransitionEventBus.TransitionReadied?.Invoke();
		}
		StartCoroutine(Coroutine());
	}

	private void OnLoadingFinished()
	{
		IEnumerator Coroutine()
		{
			yield return view.CloseTransitionCoroutine();
			LoadingTransitionEventBus.TransitionDisposed?.Invoke();
		}
		StartCoroutine(Coroutine());
	}
}
