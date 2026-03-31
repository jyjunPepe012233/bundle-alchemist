using System.Collections.Generic;
using UnityEngine;

public class InvasionLevelQueryService
{
	private static InvasionLevelQueryService _instance;
	
	private ChapterDatabaseSO _db;

	private Dictionary<StageSO, Levels> _stageLevels = new();

	public InvasionLevelQueryService(ChapterDatabaseSO db)
	{
		_db = db;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void Initialize()
	{
		var db = Resources.Load<ChapterDatabaseSO>("Chapter Database");
		_instance = new InvasionLevelQueryService(db);
	}
	
	public static InvasionLevelQueryService Inject()
	{
		return _instance;
	}
	
	public void GetLevelsOfStage(StageSO stage, out int chapterLevel, out int stagelevel)
	{
		if (_stageLevels.TryGetValue(stage, out var levels))
		{
			chapterLevel = levels.chapterLevel;
			stagelevel = levels.stageLevel;
			return;
		}
		
		for (int i = 0; i < _db.Chapters.Count; i++)
		{
			var chapter = _db.Chapters[i];
			for (int j = 0; j < chapter.Stages.Count; j++)
			{
				if (chapter.Stages[j] == stage)
				{
					chapterLevel = i + 1;
					stagelevel = j + 1;
					_stageLevels[stage] = new Levels { chapterLevel = i, stageLevel = j };
					return;
				}
			}
		}

		Debug.LogError($"스테이지 {stage}가 챕터 데이터베이스에 등록되어 있지 않음");
		chapterLevel = 0;
		stagelevel = 0;
	}

	private struct Levels
	{
		public int chapterLevel;
		public int stageLevel;
	}
}
