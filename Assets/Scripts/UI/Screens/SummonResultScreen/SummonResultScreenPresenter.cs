using ProjectB.Data.Runtime.Summon;
using ProjectB.Data.Types;
using ProjectB.Dependency.Installers.Summon;
using ProjectB.UI.Core;
using UnityEngine;

namespace ProjectB.UI.Screens.SummonResultScreen
{

	public class SummonResultScreenPresenter : UIPresenter<SummonResultScreenView>
	{
		[SerializeField]
		private SummonServicePortInstaller _summonServicePortInstaller;
		
		private SummonType _currentSummonType;
		
		protected override void SetupSubscriptions()
		{
			base.SetupSubscriptions();
			view.CloseButtonClicked += OnCloseButtonClicked;
			view.SummonAgainButtonClicked += OnSummonAgainButtonClicked;

			_summonServicePortInstaller.Port.ShowSummonResult += OnShowSummonResult;
		}

		protected override void DisposeSubscriptions()
		{
			base.DisposeSubscriptions();
			view.CloseButtonClicked -= OnCloseButtonClicked;
			view.SummonAgainButtonClicked -= OnSummonAgainButtonClicked;
			
			_summonServicePortInstaller.Port.ShowSummonResult -= OnShowSummonResult;
		}
		
		void OnShowSummonResult(SummonResult result)
		{
			_currentSummonType = result.type;
			
			view.UpdateSummonedSoldiers(result.summonedSoldiers);
		}
		
		// 다시 모집 시 startanimation을 켜는데, 다시 모집에 붙어있는 또다른 이벤트인 homecloseoverlaybutton의 이벤트가 작동하면서 startanimation 페이지를 닫음
		// 그 뒤에 startanimation 이벤트가 호출되면서 "코루틴을 비활성화된 게임오브젝트에서 실행할 수 없습니다" 메세지가 나 오는거임.
		//
		// 그래서 다시 모집 시 summonresult를 닫은 뒤에(homeoverlay close를 한 뒤에)
		// Summon 함수를 호출하는(SummonAnimation 오버레이를 활성화하는) 방식으로 변경해야 할 듯
		//
		// 아키텍처는 문제 없음. 버튼이 시스템을 호출하는 방식과 순서에 문제가 모여있기 때문에 게임플레이 시스템은 그냥 냅두면 됨.
		// - 26.04.21
			
			
		// 솔직히 SummonResultScreen 자체가 HomeOverlay에 의존하는 구조는 정말 마음에 안 드는데...
		// OnCloseButtonClicked에서 HomeOverlaysController.CloseOverlay를 직접 호출하게 되면 '화면 변경' 로직이
		// UI 시스템과 게임플레이 시스템에 섞이는 것임...

		// 완벽한 구조를 만들기엔 내가 너무 바쁘다... 
		// - 26.04.22
		
		
		// 같은 날짜.
		// ILoadSummonResultScreenPort에 현재 화면이 SummonResult 화면인지 확인하는 플래그를 추가함!
		// 이 플래그를 통해 Summon 전에 화면을 닫는 등의 처리를 할 수 있게 됨
		// 해.결
		
		void OnCloseButtonClicked()
		{
			// CloseButton은 현재 사용하지 않음
			
			// 화면을 닫거나 여는 것은 외부 구현(HomeOverlay, 씬 변경 시스템 등)의 책임이므로
			// 여기서는 단순히 화면을 닫는 버튼을 눌렀을 때의 UI 반응만이 구현됨.
			
			// 26.04.22 기준으로 화면을 닫는 처리는 HomeOverlay 프리팹에서 세팅된
			// HomeCloseOverlayButton 컴포넌트가 처리하고 있음
		}

		void OnSummonAgainButtonClicked()
		{
			// OnCloseButtonClicked()와 마찬가지로 '다시 모집' 시 화면을 닫는 처리는
			// 외부 구현에서 처리하도록 함
			
			_summonServicePortInstaller.Port.Summon(_currentSummonType);
		}
	}

}