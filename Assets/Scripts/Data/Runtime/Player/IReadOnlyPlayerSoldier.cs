using System;

namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerSoldier
	{
		string SoldierId { get; }
		
		int Exp { get; }
		
		short Level { get; } // TODO: 그냥 int로 바꾸기. 메모리 2byte 줄여봐야 의미 없음 (메서드 호환성 안 좋음)

		event Action ExpChanged;

		event Action LevelChanged;
	}

}