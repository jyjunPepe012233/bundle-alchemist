using System;
using System.Collections;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectB.UI.Screens.SummonAnimationScreen
{
	
	[Serializable]
	public class SummonAnimationScreenView : UIView
	{
		[SerializeField] private PlayableDirector _playableDirector;

		// 가비지 생성을 최소화하기 위해 재활용
		private WaitForSeconds _waitUntilTimelineFinish;
		
		
		
		public IEnumerator StartAnimation()
		{
			_playableDirector.Play();

			if (_waitUntilTimelineFinish == null)
			{
				_waitUntilTimelineFinish = new WaitForSeconds((float)_playableDirector.duration); // double -> float
			}

			yield return _waitUntilTimelineFinish;
		}
	}

}