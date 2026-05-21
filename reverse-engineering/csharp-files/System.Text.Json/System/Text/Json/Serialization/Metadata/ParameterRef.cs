namespace System.Text.Json.Serialization.Metadata;

internal readonly struct ParameterRef
{
	public readonly ulong Key;

	public readonly JsonParameterInfo Info;

	public readonly byte[] NameFromJson;

	public ParameterRef(ulong P_0, JsonParameterInfo P_1, byte[] P_2)
	{
		Key = P_0;
		Info = P_1;
		NameFromJson = P_2;
	}
}
