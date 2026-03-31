using UnityEngine;

[CreateAssetMenu(menuName = "Stage")]
public class StageSO : ScriptableObject
{
	[SerializeField] private ChapterSO _chapter;
	public ChapterSO Chapter => _chapter;
	
	[SerializeField] private string _stageName;
	public string StageName => _stageName;
}
