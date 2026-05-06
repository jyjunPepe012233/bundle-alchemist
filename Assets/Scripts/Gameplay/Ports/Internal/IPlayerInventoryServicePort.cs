using ProjectB.Data.Static.Item;
using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Internal
{

	public interface IPlayerInventoryServicePort
	{
		void GiveItem(IItemData itemData, int quantity, ItemGainAction gainAction);
	}

}