namespace System.Text.Json.Serialization.Metadata;

internal readonly struct PropertyRef
{
	public readonly ulong Key;

	public readonly JsonPropertyInfo Info;

	public readonly byte[] NameFromJson;

	public PropertyRef(ulong P_0, JsonPropertyInfo P_1, byte[] P_2)
	{
		Key = P_0;
		Info = P_1;
		NameFromJson = P_2;
	}
}
