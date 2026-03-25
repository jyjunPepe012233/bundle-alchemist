using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 시스템이 UI 시스템의 요청을 동기적으로 처리하는 흐름을 만들고자 커맨드 패턴을 바탕으로 이 클래스를 구현하였음. - 250325
public static class CommandBuffer
{
	private static readonly Queue<ICommand> _commandQueue = new(); 
	private static readonly Dictionary<Type, ICommandExecutor> _executors = new();

	private static bool _isProcessingCommands = false; // 커맨드 처리 중 여부
	
	
	
	// ICommandResolver<>를 입력받으면 CommandExecutorAdapter 객체를 만들고
	// ICommandExecutor로 추상화하여 저장함 (제네릭 클래스를 관리하기 위함)
	public static void RegisterExecutor<TCommand>(ICommandResolver<TCommand> resolver)
		where TCommand : ICommand
	{
		if (resolver == null)
		{
			Debug.LogError($"[{nameof(CommandBuffer)}] Executor가 null임: {typeof(TCommand).Name}");
			return;
		}
		
		Type commandType = typeof(TCommand);

		if (!_executors.TryAdd(commandType, new CommandExecutorAdapter<TCommand>(resolver)))
		{
			Debug.LogError($"[{nameof(CommandBuffer)}] 이미 등록된 Executor가 존재함: {commandType.Name}");
			return;
		}
	}

	
	
	public static void UnregisterExecutor<TCommand>()
		where TCommand : ICommand
	{
		Type commandType = typeof(TCommand);

		if (!_executors.Remove(commandType))
		{
			Debug.LogWarning($"[{nameof(CommandBuffer)}] 등록된 Executor를 찾을 수 없음: {commandType.Name}");
		}
	}

	
	
	public static void AddCommand(ICommand command)
	{
		if (command == null)
		{
			Debug.LogError($"[{nameof(CommandBuffer)}] Command가 null임");
			return;
		}
		
		_commandQueue.Enqueue(command);

		if (!_isProcessingCommands)
		{
			ProcessCommands();
		}
	}
	
	

	private static void ProcessCommands()
	{
		IEnumerator Coroutine()
		{
			while (_commandQueue.Count > 0)
			{
				ICommand command = _commandQueue.Dequeue();
				
				if (!_executors.TryGetValue(command.GetType(), out var executor))
				{
					Debug.LogWarning($"[{nameof(CommandBuffer)}] Executor가 등록되어 있지 않음: {command.GetType().Name}");
					continue;
				}
				
				Debug.Log($"[{nameof(CommandBuffer)}] 커맨드: {command.GetType().Name}, 실행자: {executor.GetType().Name}");
				// ICommand를 ICommandExecutor에 전달하면
				// 해당 인터페이스의 구현체인 CommandExecutorAdapter<>가 실제 ICommandResolver<>의 Resolve 메서드를 호출함
				yield return executor.Execute(command);
			}

			_isProcessingCommands = false;
		}

		_isProcessingCommands = true;
		CoroutineHandler.StartAndAdd(Coroutine());
	}
	
	
	
	
	
	private interface ICommandExecutor
	{
		IEnumerator Execute(ICommand command);
	}
	
	private sealed class CommandExecutorAdapter<TCommand> : ICommandExecutor where TCommand : ICommand
	{
		private readonly ICommandResolver<TCommand> _resolver;

		public CommandExecutorAdapter(ICommandResolver<TCommand> resolver)
		{
			_resolver = resolver;
		}

		// CommandBuffer가 ICommandExecutor에 ICommand를 전달하면
		// 이 구현체 클래스가 ICommandResolver<>의 Resolve 메서드를 호출하기 전에 ICommand를 TCommand로 캐스팅하여 전달함
		public IEnumerator Execute(ICommand command)
		{
			if (command is TCommand typedCommand)
			{
				yield return _resolver.Resolve(typedCommand);
			}
			else
			{
				Debug.LogError("[CommandResolvable] 명령어 타입 불일치: " + command.GetType().Name);
			}
		}
	}
}
