namespace System.Runtime.InteropServices.JavaScript;

internal enum MarshalerType
{
	None,
	Void,
	Discard,
	Boolean,
	Byte,
	Char,
	Int16,
	Int32,
	Int52,
	BigInt64,
	Double,
	Single,
	IntPtr,
	JSObject,
	Object,
	String,
	Exception,
	DateTime,
	DateTimeOffset,
	Nullable,
	Task,
	Array,
	ArraySegment,
	Span,
	Action,
	Function,
	JSException
}
