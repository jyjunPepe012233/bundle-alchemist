using System.Collections;

// ICommandResolver 인터페이스를 구현하면 CommandBuffer에 Resolver로 등록할 수 있음
// Resolver로 등록되면 발생하는 Resolve에서 Command를 인자로 받아 처리할 수 있음
public interface ICommandResolver<TCommand> where TCommand : ICommand
{
	IEnumerator Resolve(TCommand command);
}