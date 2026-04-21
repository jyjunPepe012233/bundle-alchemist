namespace ProjectB.Dependency.Scopes
{

	public class SummonAnimationScreenLifetimeScope : StructuredLifetimeScope
	{
		// SummonScreenLifetimeScope을 Parent로 가짐 
		
		// 따라서 Summon Animation 화면에서도 SummonManager 싱글톤 객체에 접근할 수 있음 
	}

}