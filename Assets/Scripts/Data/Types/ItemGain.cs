using ProjectB.Data.Static.Item;

namespace ProjectB.Data.Types
{

	public struct ItemGain
	{
		public IItemData item;
		public int quantity;

		public ItemGain(IItemData item, int quantity)
		{
			this.item = item;
			this.quantity = quantity;
		}
	}

}