using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class SchemaInfo : IDtdInfo
{
	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _elementDecls = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _undeclaredElementDecls = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private Dictionary<XmlQualifiedName, SchemaEntity> _generalEntities;

	private Dictionary<XmlQualifiedName, SchemaEntity> _parameterEntities;

	private XmlQualifiedName _docTypeName = XmlQualifiedName.Empty;

	private string _internalDtdSubset = string.Empty;

	private bool _hasNonCDataAttributes;

	private bool _hasDefaultAttributes;

	private readonly Dictionary<string, bool> _targetNamespaces = new Dictionary<string, bool>();

	private readonly Dictionary<XmlQualifiedName, SchemaAttDef> _attributeDecls = new Dictionary<XmlQualifiedName, SchemaAttDef>();

	private SchemaType _schemaType;

	private readonly Dictionary<XmlQualifiedName, SchemaElementDecl> _elementDeclsByType = new Dictionary<XmlQualifiedName, SchemaElementDecl>();

	private Dictionary<string, SchemaNotation> _notations;

	public XmlQualifiedName DocTypeName
	{
		set
		{
			_docTypeName = docTypeName;
		}
	}

	internal string InternalDtdSubset
	{
		set
		{
			_internalDtdSubset = internalDtdSubset;
		}
	}

	internal Dictionary<XmlQualifiedName, SchemaElementDecl> ElementDecls => _elementDecls;

	internal Dictionary<XmlQualifiedName, SchemaElementDecl> UndeclaredElementDecls => _undeclaredElementDecls;

	internal Dictionary<XmlQualifiedName, SchemaEntity> GeneralEntities => _generalEntities ?? (_generalEntities = new Dictionary<XmlQualifiedName, SchemaEntity>());

	internal Dictionary<XmlQualifiedName, SchemaEntity> ParameterEntities => _parameterEntities ?? (_parameterEntities = new Dictionary<XmlQualifiedName, SchemaEntity>());

	internal SchemaType SchemaType
	{
		get
		{
			return _schemaType;
		}
		set
		{
			_schemaType = schemaType;
		}
	}

	internal Dictionary<string, SchemaNotation> Notations => _notations ?? (_notations = new Dictionary<string, SchemaNotation>());

	bool IDtdInfo.HasDefaultAttributes => _hasDefaultAttributes;

	bool IDtdInfo.HasNonCDataAttributes => _hasNonCDataAttributes;

	XmlQualifiedName IDtdInfo.Name => _docTypeName;

	string IDtdInfo.InternalDtdSubset => _internalDtdSubset;

	internal SchemaInfo()
	{
		_schemaType = SchemaType.None;
	}

	internal void Finish()
	{
		Dictionary<XmlQualifiedName, SchemaElementDecl> dictionary = _elementDecls;
		for (int i = 0; i < 2; i++)
		{
			foreach (SchemaElementDecl value in dictionary.Values)
			{
				if (value.HasNonCDataAttribute)
				{
					_hasNonCDataAttributes = true;
				}
				if (value.DefaultAttDefs != null)
				{
					_hasDefaultAttributes = true;
				}
			}
			dictionary = _undeclaredElementDecls;
		}
	}

	IDtdAttributeListInfo IDtdInfo.LookupAttributeList(string P_0, string P_1)
	{
		XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(P_0, P_1);
		if (!_elementDecls.TryGetValue(xmlQualifiedName, out var result))
		{
			_undeclaredElementDecls.TryGetValue(xmlQualifiedName, out result);
		}
		return result;
	}

	IDtdEntityInfo IDtdInfo.LookupEntity(string P_0)
	{
		if (_generalEntities == null)
		{
			return null;
		}
		XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(P_0);
		if (_generalEntities.TryGetValue(xmlQualifiedName, out var result))
		{
			return result;
		}
		return null;
	}
}
