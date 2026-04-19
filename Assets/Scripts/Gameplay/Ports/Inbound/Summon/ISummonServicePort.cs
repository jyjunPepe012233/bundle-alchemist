using ProjectB.Data.Runtime.Summon;

namespace ProjectB.Gameplay.Ports.Inbound.Summon
{

	public interface ISummonServicePort
	{
		SummonResult Summon1x();
		
		SummonResult Summon10x();
	}

}