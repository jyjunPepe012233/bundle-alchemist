using System;
using UnityEngine;

public interface IProvideTouchInfo
{
	event Action<Touch> TouchBegan;
}
