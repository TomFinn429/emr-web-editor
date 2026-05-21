using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
public sealed class JSException : Exception
{
	internal JSObject jsException;

	public override string? StackTrace
	{
		get
		{
			string stackTrace = base.StackTrace;
			if (jsException == null)
			{
				return stackTrace;
			}
			string text = jsException.GetPropertyAsString("stack");
			if (text == null)
			{
				if (stackTrace == null)
				{
					return null;
				}
			}
			else if (text.StartsWith(Message + "\n"))
			{
				text = text.Substring(Message.Length + 1);
			}
			if (stackTrace == null)
			{
				return text;
			}
			return base.StackTrace + "\r\n" + text;
		}
	}

	public JSException(string P_0)
		: base(P_0)
	{
		jsException = null;
	}

	internal JSException(string P_0, JSObject P_1)
		: base(P_0)
	{
		jsException = P_1;
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 is JSException ex)
		{
			return ex.jsException == jsException;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (jsException != null)
		{
			return base.GetHashCode() * jsException.GetHashCode();
		}
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return Message;
	}
}
