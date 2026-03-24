using System;
using UnityEngine;

public class ClickService : MonoBehaviour, IProvideTouchInfo
{
	private static ClickService _singleton;
	public static ClickService Singleton
	{
		get
		{
			if (_singleton == null)
			{
				Debug.LogError($"[{nameof(ClickService)}] 싱글톤 객체가 존재하지 않음");
			}
			return _singleton;
		}
	}

	public event Action<Touch> TouchBegan;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void InitializeSingleton()
	{
		if (_singleton == null)
		{
			GameObject clickServiceObject = new GameObject("ClickService", typeof(ClickService));
			_singleton = clickServiceObject.GetComponent<ClickService>();
			DontDestroyOnLoad(clickServiceObject);
		}
	}

	public void Update()
	{
		if (Input.touchCount != 0)
		{
			Touch touch = Input.touches[0];
			if (touch.phase == TouchPhase.Began)
			{
				TouchBegan?.Invoke(touch);
			}
		}
	}
}
