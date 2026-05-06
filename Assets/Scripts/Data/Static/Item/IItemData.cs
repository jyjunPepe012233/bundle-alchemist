using ProjectB.Data.Static.ItemTier;
using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Item
{

	public interface IItemData
	{
		string ItemId { get; }
		
		string ItemName { get; }
		
		IItemTierData ItemTier { get; }
		
		ItemCategory Category { get; }
	}

}