namespace System.Xml;

internal interface IDtdInfo
{
	XmlQualifiedName Name { get; }

	string InternalDtdSubset { get; }

	bool HasDefaultAttributes { get; }

	bool HasNonCDataAttributes { get; }

	IDtdAttributeListInfo LookupAttributeList(string P_0, string P_1);

	IDtdEntityInfo LookupEntity(string P_0);
}
