namespace System.Xml;

public class XmlImplementation
{
	private readonly XmlNameTable _nameTable;

	internal XmlNameTable NameTable => _nameTable;

	public XmlImplementation()
		: this(new NameTable())
	{
	}

	public XmlImplementation(XmlNameTable P_0)
	{
		_nameTable = P_0;
	}

	public virtual XmlDocument CreateDocument()
	{
		return new XmlDocument(this);
	}
}
