using System.Diagnostics.Tracing;

namespace System.Collections.Concurrent;

internal sealed class CDSCollectionETWBCLProvider : EventSource
{
	public static CDSCollectionETWBCLProvider Log = new CDSCollectionETWBCLProvider();

	private CDSCollectionETWBCLProvider()
	{
	}
}
