using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class SchemaElementDecl : SchemaDeclBase, IDtdAttributeListInfo
{
	private readonly Dictionary<XmlQualifiedName, SchemaAttDef> _attdefs = new Dictionary<XmlQualifiedName, SchemaAttDef>();

	private List<IDtdDefaultAttributeInfo> _defaultAttdefs;

	private bool _isIdDeclared;

	private bool _hasNonCDataAttribute;

	private bool _hasRequiredAttribute;

	private bool _isNotationDeclared;

	private readonly Dictionary<XmlQualifiedName, XmlQualifiedName> _prohibitedAttributes = new Dictionary<XmlQualifiedName, XmlQualifiedName>();

	private ContentValidator _contentValidator;

	private XmlSchemaAnyAttribute _anyAttribute;

	internal static readonly SchemaElementDecl Empty = new SchemaElementDecl();

	bool IDtdAttributeListInfo.HasNonCDataAttributes => _hasNonCDataAttribute;

	internal bool IsIdDeclared
	{
		get
		{
			return _isIdDeclared;
		}
		set
		{
			_isIdDeclared = isIdDeclared;
		}
	}

	internal bool HasNonCDataAttribute
	{
		get
		{
			return _hasNonCDataAttribute;
		}
		set
		{
			_hasNonCDataAttribute = hasNonCDataAttribute;
		}
	}

	internal bool IsNotationDeclared
	{
		get
		{
			return _isNotationDeclared;
		}
		set
		{
			_isNotationDeclared = isNotationDeclared;
		}
	}

	internal ContentValidator ContentValidator
	{
		get
		{
			return _contentValidator;
		}
		set
		{
			_contentValidator = contentValidator;
		}
	}

	internal XmlSchemaAnyAttribute AnyAttribute
	{
		set
		{
			_anyAttribute = anyAttribute;
		}
	}

	internal IList<IDtdDefaultAttributeInfo> DefaultAttDefs => _defaultAttdefs;

	internal Dictionary<XmlQualifiedName, SchemaAttDef> AttDefs => _attdefs;

	internal SchemaElementDecl()
	{
	}

	internal SchemaElementDecl(XmlSchemaDatatype P_0)
	{
		base.Datatype = P_0;
		_contentValidator = ContentValidator.TextOnly;
	}

	internal SchemaElementDecl(XmlQualifiedName P_0, string P_1)
		: base(P_0, P_1)
	{
	}

	internal static SchemaElementDecl CreateAnyTypeElementDecl()
	{
		SchemaElementDecl schemaElementDecl = new SchemaElementDecl();
		schemaElementDecl.Datatype = DatatypeImplementation.AnySimpleType.Datatype;
		return schemaElementDecl;
	}

	IDtdAttributeInfo IDtdAttributeListInfo.LookupAttribute(string P_0, string P_1)
	{
		XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(P_1, P_0);
		if (_attdefs.TryGetValue(xmlQualifiedName, out var result))
		{
			return result;
		}
		return null;
	}

	IEnumerable<IDtdDefaultAttributeInfo> IDtdAttributeListInfo.LookupDefaultAttributes()
	{
		return _defaultAttdefs;
	}

	internal void AddAttDef(SchemaAttDef P_0)
	{
		_attdefs.Add(P_0.Name, P_0);
		if (P_0.Presence == Use.Required || P_0.Presence == Use.RequiredFixed)
		{
			_hasRequiredAttribute = true;
		}
		if (P_0.Presence == Use.Default || P_0.Presence == Use.Fixed)
		{
			if (_defaultAttdefs == null)
			{
				_defaultAttdefs = new List<IDtdDefaultAttributeInfo>();
			}
			_defaultAttdefs.Add(P_0);
		}
	}

	internal SchemaAttDef GetAttDef(XmlQualifiedName P_0)
	{
		if (_attdefs.TryGetValue(P_0, out var result))
		{
			return result;
		}
		return null;
	}
}
