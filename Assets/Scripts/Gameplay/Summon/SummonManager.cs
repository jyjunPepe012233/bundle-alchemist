using System;
using System.Collections;
using ProjectB.Core.Supports;
using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Static.Soldier;
using ProjectB.Data.Types;
using ProjectB.Gameplay.Ports.Inbound.Summon;
using ProjectB.Gameplay.Ports.Outbound;
using UnityEngine;

namespace ProjectB.Gameplay.Summon
{

	public class SummonManager : ISummonServicePort, ISummonAnimationManagerPort
	{
		private readonly ISoldierDatabase _soldierDatabase;
		private readonly ILoadSummonAnimationScreenPort _loadSummonAnimationScreenPort;
		
		public event Action<SummonResult> StartAnimation;
		public event Action AnimationPerfectlyUnloaded;

		// 외부에서는 ISummonAnimationManagerPort.AnimationFinished() 메서드를 통해서 애니메이션 종료를 알리고
		// AnimationFinished() 메서드가 _AnimationFinishedInternal 이벤트를 호출하는 형태로 구현함.
		// (코루틴 중에 애니메이션 종료를 알아야 하기 때문임)
		private event Action _AnimationFinishedInternal;

		private bool _isAnimationPlaying;
		
		public SummonManager(ISoldierDatabase soldierDatabase, ILoadSummonAnimationScreenPort loadSummonAnimationScreenPort)
		{
			_soldierDatabase = soldierDatabase;
			_loadSummonAnimationScreenPort = loadSummonAnimationScreenPort;
		}

		
		public void Summon(SummonType type)
		{
			if (type == SummonType.Summon1x)
			{
				Summon1x();
			}
			else if (type == SummonType.Summon10x)
			{
				Summon10x();
			}
		}
		
		void Summon1x()
		{
			if (_isAnimationPlaying)
			{
				// 이미 애니메이션이 재생 중인 경우, 모집을 방지
				return;
			}
			
			// 단수 모집
			int i = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
			var soldier = _soldierDatabase.Soldiers[i];
			
			LoadSummonAnimation(new SummonResult(new []{ soldier }, SummonType.Summon1x));
		}

		void Summon10x()
		{
			if (_isAnimationPlaying) return;
			
			ISoldierData[] summonedSoldiers = new ISoldierData[10];
			for (int i = 0; i < 10; i++)
			{
				int random = UnityEngine.Random.Range(0, _soldierDatabase.Soldiers.Count);
				summonedSoldiers[i] = _soldierDatabase.Soldiers[random];
			}

			LoadSummonAnimation(new SummonResult(summonedSoldiers, SummonType.Summon10x));
		}
		
		
		
		void LoadSummonAnimation(SummonResult result)
		{
			CoroutineHandler.StartAndAdd(SummonAnimationCoroutine(result));
		}

		IEnumerator SummonAnimationCoroutine(SummonResult result)
		{
			if (_isAnimationPlaying)
			{
				// 애니메이션이 재생 중인 경우 애니메이션 로드 방지
				// 이미 위 메서드들에서 체크하고 있지만 확장 시 체크를 누락할 수 있으므로 한번 더 체크
				Debug.LogError("모집 연출이 이미 재생 중이지만 다시 재생하려고 시도했습니다.");
				yield break;
			}
			
			_isAnimationPlaying = true;
			
			// 애니메이션 로드 및 시작 (뽑기 결과 전달)
			yield return _loadSummonAnimationScreenPort.LoadSummonAnimationScreen();
			StartAnimation?.Invoke(result);

			// 애니메이션 주체가 애니메이션이 끝났음을 알릴 때까지 대기
			bool isFinished = false;
			_AnimationFinishedInternal += () => isFinished = true;
			yield return new WaitUntil(() => isFinished);

			// 애니메이션 정리
			yield return _loadSummonAnimationScreenPort.UnloadSummonAnimationScreen();
			AnimationPerfectlyUnloaded?.Invoke();
			
			_isAnimationPlaying = false;
		}
		
		// 외부의 애니메이션 연출 주체가 애니메이션이 끝났음을 알리는 메서드
		public void FinishAnimation()
		{
			_AnimationFinishedInternal?.Invoke();
		}
	}

}