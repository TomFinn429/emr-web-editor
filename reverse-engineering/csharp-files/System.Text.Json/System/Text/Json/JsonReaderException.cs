namespace System.Text.Json;

[Serializable]
internal sealed class JsonReaderException : JsonException
{
	public JsonReaderException(string P_0, long P_1, long P_2)
		: base(P_0, null, P_1, P_2)
	{
	}
}
