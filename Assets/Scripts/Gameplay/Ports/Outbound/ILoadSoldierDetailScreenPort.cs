using System.Collections;
using ProjectB.Data.Runtime.Player;

namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadSoldierDetailScreenPort
	{
		bool IsLoaded { get; }
		
		IEnumerator Load(IReadOnlyPlayerSoldier playerSoldier); // 이 클래스는 함수명을 일부러 조금 간략하게 지어봄

		IEnumerator Unload();
	}

}