using System.Collections.Generic;

namespace ProjectB.Data.Static.Invasion
{

	public interface IReadOnlyChapterList
	{
		IReadOnlyCollection<IChapterData> Chapters { get; }
	}

}