using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Win32.SafeHandles;

public sealed class SafeWaitHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ReleaseHandle()
	{
		throw new NotSupportedException("Linked away");
	}
}
