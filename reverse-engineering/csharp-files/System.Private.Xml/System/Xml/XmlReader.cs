using System.IO;
using System.Reflection;
using System.Xml.Schema;

namespace System.Xml;

[DefaultMember("Item")]
public abstract class XmlReader : IDisposable
{
	public virtual XmlReaderSettings? Settings => null;

	public abstract XmlNodeType NodeType { get; }

	public virtual string Name
	{
		get
		{
			if (Prefix.Length != 0)
			{
				return NameTable.Add(Prefix + ":" + LocalName);
			}
			return LocalName;
		}
	}

	public abstract string LocalName { get; }

	public abstract string NamespaceURI { get; }

	public abstract string Prefix { get; }

	public abstract string Value { get; }

	public abstract string BaseURI { get; }

	public abstract bool IsEmptyElement { get; }

	public virtual bool IsDefault => false;

	public virtual IXmlSchemaInfo? SchemaInfo => this as IXmlSchemaInfo;

	public abstract ReadState ReadState { get; }

	public abstract XmlNameTable NameTable { get; }

	public virtual bool CanResolveEntity => false;

	internal virtual IDtdInfo? DtdInfo => null;

	public abstract bool MoveToAttribute(string P_0);

	public abstract bool MoveToFirstAttribute();

	public abstract bool MoveToNextAttribute();

	public abstract bool MoveToElement();

	public abstract bool ReadAttributeValue();

	public abstract bool Read();

	public virtual void Close()
	{
	}

	public abstract string? LookupNamespace(string P_0);

	public abstract void ResolveEntity();

	public void Dispose()
	{
		Dispose(true);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (P_0 && ReadState != ReadState.Closed)
		{
			Close();
		}
	}

	internal static int CalcBufferSize(Stream P_0)
	{
		int num = 4096;
		if (P_0.CanSeek)
		{
			long length = P_0.Length;
			if (length < num)
			{
				num = (int)length;
			}
			else if (length > 65536)
			{
				num = 8192;
			}
		}
		return num;
	}
}
