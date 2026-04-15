using Composition.Core;

namespace Dependency.Scopes
{

	public class LoadingScreenLifetimeScope : StructuredLifetimeScope
	{
		// Loading과 관련된 포트를 왜 여기에 등록하지 않고 CoreLifetimeScope에 등록했는가?
		
		// 왜냐하면 Loading과 관련된 서비스는 로딩 화면 뿐만이 아니라 모든 곳에서 사용할 수 있어야 하기 때문임
		
		// 따라서 이 Scope의 목적은 로딩과 관련된 UI/오브젝트들이 CoreLifetimeScope를 세팅한 오브젝트에 직접 접근하지 않고,
		// Parent Scope를 통해 설정된 Core Lifetime Scope를 통해 간접적으로 주입받을 수 있도록 하는 것임
	}

}