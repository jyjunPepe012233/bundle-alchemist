using ProjectB.Data.Static.Spirit;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Spirit
{

	[CreateAssetMenu(menuName = "Spirit")]
	public class SpiritSO : UnityEngine.ScriptableObject, ISpiritData
	{
		[SerializeField] private string _spiritName;
		public string SpiritName => _spiritName;
		
		[SerializeField] private Color _color;
		public Color Color => _color;
		
		[SerializeField] private Sprite _icon64;
		public Sprite Icon64 => _icon64;
	}

}