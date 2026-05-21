using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;
using MS.Internal.Xml.XPath;

namespace System.Xml.XPath;

public abstract class XPathNavigator : XPathItem, ICloneable, IXPathNavigable, IXmlNamespaceResolver
{
	public override XmlSchemaType? XmlType
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null && schemaInfo.Validity == XmlSchemaValidity.Valid)
			{
				XmlSchemaType memberType = schemaInfo.MemberType;
				if (memberType != null)
				{
					return memberType;
				}
				return schemaInfo.SchemaType;
			}
			return null;
		}
	}

	public override object TypedValue
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ChangeType(Value, datatype.ValueType, this);
						}
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ChangeType(datatype.ParseValue(Value, NameTable, this), datatype.ValueType, this);
						}
					}
				}
			}
			return Value;
		}
	}

	public override Type ValueType
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return datatype.ValueType;
						}
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return datatype.ValueType;
						}
					}
				}
			}
			return typeof(string);
		}
	}

	public override bool ValueAsBoolean
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						return xmlSchemaType.ValueConverter.ToBoolean(Value);
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ToBoolean(datatype.ParseValue(Value, NameTable, this));
						}
					}
				}
			}
			return XmlUntypedConverter.Untyped.ToBoolean(Value);
		}
	}

	public override DateTime ValueAsDateTime
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						return xmlSchemaType.ValueConverter.ToDateTime(Value);
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ToDateTime(datatype.ParseValue(Value, NameTable, this));
						}
					}
				}
			}
			return XmlUntypedConverter.Untyped.ToDateTime(Value);
		}
	}

	public override double ValueAsDouble
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						return xmlSchemaType.ValueConverter.ToDouble(Value);
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ToDouble(datatype.ParseValue(Value, NameTable, this));
						}
					}
				}
			}
			return XmlUntypedConverter.Untyped.ToDouble(Value);
		}
	}

	public override int ValueAsInt
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						return xmlSchemaType.ValueConverter.ToInt32(Value);
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ToInt32(datatype.ParseValue(Value, NameTable, this));
						}
					}
				}
			}
			return XmlUntypedConverter.Untyped.ToInt32(Value);
		}
	}

	public override long ValueAsLong
	{
		get
		{
			IXmlSchemaInfo schemaInfo = SchemaInfo;
			if (schemaInfo != null)
			{
				if (schemaInfo.Validity == XmlSchemaValidity.Valid)
				{
					XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						return xmlSchemaType.ValueConverter.ToInt64(Value);
					}
				}
				else
				{
					XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
					if (xmlSchemaType != null)
					{
						XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
						if (datatype != null)
						{
							return xmlSchemaType.ValueConverter.ToInt64(datatype.ParseValue(Value, NameTable, this));
						}
					}
				}
			}
			return XmlUntypedConverter.Untyped.ToInt64(Value);
		}
	}

	public abstract XmlNameTable NameTable { get; }

	public abstract XPathNodeType NodeType { get; }

	public abstract string LocalName { get; }

	public abstract string Name { get; }

	public abstract string NamespaceURI { get; }

	public abstract string BaseURI { get; }

	public virtual string XmlLang
	{
		get
		{
			XPathNavigator xPathNavigator = Clone();
			do
			{
				if (xPathNavigator.MoveToAttribute("lang", "http://www.w3.org/XML/1998/namespace"))
				{
					return xPathNavigator.Value;
				}
			}
			while (xPathNavigator.MoveToParent());
			return string.Empty;
		}
	}

	public virtual object? UnderlyingObject => null;

	public virtual IXmlSchemaInfo? SchemaInfo => this as IXmlSchemaInfo;

	public override string ToString()
	{
		return Value;
	}

	public override object ValueAs(Type P_0, IXmlNamespaceResolver? P_1)
	{
		if (P_1 == null)
		{
			P_1 = this;
		}
		IXmlSchemaInfo schemaInfo = SchemaInfo;
		if (schemaInfo != null)
		{
			if (schemaInfo.Validity == XmlSchemaValidity.Valid)
			{
				XmlSchemaType xmlSchemaType = schemaInfo.MemberType ?? schemaInfo.SchemaType;
				if (xmlSchemaType != null)
				{
					return xmlSchemaType.ValueConverter.ChangeType(Value, P_0, P_1);
				}
			}
			else
			{
				XmlSchemaType xmlSchemaType = schemaInfo.SchemaType;
				if (xmlSchemaType != null)
				{
					XmlSchemaDatatype datatype = xmlSchemaType.Datatype;
					if (datatype != null)
					{
						return xmlSchemaType.ValueConverter.ChangeType(datatype.ParseValue(Value, NameTable, P_1), P_0, P_1);
					}
				}
			}
		}
		return XmlUntypedConverter.Untyped.ChangeType(Value, P_0, P_1);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public virtual XPathNavigator CreateNavigator()
	{
		return Clone();
	}

	public virtual string? LookupNamespace(string P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (NodeType != XPathNodeType.Element)
		{
			XPathNavigator xPathNavigator = Clone();
			if (xPathNavigator.MoveToParent())
			{
				return xPathNavigator.LookupNamespace(P_0);
			}
		}
		else if (MoveToNamespace(P_0))
		{
			string value = Value;
			MoveToParent();
			return value;
		}
		if (P_0.Length == 0)
		{
			return string.Empty;
		}
		if (P_0 == "xml")
		{
			return "http://www.w3.org/XML/1998/namespace";
		}
		if (P_0 == "xmlns")
		{
			return "http://www.w3.org/2000/xmlns/";
		}
		return null;
	}

	public virtual string? LookupPrefix(string P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		XPathNavigator xPathNavigator = Clone();
		if (NodeType != XPathNodeType.Element)
		{
			if (xPathNavigator.MoveToParent())
			{
				return xPathNavigator.LookupPrefix(P_0);
			}
		}
		else if (xPathNavigator.MoveToFirstNamespace(XPathNamespaceScope.All))
		{
			do
			{
				if (P_0 == xPathNavigator.Value)
				{
					return xPathNavigator.LocalName;
				}
			}
			while (xPathNavigator.MoveToNextNamespace(XPathNamespaceScope.All));
		}
		if (P_0 == LookupNamespace(string.Empty))
		{
			return string.Empty;
		}
		if (P_0 == "http://www.w3.org/XML/1998/namespace")
		{
			return "xml";
		}
		if (P_0 == "http://www.w3.org/2000/xmlns/")
		{
			return "xmlns";
		}
		return null;
	}

	public abstract XPathNavigator Clone();

	public virtual bool MoveToAttribute(string P_0, string P_1)
	{
		if (MoveToFirstAttribute())
		{
			do
			{
				if (P_0 == LocalName && P_1 == NamespaceURI)
				{
					return true;
				}
			}
			while (MoveToNextAttribute());
			MoveToParent();
		}
		return false;
	}

	public abstract bool MoveToFirstAttribute();

	public abstract bool MoveToNextAttribute();

	public virtual bool MoveToNamespace(string P_0)
	{
		if (MoveToFirstNamespace(XPathNamespaceScope.All))
		{
			do
			{
				if (P_0 == LocalName)
				{
					return true;
				}
			}
			while (MoveToNextNamespace(XPathNamespaceScope.All));
			MoveToParent();
		}
		return false;
	}

	public abstract bool MoveToFirstNamespace(XPathNamespaceScope P_0);

	public abstract bool MoveToNextNamespace(XPathNamespaceScope P_0);

	public bool MoveToFirstNamespace()
	{
		return MoveToFirstNamespace(XPathNamespaceScope.All);
	}

	public bool MoveToNextNamespace()
	{
		return MoveToNextNamespace(XPathNamespaceScope.All);
	}

	public abstract bool MoveToNext();

	public abstract bool MoveToFirstChild();

	public abstract bool MoveToParent();

	public virtual void MoveToRoot()
	{
		while (MoveToParent())
		{
		}
	}

	public abstract bool MoveTo(XPathNavigator P_0);

	public abstract bool MoveToId(string P_0);

	public abstract bool IsSamePosition(XPathNavigator P_0);

	public virtual bool IsDescendant([NotNullWhen(true)] XPathNavigator? P_0)
	{
		if (P_0 != null)
		{
			P_0 = P_0.Clone();
			while (P_0.MoveToParent())
			{
				if (P_0.IsSamePosition(this))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual XmlNodeOrder ComparePosition(XPathNavigator? P_0)
	{
		if (P_0 == null)
		{
			return XmlNodeOrder.Unknown;
		}
		if (IsSamePosition(P_0))
		{
			return XmlNodeOrder.Same;
		}
		XPathNavigator xPathNavigator = Clone();
		XPathNavigator xPathNavigator2 = P_0.Clone();
		int num = GetDepth(xPathNavigator.Clone());
		int num2 = GetDepth(xPathNavigator2.Clone());
		if (num > num2)
		{
			while (num > num2)
			{
				xPathNavigator.MoveToParent();
				num--;
			}
			if (xPathNavigator.IsSamePosition(xPathNavigator2))
			{
				return XmlNodeOrder.After;
			}
		}
		if (num2 > num)
		{
			while (num2 > num)
			{
				xPathNavigator2.MoveToParent();
				num2--;
			}
			if (xPathNavigator.IsSamePosition(xPathNavigator2))
			{
				return XmlNodeOrder.Before;
			}
		}
		XPathNavigator xPathNavigator3 = xPathNavigator.Clone();
		XPathNavigator xPathNavigator4 = xPathNavigator2.Clone();
		while (true)
		{
			if (!xPathNavigator3.MoveToParent() || !xPathNavigator4.MoveToParent())
			{
				return XmlNodeOrder.Unknown;
			}
			if (xPathNavigator3.IsSamePosition(xPathNavigator4))
			{
				break;
			}
			xPathNavigator.MoveToParent();
			xPathNavigator2.MoveToParent();
		}
		_ = xPathNavigator.GetType().ToString() != "Microsoft.VisualStudio.Modeling.StoreNavigator";
		return CompareSiblings(xPathNavigator, xPathNavigator2);
	}

	public virtual XPathNodeIterator Select(string P_0)
	{
		return Select(XPathExpression.Compile(P_0));
	}

	public virtual XPathNodeIterator Select(XPathExpression P_0)
	{
		if (!(Evaluate(P_0) is XPathNodeIterator result))
		{
			throw XPathException.Create("Xp_NodeSetExpected");
		}
		return result;
	}

	public virtual object Evaluate(XPathExpression P_0)
	{
		return Evaluate(P_0, null);
	}

	public virtual object Evaluate(XPathExpression P_0, XPathNodeIterator? P_1)
	{
		if (!(P_0 is CompiledXpathExpr compiledXpathExpr))
		{
			throw XPathException.Create("Xp_BadQueryObject");
		}
		Query query = Query.Clone(compiledXpathExpr.QueryTree);
		query.Reset();
		if (P_1 == null)
		{
			P_1 = new XPathSingletonIterator(Clone(), true);
		}
		object obj = query.Evaluate(P_1);
		if (obj is XPathNodeIterator)
		{
			return new XPathSelectionIterator(P_1.Current, query);
		}
		return obj;
	}

	public virtual XPathNodeIterator SelectChildren(XPathNodeType P_0)
	{
		return new XPathChildIterator(Clone(), P_0);
	}

	public virtual XPathNodeIterator SelectChildren(string P_0, string P_1)
	{
		return new XPathChildIterator(Clone(), P_0, P_1);
	}

	public virtual XPathNodeIterator SelectDescendants(XPathNodeType P_0, bool P_1)
	{
		return new XPathDescendantIterator(Clone(), P_0, P_1);
	}

	public virtual XPathNodeIterator SelectDescendants(string P_0, string P_1, bool P_2)
	{
		return new XPathDescendantIterator(Clone(), P_0, P_1, P_2);
	}

	private static int GetDepth(XPathNavigator P_0)
	{
		int num = 0;
		while (P_0.MoveToParent())
		{
			num++;
		}
		return num;
	}

	private static XmlNodeOrder CompareSiblings(XPathNavigator P_0, XPathNavigator P_1)
	{
		int num = 0;
		switch (P_0.NodeType)
		{
		case XPathNodeType.Attribute:
			num++;
			break;
		default:
			num += 2;
			break;
		case XPathNodeType.Namespace:
			break;
		}
		switch (P_1.NodeType)
		{
		case XPathNodeType.Namespace:
			if (num != 0)
			{
				break;
			}
			while (P_0.MoveToNextNamespace())
			{
				if (P_0.IsSamePosition(P_1))
				{
					return XmlNodeOrder.Before;
				}
			}
			break;
		case XPathNodeType.Attribute:
			num--;
			if (num != 0)
			{
				break;
			}
			while (P_0.MoveToNextAttribute())
			{
				if (P_0.IsSamePosition(P_1))
				{
					return XmlNodeOrder.Before;
				}
			}
			break;
		default:
			num -= 2;
			if (num != 0)
			{
				break;
			}
			while (P_0.MoveToNext())
			{
				if (P_0.IsSamePosition(P_1))
				{
					return XmlNodeOrder.Before;
				}
			}
			break;
		}
		if (num >= 0)
		{
			return XmlNodeOrder.After;
		}
		return XmlNodeOrder.Before;
	}
}
