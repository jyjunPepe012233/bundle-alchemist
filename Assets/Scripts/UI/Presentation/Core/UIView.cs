using System;
using UnityEngine;

namespace UI.Presentation.Core
{

	[Serializable]
	public abstract class UIView : IDisposable
	{
		[SerializeField] private GameObject _topElement;

		public virtual void RegisterUICallbacks()
		{
		
		}

		public virtual void Dispose()
		{
		
		}
	
		public virtual void Show()
		{
			_topElement?.SetActive(true);
		}
	
		public virtual void Hide()
		{
			_topElement?.SetActive(false);
		}
	}

}
