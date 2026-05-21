using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Text.Json;

[Serializable]
public class JsonException : Exception
{
	internal string _message;

	[CompilerGenerated]
	private bool _003CAppendPathInformation_003Ek__BackingField;

	[CompilerGenerated]
	private long? _003CLineNumber_003Ek__BackingField;

	[CompilerGenerated]
	private long? _003CBytePositionInLine_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPath_003Ek__BackingField;

	internal bool AppendPathInformation
	{
		[CompilerGenerated]
		get
		{
			return _003CAppendPathInformation_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAppendPathInformation_003Ek__BackingField = flag;
		}
	}

	public long? LineNumber
	{
		[CompilerGenerated]
		get
		{
			return _003CLineNumber_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			_003CLineNumber_003Ek__BackingField = num;
		}
	}

	public long? BytePositionInLine
	{
		[CompilerGenerated]
		get
		{
			return _003CBytePositionInLine_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			_003CBytePositionInLine_003Ek__BackingField = num;
		}
	}

	public string? Path
	{
		[CompilerGenerated]
		get
		{
			return _003CPath_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			_003CPath_003Ek__BackingField = text;
		}
	}

	public override string Message => _message ?? base.Message;

	public JsonException(string? P_0, string? P_1, long? P_2, long? P_3, Exception? P_4)
		: base(P_0, P_4)
	{
		_message = P_0;
		LineNumber = P_2;
		BytePositionInLine = P_3;
		Path = P_1;
	}

	public JsonException(string? P_0, string? P_1, long? P_2, long? P_3)
		: base(P_0)
	{
		_message = P_0;
		LineNumber = P_2;
		BytePositionInLine = P_3;
		Path = P_1;
	}

	public JsonException(string? P_0, Exception? P_1)
		: base(P_0, P_1)
	{
		_message = P_0;
	}

	public JsonException(string? P_0)
		: base(P_0)
	{
		_message = P_0;
	}

	public JsonException()
	{
	}

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("LineNumber", LineNumber, typeof(long?));
		P_0.AddValue("BytePositionInLine", BytePositionInLine, typeof(long?));
		P_0.AddValue("Path", Path, typeof(string));
		P_0.AddValue("ActualMessage", Message, typeof(string));
	}

	internal void SetMessage(string P_0)
	{
		_message = P_0;
	}
}
