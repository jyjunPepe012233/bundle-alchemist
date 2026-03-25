public static class LoadingCommands
{
	public struct StartLoadingCommand : ICommand
	{
		public ILoadingContextHolder LoadingContextHolder { get; }

		public StartLoadingCommand(ILoadingContextHolder loadingContextHolder)
		{
			LoadingContextHolder = loadingContextHolder;
		}
	}
}
