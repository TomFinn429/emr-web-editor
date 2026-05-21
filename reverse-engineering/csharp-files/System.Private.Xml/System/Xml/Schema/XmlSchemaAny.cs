using System.ComponentModel;
using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaAny : XmlSchemaParticle
{
	private string _ns;

	private XmlSchemaContentProcessing _processContents;

	private NamespaceList _namespaceList;

	[XmlAttribute("processContents")]
	[DefaultValue(XmlSchemaContentProcessing.None)]
	public XmlSchemaContentProcessing ProcessContents
	{
		set
		{
			_processContents = processContents;
		}
	}

	[XmlIgnore]
	internal NamespaceList? NamespaceList => _namespaceList;

	internal void BuildNamespaceList(string P_0)
	{
		if (_ns != null)
		{
			_namespaceList = new NamespaceList(_ns, P_0);
		}
		else
		{
			_namespaceList = new NamespaceList();
		}
	}
}
