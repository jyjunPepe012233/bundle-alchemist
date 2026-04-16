namespace ProjectB.UI.Screens.Home
{

	public interface IHomeFullScreenOverlay
	{
		string OverlayID { get; }

		// 오버레이가 처음 열릴 때 호출됨
		void Open();

		// 오버레이가 화면에서 사라질 때 호출됨 (예: 다른 오버레이가 열려 덮어씌워짐)
		void Hide();

		// 오버레이가 다시 화면에 나타날 때 호출됨 (예: 덮어씌웠던 오버레이가 닫혀 다시 보임)
		void Show();
	
		// 오버레이가 완전히 닫힐 때 호출됨
		void Close();
	}

}