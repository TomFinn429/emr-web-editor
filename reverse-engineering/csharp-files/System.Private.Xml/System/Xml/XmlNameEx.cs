using System.Xml.Schema;

namespace System.Xml;

internal sealed class XmlNameEx : XmlName
{
	private byte _flags;

	private readonly XmlSchemaSimpleType _memberType;

	private readonly XmlSchemaType _schemaType;

	private readonly object _decl;

	public override XmlSchemaValidity Validity
	{
		get
		{
			if (!ownerDoc.CanReportValidity)
			{
				return XmlSchemaValidity.NotKnown;
			}
			return (XmlSchemaValidity)(_flags & 3);
		}
	}

	public override bool IsDefault => (_flags & 4) != 0;

	public override bool IsNil => (_flags & 8) != 0;

	public override XmlSchemaSimpleType MemberType => _memberType;

	public override XmlSchemaType SchemaType => _schemaType;

	public override XmlSchemaElement SchemaElement
	{
		get
		{
			_ = _decl;
			return null;
		}
	}

	public override XmlSchemaAttribute SchemaAttribute
	{
		get
		{
			_ = _decl;
			return null;
		}
	}

	internal XmlNameEx(string P_0, string P_1, string P_2, int P_3, XmlDocument P_4, XmlName P_5, IXmlSchemaInfo P_6)
		: base(P_0, P_1, P_2, P_3, P_4, P_5)
	{
		SetValidity(P_6.Validity);
		SetIsDefault(P_6.IsDefault);
		SetIsNil(P_6.IsNil);
		_memberType = P_6.MemberType;
		_schemaType = P_6.SchemaType;
		_decl = ((P_6.SchemaElement != null) ? ((XmlSchemaAnnotated)P_6.SchemaElement) : ((XmlSchemaAnnotated)P_6.SchemaAttribute));
	}

	public void SetValidity(XmlSchemaValidity P_0)
	{
		_flags = (byte)((_flags & -4) | (byte)P_0);
	}

	public void SetIsDefault(bool P_0)
	{
		if (P_0)
		{
			_flags |= 4;
		}
		else
		{
			_flags = (byte)(_flags & -5);
		}
	}

	public void SetIsNil(bool P_0)
	{
		if (P_0)
		{
			_flags |= 8;
		}
		else
		{
			_flags = (byte)(_flags & -9);
		}
	}

	public override bool Equals(IXmlSchemaInfo P_0)
	{
		if (P_0 != null && P_0.Validity == (XmlSchemaValidity)(_flags & 3) && P_0.IsDefault == ((_flags & 4) != 0) && P_0.IsNil == ((_flags & 8) != 0) && P_0.MemberType == _memberType && P_0.SchemaType == _schemaType)
		{
			XmlSchemaElement? schemaElement = P_0.SchemaElement;
			_ = _decl;
			if (schemaElement == null)
			{
				XmlSchemaAttribute? schemaAttribute = P_0.SchemaAttribute;
				_ = _decl;
				if (schemaAttribute == null)
				{
					return true;
				}
			}
		}
		return false;
	}
}
