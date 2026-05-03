using UnityEngine;

namespace ProjectB.UI.Components
{

	public class PrefabIconParent : MonoBehaviour
	{
		[SerializeField] private Transform _parent;

		private GameObject _iconInstance;
		
		public void SetIcon(GameObject prefab)
		{
			if (_iconInstance != null)
			{
				Destroy(_iconInstance);
			}
			
			_iconInstance = Instantiate(prefab, _parent);
		}
	}

}