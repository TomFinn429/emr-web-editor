namespace Microsoft.JSInterop.Infrastructure;

public readonly struct DotNetInvocationInfo
{
	public string? AssemblyName { get; }

	public string MethodIdentifier { get; }

	public long DotNetObjectId { get; }

	public string? CallId { get; }

	public DotNetInvocationInfo(string? P_0, string P_1, long P_2, string? P_3)
	{
		CallId = P_3;
		AssemblyName = P_0;
		MethodIdentifier = P_1;
		DotNetObjectId = P_2;
	}
}
