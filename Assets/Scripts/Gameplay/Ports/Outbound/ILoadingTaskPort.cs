namespace Core.Models
{

	public interface ILoadingTaskPort
	{
		bool IsDone { get; }
	
		float Progress { get; }

		void Load();
	}

}
