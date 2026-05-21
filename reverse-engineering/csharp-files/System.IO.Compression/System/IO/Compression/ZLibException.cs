using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.IO.Compression;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class ZLibException : IOException, ISerializable
{
	private readonly string _zlibErrorContext = string.Empty;

	private readonly string _zlibErrorMessage = string.Empty;

	private readonly ZLibNative.ErrorCode _zlibErrorCode;

	public ZLibException(string? P_0, string? P_1, int P_2, string? P_3)
		: base(P_0)
	{
		_zlibErrorContext = P_1;
		_zlibErrorCode = (ZLibNative.ErrorCode)P_2;
		_zlibErrorMessage = P_3;
	}

	public ZLibException(string? P_0, Exception? P_1)
		: base(P_0, P_1)
	{
	}

	void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("zlibErrorContext", _zlibErrorContext);
		P_0.AddValue("zlibErrorCode", (int)_zlibErrorCode);
		P_0.AddValue("zlibErrorMessage", _zlibErrorMessage);
	}
}
