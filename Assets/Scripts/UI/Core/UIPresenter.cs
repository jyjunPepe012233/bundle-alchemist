using UnityEngine;

namespace ProjectB.UI.Core
{

	public abstract class UIPresenter<TView> : MonoBehaviour where TView : UIView
	{
		[SerializeField] protected bool initializeOnShow = true;
		[SerializeField] protected bool initializeOnEnable = true;
		[SerializeField] protected TView view;

		public void Awake()
		{
			view.RegisterUICallbacks();
		}

		public void Start()
		{
			SetupReferences();
			SetupSubscriptions();
			InitializeView();
		}
	
		public void OnDestroy()
		{
			view.Dispose();
			DisposeSubscriptions();
		}

		public void OnEnable()
		{
			if (initializeOnShow)
			{
				InitializeView();
			}
		}

		protected virtual void SetupReferences()
		{
			
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
			if (initializeOnShow)
			{
				InitializeView();
			}
			
			view?.Show();
		}

		public virtual void Hide()
		{
			view?.Hide();
		}
	}

}
