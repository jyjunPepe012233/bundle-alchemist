using ProjectB.Data.Static.Item;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IPlayerInventoryServicePort
	{
		void GiveItem(IItemData itemData, int quantity);
	}

}