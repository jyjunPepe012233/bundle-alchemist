using UnityEngine;
using VContainer;

namespace ProjectB.Dependency.Installers
{

	public abstract class DIBasedPortInstaller<T> : MonoBehaviour where T : class
	{
		// Port를 주입받지 못할 때는 CoreLifetimeScope가 있는 씬에서 게임을 시작했는지 확인해볼 것!
		
		public T Port { get; private set; }
		
		[Inject]
		public void Install(T port)
		{
			Port = port;
		}
	}

}