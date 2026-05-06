using System.Collections.Generic;
using ProjectB.Data.Static.ShopItem;

namespace ProjectB.Data.Static.ShopPage
{

	public interface IShopPage
	{
		string ShopPageId { get; }
		
		string ShopPageName { get; }
		
		IEnumerable<IShopItem> ShopItems { get; }
	}

}