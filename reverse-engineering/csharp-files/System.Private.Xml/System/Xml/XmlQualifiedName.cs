using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Xml;

public class XmlQualifiedName
{
	private int _hash;

	public static readonly XmlQualifiedName Empty = new XmlQualifiedName(string.Empty);

	[CompilerGenerated]
	private string _003CNamespace_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CName_003Ek__BackingField;

	public string Namespace
	{
		[CompilerGenerated]
		get
		{
			return _003CNamespace_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNamespace_003Ek__BackingField = text;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _003CName_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CName_003Ek__BackingField = text;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (Name.Length == 0)
			{
				return Namespace.Length == 0;
			}
			return false;
		}
	}

	public XmlQualifiedName(string? P_0)
		: this(P_0, string.Empty)
	{
	}

	public XmlQualifiedName(string? P_0, string? P_1)
	{
		Namespace = P_1 ?? string.Empty;
		Name = P_0 ?? string.Empty;
	}

	public override int GetHashCode()
	{
		if (_hash == 0)
		{
			_hash = Name.GetHashCode();
		}
		return _hash;
	}

	public override string ToString()
	{
		if (Namespace.Length != 0)
		{
			return Namespace + ":" + Name;
		}
		return Name;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (this == P_0)
		{
			return true;
		}
		if (P_0 is XmlQualifiedName xmlQualifiedName)
		{
			return Equals(xmlQualifiedName.Name, xmlQualifiedName.Namespace);
		}
		return false;
	}

	internal bool Equals(string P_0, string P_1)
	{
		if (Name == P_0)
		{
			return Namespace == P_1;
		}
		return false;
	}

	public static bool operator ==(XmlQualifiedName? P_0, XmlQualifiedName? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null)
		{
			return false;
		}
		if (P_0.Name == P_1.Name)
		{
			return P_0.Namespace == P_1.Namespace;
		}
		return false;
	}

	public static bool operator !=(XmlQualifiedName? P_0, XmlQualifiedName? P_1)
	{
		return !(P_0 == P_1);
	}

	internal static XmlQualifiedName Parse(string P_0, IXmlNamespaceResolver P_1, out string P_2)
	{
		ValidateNames.ParseQNameThrow(P_0, out P_2, out var text);
		string text2 = P_1.LookupNamespace(P_2);
		if (text2 == null)
		{
			if (P_2.Length != 0)
			{
				throw new XmlException("Xml_UnknownNs", P_2);
			}
			text2 = string.Empty;
		}
		return new XmlQualifiedName(text, text2);
	}
}
