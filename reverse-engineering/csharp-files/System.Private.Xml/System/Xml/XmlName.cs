using System.Xml.Schema;

namespace System.Xml;

internal class XmlName : IXmlSchemaInfo
{
	private readonly string _prefix;

	private readonly string _localName;

	private readonly string _ns;

	private string _name;

	private readonly int _hashCode;

	internal XmlDocument ownerDoc;

	internal XmlName next;

	public string LocalName => _localName;

	public string NamespaceURI => _ns;

	public string Prefix => _prefix;

	public int HashCode => _hashCode;

	public XmlDocument OwnerDocument => ownerDoc;

	public string Name
	{
		get
		{
			if (_name == null)
			{
				if (_prefix.Length > 0)
				{
					if (_localName.Length > 0)
					{
						string text = _prefix + ":" + _localName;
						lock (ownerDoc.NameTable)
						{
							if (_name == null)
							{
								_name = ownerDoc.NameTable.Add(text);
							}
						}
					}
					else
					{
						_name = _prefix;
					}
				}
				else
				{
					_name = _localName;
				}
			}
			return _name;
		}
	}

	public virtual XmlSchemaValidity Validity => XmlSchemaValidity.NotKnown;

	public virtual bool IsDefault => false;

	public virtual bool IsNil => false;

	public virtual XmlSchemaSimpleType MemberType => null;

	public virtual XmlSchemaType SchemaType => null;

	public virtual XmlSchemaElement SchemaElement => null;

	public virtual XmlSchemaAttribute SchemaAttribute => null;

	public static XmlName Create(string P_0, string P_1, string P_2, int P_3, XmlDocument P_4, XmlName P_5, IXmlSchemaInfo P_6)
	{
		if (P_6 == null)
		{
			return new XmlName(P_0, P_1, P_2, P_3, P_4, P_5);
		}
		return new XmlNameEx(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	internal XmlName(string P_0, string P_1, string P_2, int P_3, XmlDocument P_4, XmlName P_5)
	{
		_prefix = P_0;
		_localName = P_1;
		_ns = P_2;
		_name = null;
		_hashCode = P_3;
		ownerDoc = P_4;
		next = P_5;
	}

	public virtual bool Equals(IXmlSchemaInfo P_0)
	{
		return P_0 == null;
	}

	public static int GetHashCode(string P_0)
	{
		int result = 0;
		if (P_0 != null)
		{
			return string.GetHashCode(P_0.AsSpan(P_0.LastIndexOf(':') + 1));
		}
		return result;
	}
}
