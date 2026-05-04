namespace ProjectB.Data.Runtime.Player
{

	public interface IPlayerItem : IReadOnlyPlayerItem
	{
		void AddQuantity(int amount);
		
		bool TryRemoveQuantity(int amount);
	}

}