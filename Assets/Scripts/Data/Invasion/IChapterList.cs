using System.Collections.Generic;

namespace Data.Invasion
{

	public interface IChapterList
	{
		IReadOnlyCollection<IChapterData> Chapters { get; }
	}

}