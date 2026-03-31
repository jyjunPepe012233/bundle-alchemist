using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chapter Database")]
public class ChapterDatabaseSO : ScriptableObject
{
	[SerializeField] private ChapterSO[] _chapters;
	public IReadOnlyList<ChapterSO> Chapters => _chapters;
}
