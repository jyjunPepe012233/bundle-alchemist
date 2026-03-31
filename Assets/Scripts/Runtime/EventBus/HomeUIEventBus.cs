using System;

public static class HomeUIEventBus
{
	public static Action<string> OpenOverlay;
	public static Action CloseOverlay;

	public static class WorldMapScreen
	{
		public static Action<StageSO> StageInfoButtonClicked;
	}
}
