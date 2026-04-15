using UnityEngine;
using VContainer;

namespace ProjectB.Dependency.Installers
{

	public abstract class DIBasedPortInstaller<T> : MonoBehaviour where T : class
	{
		public T Port { get; private set; }
		
		[Inject]
		public void Install(T port)
		{
			Port = port;
		}
	}

}