using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Composition.Core
{

	// 구조화된 LifetimeScope 작성을 위해 메서드를 제공하는 추상 클래스
	public abstract class StructuredLifetimeScope : LifetimeScope
	{
		// Configure 시작 시 바로 등록됨
		private IContainerBuilder _builder;
		
		// 구조화된 LifetimeScope 작성을 위해 이 클래스에서 제공하는 추상 메서드를 통해서만 어댑터들을 등록할 수 있게 함
		protected override void Configure(IContainerBuilder builder)
		{
			_builder = builder;
			
			base.Configure(builder);
			
			AddInboundAdapters();
			AddOutboundAdapters();
		}

		/// <summary>
		/// Gameplay 어셈블리에 구현된 Inbound Ports들의 어댑터들을 등록
		/// </summary>
		protected virtual void AddInboundAdapters()
		{
			
		}

		/// <summary>
		/// Infrastructure 어셈블리에 구현된 Outbound Ports들의 어댑터들을 등록
		/// </summary>
		protected virtual void AddOutboundAdapters()
		{
			
		}

		/// <summary>
		/// Infrastructure 내부 시스템을 등록 (예시: SceneLoader 등)
		/// </summary>
		protected virtual void AddInfrastructure()
		{
			
		}
		
		protected void RegisterSingleSystem<T>() where T : class
		{
			_builder.Register<T>(Lifetime.Singleton).As<T>();
		}
		
		/// <summary>
		/// 이 메서드를 통해서만 Port-Adapter를 등록할 수 있도록 함
		/// </summary>
		protected void RegisterPortAdapter<TPort, TAdapter>()
			where TPort : class
			where TAdapter : class, TPort
		{
			_builder.Register<TAdapter>(Lifetime.Singleton).As<TPort>();
		}
	}

}