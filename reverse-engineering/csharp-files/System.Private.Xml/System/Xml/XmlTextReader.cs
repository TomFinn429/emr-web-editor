using System.ComponentModel;
using System.IO;

namespace System.Xml;

[EditorBrowsable(EditorBrowsableState.Never)]
public class XmlTextReader : XmlReader, IXmlNamespaceResolver
{
	private readonly XmlTextReaderImpl _impl;

	public override XmlNodeType NodeType => _impl.NodeType;

	public override string Name => _impl.Name;

	public override string LocalName => _impl.LocalName;

	public override string NamespaceURI => _impl.NamespaceURI;

	public override string Prefix => _impl.Prefix;

	public override string Value => _impl.Value;

	public override string BaseURI => _impl.BaseURI;

	public override bool IsEmptyElement => _impl.IsEmptyElement;

	public override bool IsDefault => _impl.IsDefault;

	public override ReadState ReadState => _impl.ReadState;

	public override XmlNameTable NameTable => _impl.NameTable;

	public override bool CanResolveEntity => true;

	public EntityHandling EntityHandling
	{
		set
		{
			_impl.EntityHandling = entityHandling;
		}
	}

	public XmlResolver? XmlResolver
	{
		set
		{
			_impl.XmlResolver = xmlResolver;
		}
	}

	internal XmlTextReaderImpl Impl => _impl;

	internal bool XmlValidatingReaderCompatibilityMode
	{
		set
		{
			_impl.XmlValidatingReaderCompatibilityMode = xmlValidatingReaderCompatibilityMode;
		}
	}

	internal override IDtdInfo? DtdInfo => _impl.DtdInfo;

	public XmlTextReader(TextReader P_0, XmlNameTable P_1)
	{
		_impl = new XmlTextReaderImpl(P_0, P_1);
		_impl.OuterReader = this;
	}

	public override bool MoveToAttribute(string P_0)
	{
		return _impl.MoveToAttribute(P_0);
	}

	public override bool MoveToFirstAttribute()
	{
		return _impl.MoveToFirstAttribute();
	}

	public override bool MoveToNextAttribute()
	{
		return _impl.MoveToNextAttribute();
	}

	public override bool MoveToElement()
	{
		return _impl.MoveToElement();
	}

	public override bool ReadAttributeValue()
	{
		return _impl.ReadAttributeValue();
	}

	public override bool Read()
	{
		return _impl.Read();
	}

	public override void Close()
	{
		_impl.Close();
	}

	public override string? LookupNamespace(string P_0)
	{
		string text = _impl.LookupNamespace(P_0);
		if (text != null && text.Length == 0)
		{
			text = null;
		}
		return text;
	}

	public override void ResolveEntity()
	{
		_impl.ResolveEntity();
	}

	string IXmlNamespaceResolver.LookupNamespace(string P_0)
	{
		return _impl.LookupNamespace(P_0);
	}

	string IXmlNamespaceResolver.LookupPrefix(string P_0)
	{
		return _impl.LookupPrefix(P_0);
	}
}
