namespace System.Net.Http.Headers;

internal struct HeaderEntry
{
	public HeaderDescriptor Key;

	public object Value;

	public HeaderEntry(HeaderDescriptor P_0, object P_1)
	{
		Key = P_0;
		Value = P_1;
	}
}
