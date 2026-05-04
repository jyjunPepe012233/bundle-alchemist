using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Item
{

	public interface IItemData
	{
		string ItemId { get; }
		
		string ItemName { get; }
		
		ItemCategory Category { get; }
	}

}