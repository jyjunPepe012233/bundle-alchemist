using System;

public static class LoadingTransitionEventBus
{
	// 1.
	public static Action LoadingStarted;

	// 2.
	// 시작 요청 후, 트랜지션이 준비되었음을 알리는 이벤트
	// 트랜지션이 준비된 뒤에 실제 로딩을 시작함
	public static Action TransitionReadied;
	
	// 3.
	// 실제 로딩이 끝났음을 알림
	public static Action LoadingFinished;
		

	// 4.
	// 트랜지션을 종료한 뒤 마지막으로 호출되는 이벤트
	public static Action TransitionDisposed;
}
