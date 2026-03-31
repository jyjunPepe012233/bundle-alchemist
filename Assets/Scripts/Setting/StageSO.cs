using UnityEngine;

[CreateAssetMenu(menuName = "Stage")]
public class StageSO : ScriptableObject
{
	[SerializeField] private string _stageName;
	public string StageName => _stageName;
}
