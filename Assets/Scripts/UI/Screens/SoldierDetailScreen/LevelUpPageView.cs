using System;
using ProjectB.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Screens.SoldierDetailScreen
{

	[Serializable]
	public class LevelUpPageView : SoldierDetailPageView
	{
		[Header("Consume Food Button")]
		[SerializeField] private Button _consumeFoodButton;
		[SerializeField] private TextMeshProUGUI _consumeFoodAmountText;

		public event Action ConsumeFoodButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_consumeFoodButton.onClick.AddListener(OnConsumeFoodButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_consumeFoodButton.onClick.RemoveListener(OnConsumeFoodButtonClicked);
		}

		void OnConsumeFoodButtonClicked()
		{
			ConsumeFoodButtonClicked?.Invoke();
		}
		
		public void SetConsumeFoodAmount(int amount)
		{
			_consumeFoodAmountText.text = amount.ToString();
		}
	}

}