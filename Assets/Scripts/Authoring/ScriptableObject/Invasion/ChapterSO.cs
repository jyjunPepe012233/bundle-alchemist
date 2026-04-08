using System.Collections.Generic;
using Core.Type;
using Data.Invasion;
using UnityEngine;

namespace Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Chapter")]
	public class ChapterSO : UnityEngine.ScriptableObject, IChapterData
	{
		[SerializeField] private string _chapterName;
		public string ChapterName => _chapterName;
	
		[SerializeField] private InterfaceRefs<IStageData> _stages;
		public IReadOnlyCollection<IStageData> Stages => _stages.Value;
	}

}
