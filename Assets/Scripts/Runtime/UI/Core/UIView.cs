using System;
using UnityEngine;

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
}
