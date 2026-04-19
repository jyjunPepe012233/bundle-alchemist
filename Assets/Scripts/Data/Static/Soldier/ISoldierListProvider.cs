using System.Collections.Generic;

namespace ProjectB.Data.Static.Soldier
{

	public interface ISoldierListProvider
	{
		// 코드베이스에서는 왠만하면 배열 대신 IEnumerable<T>을 사용하고 있으나 모집, 데이터 조회 등의 케이스에서
		// List로 보관하는 편이 훨씬 나아서 IReadOnlyList<T>로 타입을 바꿈
		// 26.04.19. IEnumerable<T> -> IReadOnlyList<T>
		IReadOnlyList<ISoldierData> Soldiers { get; }
	}

}