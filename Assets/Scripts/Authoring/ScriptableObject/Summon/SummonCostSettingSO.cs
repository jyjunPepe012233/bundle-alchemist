using ProjectB.Data.Static.Summon;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Summon
{

	[CreateAssetMenu(menuName = "Summon Price Settings")]
	public class SummonCostSettingSO : UnityEngine.ScriptableObject, ISummonCostSetting
	{
		[SerializeField] private int _price1x;
		public int Price1x => _price1x;

		[SerializeField] private int _price10x;
		public int Price10x => _price10x;
	}

}