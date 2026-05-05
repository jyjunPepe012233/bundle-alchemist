using ProjectB.Data.Types;

namespace ProjectB.Data.Static.Item
{

	public interface IGainCurrencyItem : IConsumableItem
	{
		CurrencyType CurrencyType { get; }
		
		int Amount { get; }
	}

}