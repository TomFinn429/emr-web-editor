using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

internal static class CancellationHelper
{
	private static readonly string s_cancellationMessage = new OperationCanceledException().Message;

	internal static Exception CreateOperationCanceledException(Exception P_0, CancellationToken P_1)
	{
		return new TaskCanceledException(s_cancellationMessage, P_0, P_1);
	}
}
