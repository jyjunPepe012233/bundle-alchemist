using System.Collections;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Dependency.Installers.Summon;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SummonAnimationScreen
{

	public class SummonAnimationScreenPresenter : UIPresenter<SummonAnimationScreenView>
	{
		[SerializeField] private SummonAnimationManagerPortInstaller _summmonAnimManagerPortInstaller;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			Debug.Log(_summmonAnimManagerPortInstaller.Port);
			_summmonAnimManagerPortInstaller.Port.StartAnimation += OnStartAnimation;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			_summmonAnimManagerPortInstaller.Port.StartAnimation -= OnStartAnimation;
		}

		void OnStartAnimation(SummonResult result)
		{	
			Debug.Log(29);
			StartCoroutine(AnimationCoroutine());
		}

		IEnumerator AnimationCoroutine()
		{
			yield return view.StartAnimation();
			
			// Manager에게 연출이 끝났음을 알림
			_summmonAnimManagerPortInstaller.Port.FinishAnimation();
		}
		
	}

}