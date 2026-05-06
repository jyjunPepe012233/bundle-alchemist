using System.Collections.Generic;
using ProjectB.Data.Static.ShopPage;

namespace ProjectB.Data.Static.Shop
{

	public interface IShopSetting
	{
		IReadOnlyList<IShopPage> ShopPages { get; }
	}

}