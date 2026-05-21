using System.Collections;

namespace System.Xml.Schema;

internal sealed class Datatype_List : Datatype_anySimpleType
{
	private readonly DatatypeImplementation _itemType;

	private readonly int _minListSize;

	public override Type ValueType => ListValueType;

	public override XmlTokenizedType TokenizedType => _itemType.TokenizedType;

	internal override Type ListValueType => _itemType.ListValueType;

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.listFacetsChecker;

	public override XmlTypeCode TypeCode => _itemType.TypeCode;

	internal DatatypeImplementation ItemType => _itemType;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		XmlSchemaType xmlSchemaType = null;
		XmlSchemaComplexType xmlSchemaComplexType = P_0 as XmlSchemaComplexType;
		XmlSchemaSimpleType xmlSchemaSimpleType;
		if (xmlSchemaComplexType != null)
		{
			do
			{
				xmlSchemaSimpleType = xmlSchemaComplexType.BaseXmlSchemaType as XmlSchemaSimpleType;
				if (xmlSchemaSimpleType != null)
				{
					break;
				}
				xmlSchemaComplexType = xmlSchemaComplexType.BaseXmlSchemaType as XmlSchemaComplexType;
			}
			while (xmlSchemaComplexType != null && xmlSchemaComplexType != XmlSchemaComplexType.AnyType);
		}
		else
		{
			xmlSchemaSimpleType = P_0 as XmlSchemaSimpleType;
		}
		if (xmlSchemaSimpleType != null)
		{
			do
			{
				if (xmlSchemaSimpleType.Content is XmlSchemaSimpleTypeList xmlSchemaSimpleTypeList)
				{
					xmlSchemaType = xmlSchemaSimpleTypeList.BaseItemType;
					break;
				}
				xmlSchemaSimpleType = xmlSchemaSimpleType.BaseXmlSchemaType as XmlSchemaSimpleType;
			}
			while (xmlSchemaSimpleType != null && xmlSchemaSimpleType != DatatypeImplementation.AnySimpleType);
		}
		if (xmlSchemaType == null)
		{
			xmlSchemaType = DatatypeImplementation.GetSimpleTypeFromTypeCode(P_0.Datatype.TypeCode);
		}
		return XmlListConverter.Create(xmlSchemaType.ValueConverter);
	}

	internal Datatype_List(DatatypeImplementation P_0, int P_1)
	{
		_itemType = P_0;
		_minListSize = P_1;
	}

	internal override int Compare(object P_0, object P_1)
	{
		Array array = (Array)P_0;
		Array array2 = (Array)P_1;
		int length = array.Length;
		if (length != array2.Length)
		{
			return -1;
		}
		if (array is XmlAtomicValue[] array3)
		{
			XmlAtomicValue[] array4 = array2 as XmlAtomicValue[];
			for (int i = 0; i < array3.Length; i++)
			{
				XmlSchemaType xmlType = array3[i].XmlType;
				if (xmlType != array4[i].XmlType || !xmlType.Datatype.IsEqual(array3[i].TypedValue, array4[i].TypedValue))
				{
					return -1;
				}
			}
			return 0;
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (_itemType.Compare(array.GetValue(j), array2.GetValue(j)) != 0)
			{
				return -1;
			}
		}
		return 0;
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.listFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ArrayList arrayList = new ArrayList();
			object obj2;
			if (_itemType.Variety == XmlSchemaDatatypeVariety.Union)
			{
				string[] array = XmlConvert.SplitString(P_0);
				int num = 0;
				while (num < array.Length)
				{
					ex = _itemType.TryParseValue(array[num], P_1, P_2, out var obj);
					if (ex == null)
					{
						XsdSimpleValue xsdSimpleValue = (XsdSimpleValue)obj;
						arrayList.Add(new XmlAtomicValue(xsdSimpleValue.XmlType, xsdSimpleValue.TypedValue, P_2));
						num++;
						continue;
					}
					goto IL_011b;
				}
				obj2 = arrayList.ToArray(typeof(XmlAtomicValue));
			}
			else
			{
				string[] array2 = XmlConvert.SplitString(P_0);
				int num2 = 0;
				while (num2 < array2.Length)
				{
					ex = _itemType.TryParseValue(array2[num2], P_1, P_2, out P_3);
					if (ex == null)
					{
						arrayList.Add(P_3);
						num2++;
						continue;
					}
					goto IL_011b;
				}
				obj2 = arrayList.ToArray(_itemType.ValueType);
			}
			if (arrayList.Count < _minListSize)
			{
				return new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
			}
			ex = DatatypeImplementation.listFacetsChecker.CheckValueFacets(obj2, this);
			if (ex == null)
			{
				P_3 = obj2;
				return null;
			}
		}
		goto IL_011b;
		IL_011b:
		return ex;
	}
}
