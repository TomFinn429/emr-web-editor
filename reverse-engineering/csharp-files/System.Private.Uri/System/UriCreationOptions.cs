namespace System;

public struct UriCreationOptions
{
	private bool _disablePathAndQueryCanonicalization;

	public readonly bool DangerousDisablePathAndQueryCanonicalization => _disablePathAndQueryCanonicalization;
}
