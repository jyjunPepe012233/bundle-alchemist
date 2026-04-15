using System.Collections.Generic;

namespace ProjectB.Data.Static.Invasion
{

	public interface IChapterData
	{
		string ChapterName { get; }
		
		IReadOnlyCollection<IStageData> Stages { get; }
	}
	
}