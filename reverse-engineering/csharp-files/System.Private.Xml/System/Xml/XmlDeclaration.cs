using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Xml;

public class XmlDeclaration : XmlLinkedNode
{
	private string _version;

	private string _encoding;

	private string _standalone;

	public string Version
	{
		get
		{
			return _version;
		}
		[MemberNotNull("_version")]
		internal set
		{
			_version = version;
		}
	}

	public string Encoding
	{
		get
		{
			return _encoding;
		}
		[MemberNotNull("_encoding")]
		[param: AllowNull]
		set
		{
			_encoding = text ?? string.Empty;
		}
	}

	public string Standalone
	{
		get
		{
			return _standalone;
		}
		[MemberNotNull("_standalone")]
		[param: AllowNull]
		set
		{
			if (text == null)
			{
				_standalone = string.Empty;
				return;
			}
			if (text.Length == 0 || text == "yes" || text == "no")
			{
				_standalone = text;
				return;
			}
			throw new ArgumentException(System.SR.Format("Xdom_standalone", text));
		}
	}

	public override string? Value
	{
		get
		{
			return InnerText;
		}
		set
		{
			InnerText = innerText;
		}
	}

	public override string InnerText
	{
		get
		{
			Span<char> span = stackalloc char[256];
			System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
			valueStringBuilder.Append("version=\"");
			valueStringBuilder.Append(Version);
			valueStringBuilder.Append('"');
			if (Encoding.Length > 0)
			{
				valueStringBuilder.Append(" encoding=\"");
				valueStringBuilder.Append(Encoding);
				valueStringBuilder.Append('"');
			}
			if (Standalone.Length > 0)
			{
				valueStringBuilder.Append(" standalone=\"");
				valueStringBuilder.Append(Standalone);
				valueStringBuilder.Append('"');
			}
			return valueStringBuilder.ToString();
		}
		set
		{
			string encoding = Encoding;
			string standalone = Standalone;
			string version = Version;
			XmlLoader.ParseXmlDeclarationValue(text, out var text2, out var text3, out var text4);
			try
			{
				if (text2 != null && !IsValidXmlVersion(text2))
				{
					throw new ArgumentException("Xdom_Version");
				}
				Version = text2;
				if (text3 != null)
				{
					Encoding = text3;
				}
				if (text4 != null)
				{
					Standalone = text4;
				}
			}
			catch
			{
				Encoding = encoding;
				Standalone = standalone;
				Version = version;
				throw;
			}
		}
	}

	public override string Name => "xml";

	public override string LocalName => Name;

	public override XmlNodeType NodeType => XmlNodeType.XmlDeclaration;

	protected internal XmlDeclaration(string P_0, string? P_1, string? P_2, XmlDocument P_3)
		: base(P_3)
	{
		if (!IsValidXmlVersion(P_0))
		{
			throw new ArgumentException("Xdom_Version");
		}
		if (P_2 != null && P_2.Length > 0 && P_2 != "yes" && P_2 != "no")
		{
			throw new ArgumentException(System.SR.Format("Xdom_standalone", P_2));
		}
		Encoding = P_1;
		Standalone = P_2;
		Version = P_0;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateXmlDeclaration(Version, Encoding, Standalone);
	}

	private static bool IsValidXmlVersion(string P_0)
	{
		if (P_0.Length >= 3 && P_0[0] == '1' && P_0[1] == '.')
		{
			return XmlCharType.IsOnlyDigits(P_0, 2, P_0.Length - 2);
		}
		return false;
	}
}
