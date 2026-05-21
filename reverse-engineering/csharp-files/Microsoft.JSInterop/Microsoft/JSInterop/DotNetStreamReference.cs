using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Microsoft.JSInterop;

public sealed class DotNetStreamReference : IDisposable
{
	public Stream Stream
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public bool LeaveOpen
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Dispose()
	{
		throw new NotSupportedException("Linked away");
	}
}
