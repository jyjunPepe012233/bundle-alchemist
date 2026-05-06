using System.Linq;
using ProjectB.Data.Runtime.Player;
using ProjectB.Data.RuntimeImpl;
using ProjectB.Data.Static.Item;
using ProjectB.Gameplay.Ports.Internal;
using ProjectB.Gameplay.Ports.Outbound;

namespace ProjectB.Gameplay
{

	public class PlayerInventoryService : IPlayerInventoryServicePort
	{
		private readonly IPlayerSessionHolderPort _playerSessionHolderPort;

		public PlayerInventoryService(IPlayerSessionHolderPort playerSessionHolderPort)
		{
			_playerSessionHolderPort = playerSessionHolderPort;
		}

		public void GiveItem(IItemData itemData, int quantity)
		{
			var playerData = _playerSessionHolderPort.GetPlayerSession().PlayerData;

			// 찾지 못하면 null이 할당됨
			var existingItem = playerData.Items.FirstOrDefault(x => x.ItemId == itemData.ItemId);

			if (existingItem != null)
			{
				existingItem.AddQuantity(quantity);
			}
			else
			{
				IPlayerItem newItem = new PlayerItem(itemData.ItemId, quantity);
				playerData.AddItem(newItem);
			}
		}
	}

}