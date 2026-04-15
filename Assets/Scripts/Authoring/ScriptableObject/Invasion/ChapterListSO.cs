using System.Collections.Generic;
using ProjectB.Core.Types;
using ProjectB.Data.Static.Invasion;
using UnityEngine;

namespace ProjectB.Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Chapter List")]
	public class ChapterListSO : UnityEngine.ScriptableObject, IReadOnlyChapterList
	{
		[SerializeField] private InterfaceRefs<IChapterData> _chapters;
		public IReadOnlyCollection<IChapterData> Chapters => _chapters.Value;
	}

}
