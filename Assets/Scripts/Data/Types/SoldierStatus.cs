using System;

namespace ProjectB.Data.Types
{

	// 병사 스테이터스를 표현할 수 있는 자유로운 구조체 타입이므로
	// 필드는 모두 public으로 선언함
	
	[Serializable]
	public struct SoldierStatus
	{
		public int hp;

		public int sp;

		public int physicalAttack;
		
		public int magicalAttack;
		
		public int physicalDefense;
		
		public int magicalDefense;
		
		public static SoldierStatus operator *(SoldierStatus a, SoldierStatusf b)
		{
			return new SoldierStatus // 초과한 소수점은 내림 처리
			{
				hp = (int)(a.hp * b.hp),
				sp = (int)(a.sp * b.sp),
				physicalAttack = (int)(a.physicalAttack * b.physicalAttack),
				magicalAttack = (int)(a.magicalAttack * b.magicalAttack),
				physicalDefense = (int)(a.physicalDefense * b.physicalDefense),
				magicalDefense = (int)(a.magicalDefense * b.magicalDefense)
			};
		}
	}

}