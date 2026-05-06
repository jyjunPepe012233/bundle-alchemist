using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectB.UI.Components
{

	public class ItemPurchaseButton : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private TextMeshProUGUI _itemQuantityText;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private Button _purchaseButton;
		[SerializeField] private Transform _backgroundParent256;

		public event Action PurchaseButtonClicked;
		
		private GameObject _backgroundInstance;
		
		public void SetItemNameText(string text)
		{
			_itemNameText.text = text;
		}
		
		public void SetItemQuantityText(string text)
		{
			_itemQuantityText.text = text;
		}
		
		public void SetPriceText(string text)
		{
			_priceText.text = text;
		}
		
		public void SetPurchaseButtonInteractable(bool interactable)
		{
			_purchaseButton.interactable = interactable;
		}

		public void SetBackground256(GameObject prefab)
		{
			if (_backgroundInstance != null)
			{
				Destroy(_backgroundInstance);
			}
			
			_backgroundInstance = Instantiate(prefab, _backgroundParent256);
		}
	}

}