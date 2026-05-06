using ProjectB.Data.Static.ShopItem;

namespace ProjectB.Gameplay.Ports.Inbound
{

	public interface IShopServicePort
	{
		void BuyItem(IShopItem shopItem);
	}

}