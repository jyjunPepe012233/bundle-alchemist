using System;

namespace Gameplay.Ports.Inbound
{

	public interface ILoadingOverlayManagerPort
	{
		public event Action LoadingStarted;
		public event Action LoadingFinished;
		
		void TransitionReadied();
		void TransitionDisposed();
	}

}