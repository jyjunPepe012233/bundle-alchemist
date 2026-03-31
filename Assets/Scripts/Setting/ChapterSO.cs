using UnityEngine;

[CreateAssetMenu(menuName = "Chapter")]
public class ChapterSO : ScriptableObject
{
	[SerializeField] private string _chapterName;
	public string ChapterName => _chapterName;

	[SerializeField] private StageSO[] _stages;
}
