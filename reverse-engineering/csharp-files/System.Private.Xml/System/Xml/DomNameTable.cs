using System.Xml.Schema;

namespace System.Xml;

internal sealed class DomNameTable
{
	private XmlName[] _entries;

	private int _count;

	private int _mask;

	private readonly XmlDocument _ownerDocument;

	private readonly XmlNameTable _nameTable;

	public DomNameTable(XmlDocument P_0)
	{
		_ownerDocument = P_0;
		_nameTable = P_0.NameTable;
		_entries = new XmlName[64];
		_mask = 63;
	}

	public XmlName GetName(string P_0, string P_1, string P_2, IXmlSchemaInfo P_3)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		if (P_2 == null)
		{
			P_2 = string.Empty;
		}
		int hashCode = XmlName.GetHashCode(P_1);
		for (XmlName xmlName = _entries[hashCode & _mask]; xmlName != null; xmlName = xmlName.next)
		{
			if (xmlName.HashCode == hashCode && ((object)xmlName.LocalName == P_1 || xmlName.LocalName.Equals(P_1)) && ((object)xmlName.Prefix == P_0 || xmlName.Prefix.Equals(P_0)) && ((object)xmlName.NamespaceURI == P_2 || xmlName.NamespaceURI.Equals(P_2)) && xmlName.Equals(P_3))
			{
				return xmlName;
			}
		}
		return null;
	}

	public XmlName AddName(string P_0, string P_1, string P_2, IXmlSchemaInfo P_3)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		if (P_2 == null)
		{
			P_2 = string.Empty;
		}
		int hashCode = XmlName.GetHashCode(P_1);
		for (XmlName xmlName = _entries[hashCode & _mask]; xmlName != null; xmlName = xmlName.next)
		{
			if (xmlName.HashCode == hashCode && ((object)xmlName.LocalName == P_1 || xmlName.LocalName.Equals(P_1)) && ((object)xmlName.Prefix == P_0 || xmlName.Prefix.Equals(P_0)) && ((object)xmlName.NamespaceURI == P_2 || xmlName.NamespaceURI.Equals(P_2)) && xmlName.Equals(P_3))
			{
				return xmlName;
			}
		}
		P_0 = _nameTable.Add(P_0);
		P_1 = _nameTable.Add(P_1);
		P_2 = _nameTable.Add(P_2);
		int num = hashCode & _mask;
		XmlName xmlName2 = XmlName.Create(P_0, P_1, P_2, hashCode, _ownerDocument, _entries[num], P_3);
		_entries[num] = xmlName2;
		if (_count++ == _mask)
		{
			Grow();
		}
		return xmlName2;
	}

	private void Grow()
	{
		int num = _mask * 2 + 1;
		XmlName[] entries = _entries;
		XmlName[] array = new XmlName[num + 1];
		for (int i = 0; i < entries.Length; i++)
		{
			XmlName xmlName = entries[i];
			while (xmlName != null)
			{
				int num2 = xmlName.HashCode & num;
				XmlName next = xmlName.next;
				xmlName.next = array[num2];
				array[num2] = xmlName;
				xmlName = next;
			}
		}
		_entries = array;
		_mask = num;
	}
}
