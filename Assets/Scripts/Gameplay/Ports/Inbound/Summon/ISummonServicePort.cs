using ProjectB.Data.Types;

namespace ProjectB.Gameplay.Ports.Inbound.Summon
{

	public interface ISummonServicePort
	{
		void Summon(SummonType type);
	}

}