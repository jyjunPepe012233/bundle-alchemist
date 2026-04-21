using UnityEngine;

namespace ProjectB.Core.Supports
{

	public class Note : MonoBehaviour
	{
		
#if UNITY_EDITOR
		[TextArea(3, 10)]
		public string note;
#endif
		
	}

}