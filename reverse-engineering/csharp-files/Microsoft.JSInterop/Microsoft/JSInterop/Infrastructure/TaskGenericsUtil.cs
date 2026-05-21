using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.JSInterop.Infrastructure;

internal static class TaskGenericsUtil
{
	private interface ITcsResultSetter
	{
		Type ResultType { get; }

		void SetResult(object P_0, object P_1);

		void SetException(object P_0, Exception P_1);
	}

	private interface ITaskResultGetter
	{
		object GetResult(Task P_0);
	}

	private sealed class TaskResultGetter<T> : ITaskResultGetter
	{
		public object GetResult(Task P_0)
		{
			return ((Task<T>)P_0).Result;
		}
	}

	private sealed class VoidTaskResultGetter : ITaskResultGetter
	{
		public object GetResult(Task P_0)
		{
			P_0.Wait();
			return null;
		}
	}

	private sealed class TcsResultSetter<T> : ITcsResultSetter
	{
		public Type ResultType => typeof(T);

		public void SetResult(object P_0, object P_1)
		{
			TaskCompletionSource<T> obj = (TaskCompletionSource<T>)P_0;
			T result = ((P_1 is T val) ? val : ((T)Convert.ChangeType(P_1, typeof(T), CultureInfo.InvariantCulture)));
			obj.SetResult(result);
		}

		public void SetException(object P_0, Exception P_1)
		{
			((TaskCompletionSource<T>)P_0).SetException(P_1);
		}
	}

	private static readonly ConcurrentDictionary<Type, ITaskResultGetter> _cachedResultGetters = new ConcurrentDictionary<Type, ITaskResultGetter>();

	private static readonly ConcurrentDictionary<Type, ITcsResultSetter> _cachedResultSetters = new ConcurrentDictionary<Type, ITcsResultSetter>();

	public static void SetTaskCompletionSourceResult(object P_0, object? P_1)
	{
		CreateResultSetter(P_0).SetResult(P_0, P_1);
	}

	public static void SetTaskCompletionSourceException(object P_0, Exception P_1)
	{
		CreateResultSetter(P_0).SetException(P_0, P_1);
	}

	public static Type GetTaskCompletionSourceResultType(object P_0)
	{
		return CreateResultSetter(P_0).ResultType;
	}

	public static object? GetTaskResult(Task P_0)
	{
		return _cachedResultGetters.GetOrAdd(P_0.GetType(), delegate(Type type)
		{
			Type taskResultType = GetTaskResultType(type);
			return (!(taskResultType == null)) ? ((ITaskResultGetter)Activator.CreateInstance(typeof(TaskResultGetter<>).MakeGenericType(taskResultType))) : new VoidTaskResultGetter();
		}).GetResult(P_0);
	}

	private static Type GetTaskResultType(Type P_0)
	{
		while (P_0 != typeof(Task) && (!P_0.IsGenericType || P_0.GetGenericTypeDefinition() != typeof(Task<>)))
		{
			P_0 = P_0.BaseType ?? throw new ArgumentException($"The type '{P_0.FullName}' is not inherited from '{typeof(Task).FullName}'.");
		}
		if (!P_0.IsGenericType)
		{
			return null;
		}
		return P_0.GetGenericArguments()[0];
	}

	private static ITcsResultSetter CreateResultSetter(object P_0)
	{
		return _cachedResultSetters.GetOrAdd(P_0.GetType(), delegate(Type type2)
		{
			Type type = type2.GetGenericArguments()[0];
			return (ITcsResultSetter)Activator.CreateInstance(typeof(TcsResultSetter<>).MakeGenericType(type));
		});
	}
}
