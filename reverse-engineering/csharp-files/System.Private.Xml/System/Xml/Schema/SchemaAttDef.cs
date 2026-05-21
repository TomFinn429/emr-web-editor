using System.Diagnostics.CodeAnalysis;

namespace System.Xml.Schema;

internal sealed class SchemaAttDef : SchemaDeclBase, IDtdDefaultAttributeInfo, IDtdAttributeInfo
{
	internal enum Reserve
	{
		None,
		XmlSpace,
		XmlLang
	}

	private string _defExpanded;

	private int _lineNum;

	private int _linePos;

	private int _valueLineNum;

	private int _valueLinePos;

	private Reserve _reserved;

	public static readonly SchemaAttDef Empty = new SchemaAttDef();

	string IDtdAttributeInfo.Prefix => Prefix;

	string IDtdAttributeInfo.LocalName => Name.Name;

	int IDtdAttributeInfo.LineNumber => LineNumber;

	int IDtdAttributeInfo.LinePosition => LinePosition;

	bool IDtdAttributeInfo.IsNonCDataType => TokenizedType != XmlTokenizedType.CDATA;

	bool IDtdAttributeInfo.IsDeclaredInExternal => IsDeclaredInExternal;

	bool IDtdAttributeInfo.IsXmlAttribute => Reserved != Reserve.None;

	string IDtdDefaultAttributeInfo.DefaultValueExpanded => DefaultValueExpanded;

	object IDtdDefaultAttributeInfo.DefaultValueTyped => DefaultValueTyped;

	int IDtdDefaultAttributeInfo.ValueLineNumber => ValueLineNumber;

	int IDtdDefaultAttributeInfo.ValueLinePosition => ValueLinePosition;

	internal int LinePosition
	{
		get
		{
			return _linePos;
		}
		set
		{
			_linePos = linePos;
		}
	}

	internal int LineNumber
	{
		get
		{
			return _lineNum;
		}
		set
		{
			_lineNum = lineNum;
		}
	}

	internal int ValueLinePosition
	{
		get
		{
			return _valueLinePos;
		}
		set
		{
			_valueLinePos = valueLinePos;
		}
	}

	internal int ValueLineNumber
	{
		get
		{
			return _valueLineNum;
		}
		set
		{
			_valueLineNum = valueLineNum;
		}
	}

	internal string DefaultValueExpanded
	{
		get
		{
			return _defExpanded ?? string.Empty;
		}
		[param: AllowNull]
		set
		{
			_defExpanded = defExpanded;
		}
	}

	internal XmlTokenizedType TokenizedType
	{
		get
		{
			return base.Datatype.TokenizedType;
		}
		set
		{
			base.Datatype = XmlSchemaDatatype.FromXmlTokenizedType(xmlTokenizedType);
		}
	}

	internal Reserve Reserved
	{
		get
		{
			return _reserved;
		}
		set
		{
			_reserved = reserved;
		}
	}

	public SchemaAttDef(XmlQualifiedName P_0, string P_1)
		: base(P_0, P_1)
	{
	}

	private SchemaAttDef()
	{
	}

	internal void CheckXmlSpace(IValidationEventHandling P_0)
	{
		if (datatype.TokenizedType == XmlTokenizedType.ENUMERATION && values != null && values.Count <= 2)
		{
			string text = values[0].ToString();
			if (values.Count == 2)
			{
				string text2 = values[1].ToString();
				if ((text == "default" || text2 == "default") && (text == "preserve" || text2 == "preserve"))
				{
					return;
				}
			}
			else if (text == "default" || text == "preserve")
			{
				return;
			}
		}
		P_0.SendEvent(new XmlSchemaException("Sch_XmlSpace", string.Empty), XmlSeverityType.Error);
	}
}
