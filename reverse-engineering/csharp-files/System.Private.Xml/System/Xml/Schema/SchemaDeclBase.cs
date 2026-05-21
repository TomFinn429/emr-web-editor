using System.Collections.Generic;

namespace System.Xml.Schema;

internal abstract class SchemaDeclBase
{
	internal enum Use
	{
		Default,
		Required,
		Implied,
		Fixed,
		RequiredFixed
	}

	protected XmlQualifiedName name = XmlQualifiedName.Empty;

	protected string prefix;

	protected bool isDeclaredInExternal;

	protected Use presence;

	protected XmlSchemaType schemaType;

	protected XmlSchemaDatatype datatype;

	protected string defaultValueRaw;

	protected object defaultValueTyped;

	protected long maxLength;

	protected long minLength;

	protected List<string> values;

	internal XmlQualifiedName Name => name;

	internal string Prefix => prefix ?? string.Empty;

	internal bool IsDeclaredInExternal
	{
		get
		{
			return isDeclaredInExternal;
		}
		set
		{
			isDeclaredInExternal = flag;
		}
	}

	internal Use Presence
	{
		get
		{
			return presence;
		}
		set
		{
			presence = use;
		}
	}

	internal XmlSchemaType SchemaType
	{
		set
		{
			schemaType = xmlSchemaType;
		}
	}

	internal XmlSchemaDatatype Datatype
	{
		get
		{
			return datatype;
		}
		set
		{
			datatype = xmlSchemaDatatype;
		}
	}

	internal List<string> Values => values;

	internal string DefaultValueRaw => defaultValueRaw ?? string.Empty;

	internal object DefaultValueTyped
	{
		get
		{
			return defaultValueTyped;
		}
		set
		{
			defaultValueTyped = obj;
		}
	}

	protected SchemaDeclBase(XmlQualifiedName P_0, string P_1)
	{
		name = P_0;
		prefix = P_1;
		maxLength = -1L;
		minLength = -1L;
	}

	protected SchemaDeclBase()
	{
	}

	internal void AddValue(string P_0)
	{
		if (values == null)
		{
			values = new List<string>();
		}
		values.Add(P_0);
	}
}
