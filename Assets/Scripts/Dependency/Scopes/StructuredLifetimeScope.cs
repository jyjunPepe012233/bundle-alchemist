using VContainer;
using VContainer.Unity;

namespace ProjectB.Dependency.Scopes
{

	// 구조화된 LifetimeScope 작성을 위해 메서드를 제공하는 추상 클래스
	public abstract class StructuredLifetimeScope : LifetimeScope
	{
		// Configure 시작 시 바로 등록됨
		private IContainerBuilder _builder;
		
		// 직접 Builder를 사용하여 Register할 수도 있게 함
		protected IContainerBuilder Builder => _builder;
		
		// 구조화된 LifetimeScope 작성을 위해 이 클래스에서 제공하는 추상 메서드를 통해서만 어댑터들을 등록할 수 있게 함
		protected sealed override void Configure(IContainerBuilder builder)
		{
			_builder = builder;
			
			base.Configure(builder);
			
			// 컨테이너에 Register하는 순서는 상관 없음
			AddInboundAdapters();
			AddInternalAdapters();
			AddOutboundAdapters();
			AddInfrastructure();
			AddData();
		}

		/// <summary>
		/// Gameplay 어셈블리에 구현된 Inbound Ports들의 어댑터들을 등록
		/// </summary>
		protected virtual void AddInboundAdapters()
		{
			
		}
		
		/// <summary>
		/// Gameplay 어셈블리에 구현된 Internal Ports들의 어댑터들을 등록
		///	</summary>
		protected virtual void AddInternalAdapters()
		{
			
		}

		/// <summary>
		/// Infrastructure 어셈블리에 구현된 Outbound Ports들의 어댑터들을 등록
		/// </summary>
		protected virtual void AddOutboundAdapters()
		{
			
		}
		
		/// <summary>
		/// Data 어셈블리 
		/// </summary>
		protected virtual void AddData()
		{
			
		}

		/// <summary>
		/// Infrastructure 내부 시스템을 등록 (예시: SceneLoader 등)
		/// </summary>
		/*protected virtual*/ void AddInfrastructure() // 사용 안 함
		{

		}

		/// <summary>
		/// 이 메서드를 통해서 Port-Adapter를 편하게 등록할 수 있도록 함
		/// </summary>
		protected void RegisterPortAdapter<TPort, TAdapter>()
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.Register<TAdapter>(Lifetime.Singleton).As<TPort>();
		}


		protected void RegisterPortInstance<TPort, TAdapter>(TAdapter instance)
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.RegisterInstance(instance).As<TPort>();
		} 
	}

}