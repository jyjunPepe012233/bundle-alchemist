using System;
using ProjectB.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Buttons.SoldierDetailNavigateButton
{

	[Serializable]
	public class SoldierDetailNavigateButtonView : UIView
	{
		[SerializeField] private Button _infoPageButton;
		[SerializeField] private Button _levelUpPageButton;
		
		public event Action InfoPageButtonClicked;
		public event Action LevelUpPageButtonClicked;

		public override void RegisterUICallbacks()
		{
			base.RegisterUICallbacks();
			_infoPageButton.onClick.AddListener(OnInfoPageButtonClicked);
			_levelUpPageButton.onClick.AddListener(OnLevelUpPageButtonClicked);
		}

		public override void Dispose()
		{
			base.Dispose();
			_infoPageButton.onClick.RemoveListener(OnInfoPageButtonClicked);
			_levelUpPageButton.onClick.RemoveListener(OnLevelUpPageButtonClicked);
		}

		void OnInfoPageButtonClicked()
		{
			InfoPageButtonClicked?.Invoke();
		}
		
		void OnLevelUpPageButtonClicked()
		{
			LevelUpPageButtonClicked?.Invoke();
		}
	}

}