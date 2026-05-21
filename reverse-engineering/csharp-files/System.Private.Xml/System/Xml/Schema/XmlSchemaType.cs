using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaType : XmlSchemaAnnotated
{
	private XmlSchemaDerivationMethod _final = XmlSchemaDerivationMethod.None;

	private XmlSchemaDerivationMethod _derivedBy;

	private XmlSchemaType _baseSchemaType;

	private XmlSchemaDatatype _datatype;

	private volatile SchemaElementDecl _elementDecl;

	private volatile XmlQualifiedName _qname = XmlQualifiedName.Empty;

	private XmlSchemaContentType _contentType;

	[XmlIgnore]
	public XmlQualifiedName QualifiedName => _qname;

	[XmlIgnore]
	public XmlSchemaType? BaseXmlSchemaType => _baseSchemaType;

	[XmlIgnore]
	public XmlSchemaDatatype? Datatype => _datatype;

	[XmlIgnore]
	public virtual bool IsMixed
	{
		set
		{
		}
	}

	[XmlIgnore]
	public XmlTypeCode TypeCode
	{
		get
		{
			if (this == XmlSchemaComplexType.AnyType)
			{
				return XmlTypeCode.Item;
			}
			if (_datatype == null)
			{
				return XmlTypeCode.None;
			}
			return _datatype.TypeCode;
		}
	}

	[XmlIgnore]
	internal XmlValueConverter ValueConverter
	{
		get
		{
			if (_datatype == null)
			{
				return XmlUntypedConverter.Untyped;
			}
			return _datatype.ValueConverter;
		}
	}

	internal SchemaElementDecl? ElementDecl
	{
		get
		{
			return _elementDecl;
		}
		set
		{
			_elementDecl = elementDecl;
		}
	}

	public static XmlSchemaSimpleType GetBuiltInSimpleType(XmlTypeCode P_0)
	{
		return DatatypeImplementation.GetSimpleTypeFromTypeCode(P_0);
	}

	internal void SetQualifiedName(XmlQualifiedName P_0)
	{
		_qname = P_0;
	}

	internal void SetBaseSchemaType(XmlSchemaType P_0)
	{
		_baseSchemaType = P_0;
	}

	internal void SetDerivedBy(XmlSchemaDerivationMethod P_0)
	{
		_derivedBy = P_0;
	}

	internal void SetDatatype(XmlSchemaDatatype P_0)
	{
		_datatype = P_0;
	}

	internal void SetContentType(XmlSchemaContentType P_0)
	{
		_contentType = P_0;
	}
}
