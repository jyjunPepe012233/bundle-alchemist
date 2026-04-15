using System.Collections.Generic;

namespace Data.Invasion
{

	public interface IChapterData
	{
		string ChapterName { get; }
		
		IReadOnlyCollection<IStageData> Stages { get; }
	}
	
}