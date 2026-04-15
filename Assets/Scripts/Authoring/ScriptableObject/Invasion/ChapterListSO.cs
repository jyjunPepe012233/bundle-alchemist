using System.Collections.Generic;
using Core.Types;
using Data.Invasion;
using UnityEngine;

namespace Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Chapter List")]
	public class ChapterListSO : UnityEngine.ScriptableObject, IReadOnlyChapterList
	{
		[SerializeField] private InterfaceRefs<IChapterData> _chapters;
		public IReadOnlyCollection<IChapterData> Chapters => _chapters.Value;
	}

}
