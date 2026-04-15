using System;
using System.Collections;
using UI.Presentation.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace UI.Presentation.Screens.LoadingOverlay
{

	[Serializable]
	public class LoadingOverlayView : UIView
	{
		[SerializeField] private PlayableDirector _playableDirector;

		private bool isAnimating = false;

		[SerializeField] private PlayableAsset _openTransitionAnim;
		[SerializeField] private PlayableAsset _closeTransitionAnim;

		private IEnumerator WaitUntilTimelineFinish(PlayableAsset asset)
		{
			if (isAnimating)
				yield return new WaitUntil(() => !isAnimating);
		
			isAnimating = true;
		
			_playableDirector.Play(asset);
			yield return new WaitForSeconds((float)asset.duration);

			isAnimating = false;
		}
	
		public IEnumerator OpenTransitionCoroutine()
		{
			yield return WaitUntilTimelineFinish(_openTransitionAnim);
		}
	
		public IEnumerator CloseTransitionCoroutine()
		{
			yield return WaitUntilTimelineFinish(_closeTransitionAnim);
		}
	}

}
