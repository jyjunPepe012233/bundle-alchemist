using System.Collections.Generic;
using Core.Type;
using Data.Invasion;
using UnityEngine;

namespace Authoring.ScriptableObject.Invasion
{

	[CreateAssetMenu(menuName = "Chapter Database")]
	public class ChapterDatabaseSO : UnityEngine.ScriptableObject, IChapterList
	{
		[SerializeField] private InterfaceRefs<IChapterData> _chapters;
		public IReadOnlyCollection<IChapterData> Chapters => _chapters.Value;
	}

}
