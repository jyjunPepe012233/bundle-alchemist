using Data.Invasion;
using UnityEngine;

namespace Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Stage")]
	public class StageSO : UnityEngine.ScriptableObject, IStageData
	{
		[SerializeField] private string _stageName;
		public string StageName => _stageName;
	}

}
