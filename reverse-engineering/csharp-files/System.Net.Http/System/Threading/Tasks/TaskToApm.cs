using System.Diagnostics.CodeAnalysis;

namespace System.Threading.Tasks;

internal static class TaskToApm
{
	internal sealed class TaskAsyncResult : IAsyncResult
	{
		internal readonly Task _task;

		private readonly AsyncCallback _callback;

		public object AsyncState { get; }

		public bool CompletedSynchronously { get; }

		internal TaskAsyncResult(Task P_0, object P_1, AsyncCallback P_2)
		{
			_task = P_0;
			AsyncState = P_1;
			if (P_0.IsCompleted)
			{
				CompletedSynchronously = true;
				P_2?.Invoke(this);
			}
			else if (P_2 != null)
			{
				_callback = P_2;
				_task.ConfigureAwait(false).GetAwaiter().OnCompleted(InvokeCallback);
			}
		}

		private void InvokeCallback()
		{
			_callback(this);
		}
	}

	public static IAsyncResult Begin(Task P_0, AsyncCallback P_1, object P_2)
	{
		return new TaskAsyncResult(P_0, P_2, P_1);
	}

	public static void End(IAsyncResult P_0)
	{
		Task task = GetTask(P_0);
		if (task != null)
		{
			task.GetAwaiter().GetResult();
		}
		else
		{
			ThrowArgumentException(P_0);
		}
	}

	public static TResult End<TResult>(IAsyncResult P_0)
	{
		if (GetTask(P_0) is Task<TResult> task)
		{
			return task.GetAwaiter().GetResult();
		}
		ThrowArgumentException(P_0);
		return default(TResult);
	}

	public static Task GetTask(IAsyncResult P_0)
	{
		return (P_0 as TaskAsyncResult)?._task;
	}

	[DoesNotReturn]
	private static void ThrowArgumentException(IAsyncResult P_0)
	{
		throw (P_0 == null) ? new ArgumentNullException("asyncResult") : new ArgumentException(null, "asyncResult");
	}
}
