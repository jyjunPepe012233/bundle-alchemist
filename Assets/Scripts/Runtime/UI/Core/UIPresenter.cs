using UnityEngine;

public abstract class UIPresenter<TView> : MonoBehaviour where TView : UIView
{
	[SerializeField] protected TView view;

	public void Awake()
	{
		view.RegisterUICallbacks();
		SetupSubscriptions();
	}

	public void Start()
	{
		InitializeView();
	}
	
	public void OnDestroy()
	{
		view.Dispose();
		DisposeSubscriptions();
	}
	
	protected virtual void SetupSubscriptions()
	{
		
	}

	protected virtual void DisposeSubscriptions()
	{
		
	}
	
	protected virtual void InitializeView()
	{
		
	}

	public virtual void Show()
	{
		view?.Show();
	}

	public virtual void Hide()
	{
		view?.Hide();
	}
}
