using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal static class StreamToStreamCopy
{
	public static Task CopyAsync(Stream P_0, Stream P_1, int P_2, bool P_3, CancellationToken P_4 = default(CancellationToken))
	{
		try
		{
			Task task = ((P_2 == 0) ? P_0.CopyToAsync(P_1, P_4) : P_0.CopyToAsync(P_1, P_2, P_4));
			if (!P_3)
			{
				return task;
			}
			switch (task.Status)
			{
			case TaskStatus.RanToCompletion:
				DisposeSource(P_0);
				return Task.CompletedTask;
			case TaskStatus.Canceled:
			case TaskStatus.Faulted:
				return task;
			default:
				return DisposeSourceAsync(task, P_0);
			}
		}
		catch (Exception ex)
		{
			return Task.FromException(ex);
		}
		static async Task DisposeSourceAsync(Task task2, Stream stream)
		{
			await task2.ConfigureAwait(false);
			DisposeSource(stream);
		}
	}

	private static void DisposeSource(Stream P_0)
	{
		try
		{
			P_0.Dispose();
		}
		catch (Exception)
		{
			if (!NetEventSource.Log.IsEnabled())
			{
			}
		}
	}
}
