using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Xml;

public sealed class XmlAttributeCollection : XmlNamedNodeMap, ICollection, IEnumerable
{
	[IndexerName("ItemOf")]
	public XmlAttribute this[int P_0]
	{
		get
		{
			try
			{
				return (XmlAttribute)nodes[P_0];
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new IndexOutOfRangeException("Xdom_IndexOutOfRange");
			}
		}
	}

	[IndexerName("ItemOf")]
	public XmlAttribute? this[string P_0]
	{
		get
		{
			int hashCode = XmlName.GetHashCode(P_0);
			for (int i = 0; i < nodes.Count; i++)
			{
				XmlAttribute xmlAttribute = (XmlAttribute)nodes[i];
				if (hashCode == xmlAttribute.LocalNameHash && P_0 == xmlAttribute.Name)
				{
					return xmlAttribute;
				}
			}
			return null;
		}
	}

	[IndexerName("ItemOf")]
	public XmlAttribute? this[string P_0, string? P_1]
	{
		get
		{
			int hashCode = XmlName.GetHashCode(P_0);
			for (int i = 0; i < nodes.Count; i++)
			{
				XmlAttribute xmlAttribute = (XmlAttribute)nodes[i];
				if (hashCode == xmlAttribute.LocalNameHash && P_0 == xmlAttribute.LocalName && P_1 == xmlAttribute.NamespaceURI)
				{
					return xmlAttribute;
				}
			}
			return null;
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	int ICollection.Count => base.Count;

	internal XmlAttributeCollection(XmlNode P_0)
		: base(P_0)
	{
	}

	[return: NotNullIfNotNull("node")]
	public override XmlNode? SetNamedItem(XmlNode? P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (!(P_0 is XmlAttribute))
		{
			throw new ArgumentException("Xdom_AttrCol_Object");
		}
		int num = FindNodeOffset(P_0.LocalName, P_0.NamespaceURI);
		if (num == -1)
		{
			return InternalAppendAttribute((XmlAttribute)P_0);
		}
		XmlNode result = base.RemoveNodeAt(num);
		InsertNodeAt(num, P_0);
		return result;
	}

	public XmlAttribute Append(XmlAttribute P_0)
	{
		XmlDocument ownerDocument = P_0.OwnerDocument;
		if (ownerDocument == null || !ownerDocument.IsLoading)
		{
			if (ownerDocument != null && ownerDocument != parent.OwnerDocument)
			{
				throw new ArgumentException("Xdom_NamedNode_Context");
			}
			if (P_0.OwnerElement != null)
			{
				Detach(P_0);
			}
			AddNode(P_0);
		}
		else
		{
			base.AddNodeForLoad(P_0, ownerDocument);
			InsertParentIntoElementIdAttrMap(P_0);
		}
		return P_0;
	}

	public XmlAttribute? Remove(XmlAttribute? P_0)
	{
		int count = nodes.Count;
		for (int i = 0; i < count; i++)
		{
			if (nodes[i] == P_0)
			{
				RemoveNodeAt(i);
				return P_0;
			}
		}
		return null;
	}

	public XmlAttribute? RemoveAt(int P_0)
	{
		if (P_0 < 0 || P_0 >= Count)
		{
			return null;
		}
		return (XmlAttribute)RemoveNodeAt(P_0);
	}

	public void RemoveAll()
	{
		int num = Count;
		while (num > 0)
		{
			num--;
			RemoveAt(num);
		}
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		int num = 0;
		int count = Count;
		while (num < count)
		{
			P_0.SetValue(nodes[num], P_1);
			num++;
			P_1++;
		}
	}

	internal override XmlNode AddNode(XmlNode P_0)
	{
		RemoveDuplicateAttribute((XmlAttribute)P_0);
		XmlNode result = base.AddNode(P_0);
		InsertParentIntoElementIdAttrMap((XmlAttribute)P_0);
		return result;
	}

	internal override XmlNode InsertNodeAt(int P_0, XmlNode P_1)
	{
		XmlNode result = base.InsertNodeAt(P_0, P_1);
		InsertParentIntoElementIdAttrMap((XmlAttribute)P_1);
		return result;
	}

	internal override XmlNode RemoveNodeAt(int P_0)
	{
		XmlNode xmlNode = base.RemoveNodeAt(P_0);
		RemoveParentFromElementIdAttrMap((XmlAttribute)xmlNode);
		XmlAttribute defaultAttribute = parent.OwnerDocument.GetDefaultAttribute((XmlElement)parent, xmlNode.Prefix, xmlNode.LocalName, xmlNode.NamespaceURI);
		if (defaultAttribute != null)
		{
			InsertNodeAt(P_0, defaultAttribute);
		}
		return xmlNode;
	}

	internal static void Detach(XmlAttribute P_0)
	{
		P_0.OwnerElement.Attributes.Remove(P_0);
	}

	internal void InsertParentIntoElementIdAttrMap(XmlAttribute P_0)
	{
		if (parent is XmlElement xmlElement && parent.OwnerDocument != null)
		{
			XmlName iDInfoByElement = parent.OwnerDocument.GetIDInfoByElement(xmlElement.XmlName);
			if (iDInfoByElement != null && iDInfoByElement.Prefix == P_0.XmlName.Prefix && iDInfoByElement.LocalName == P_0.XmlName.LocalName)
			{
				parent.OwnerDocument.AddElementWithId(P_0.Value, xmlElement);
			}
		}
	}

	internal void RemoveParentFromElementIdAttrMap(XmlAttribute P_0)
	{
		if (parent is XmlElement xmlElement && parent.OwnerDocument != null)
		{
			XmlName iDInfoByElement = parent.OwnerDocument.GetIDInfoByElement(xmlElement.XmlName);
			if (iDInfoByElement != null && iDInfoByElement.Prefix == P_0.XmlName.Prefix && iDInfoByElement.LocalName == P_0.XmlName.LocalName)
			{
				parent.OwnerDocument.RemoveElementWithId(P_0.Value, xmlElement);
			}
		}
	}

	internal int RemoveDuplicateAttribute(XmlAttribute P_0)
	{
		int num = FindNodeOffset(P_0.LocalName, P_0.NamespaceURI);
		if (num != -1)
		{
			XmlAttribute xmlAttribute = (XmlAttribute)nodes[num];
			base.RemoveNodeAt(num);
			RemoveParentFromElementIdAttrMap(xmlAttribute);
		}
		return num;
	}

	internal bool PrepareParentInElementIdAttrMap(string P_0, string P_1)
	{
		XmlElement xmlElement = parent as XmlElement;
		XmlDocument ownerDocument = parent.OwnerDocument;
		XmlName iDInfoByElement = ownerDocument.GetIDInfoByElement(xmlElement.XmlName);
		if (iDInfoByElement != null && iDInfoByElement.Prefix == P_0 && iDInfoByElement.LocalName == P_1)
		{
			return true;
		}
		return false;
	}

	internal void ResetParentInElementIdAttrMap(string P_0, string P_1)
	{
		XmlElement xmlElement = parent as XmlElement;
		XmlDocument ownerDocument = parent.OwnerDocument;
		ownerDocument.RemoveElementWithId(P_0, xmlElement);
		ownerDocument.AddElementWithId(P_1, xmlElement);
	}

	internal XmlAttribute InternalAppendAttribute(XmlAttribute P_0)
	{
		XmlNode xmlNode = base.AddNode(P_0);
		InsertParentIntoElementIdAttrMap(P_0);
		return (XmlAttribute)xmlNode;
	}
}
