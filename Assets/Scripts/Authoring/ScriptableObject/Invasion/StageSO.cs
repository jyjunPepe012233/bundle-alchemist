using ProjectB.Data.Static.Invasion;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Project B/Invasion/Stage")]
	public class StageSO : UnityEngine.ScriptableObject, IStageData
	{
		[SerializeField] private string _stageName;
		public string StageName => _stageName;
	}

}
