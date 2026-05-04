namespace ProjectB.Data.Runtime.Player
{

	public interface IReadOnlyPlayerItem
	{
		string ItemId { get; }
		
		int Quantity { get; }
	}

}