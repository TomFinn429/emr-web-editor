using System.Diagnostics.Tracing;

namespace System.Net;

internal sealed class NetEventSource : EventSource
{
	public static readonly NetEventSource Log = new NetEventSource();
}
