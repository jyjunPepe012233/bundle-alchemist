public interface ILoadingContextHolder
{
	bool IsDone { get; }
	
	float Progress { get; }

	void Load();
}
