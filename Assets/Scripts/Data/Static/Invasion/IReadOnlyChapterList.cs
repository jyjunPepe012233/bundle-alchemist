using System.Collections.Generic;

namespace Data.Invasion
{

	public interface IReadOnlyChapterList
	{
		IReadOnlyCollection<IChapterData> Chapters { get; }
	}

}