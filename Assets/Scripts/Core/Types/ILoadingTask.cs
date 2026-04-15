namespace Core.Models
{

	public interface ILoadingTask
	{
		bool IsDone { get; }
	
		float Progress { get; }

		void Load();
	}

}
