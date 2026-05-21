using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Xml.XPath;

[Serializable]
[TypeForwardedFrom("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class XPathException : SystemException
{
	private readonly string _res;

	private readonly string[] _args;

	private readonly string _message;

	public override string Message => _message ?? base.Message;

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("res", _res);
		P_0.AddValue("args", _args);
		P_0.AddValue("version", "2.0");
	}

	internal static XPathException Create(string P_0)
	{
		return new XPathException(P_0, null);
	}

	internal static XPathException Create(string P_0, string P_1)
	{
		return new XPathException(P_0, new string[1] { P_1 });
	}

	internal static XPathException Create(string P_0, string P_1, string P_2)
	{
		return new XPathException(P_0, new string[2] { P_1, P_2 });
	}

	internal static XPathException Create(string P_0, string P_1, Exception P_2)
	{
		return new XPathException(P_0, new string[1] { P_1 }, P_2);
	}

	private XPathException(string P_0, string[] P_1)
		: this(P_0, P_1, null)
	{
	}

	private XPathException(string P_0, string[] P_1, Exception P_2)
		: base(CreateMessage(P_0, P_1), P_2)
	{
		base.HResult = -2146231997;
		_res = P_0;
		_args = P_1;
	}

	private static string CreateMessage(string P_0, string[] P_1)
	{
		try
		{
			string text;
			if (P_1 != null)
			{
				text = string.Format(P_0, P_1);
			}
			else
			{
				text = P_0;
			}
			string text2 = text;
			if (text2 != null)
			{
				return text2;
			}
		}
		catch (MissingManifestResourceException)
		{
		}
		return "UNKNOWN(" + P_0 + ")";
	}
}
