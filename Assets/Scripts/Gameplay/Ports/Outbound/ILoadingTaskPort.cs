namespace ProjectB.Gameplay.Ports.Outbound
{

	public interface ILoadingTaskPort
	{
		bool IsDone { get; }
	
		float Progress { get; }

		void Load();
	}

}
