using System.Collections.Generic;

namespace System.Xml;

internal interface IDtdAttributeListInfo
{
	bool HasNonCDataAttributes { get; }

	IDtdAttributeInfo LookupAttribute(string P_0, string P_1);

	IEnumerable<IDtdDefaultAttributeInfo> LookupDefaultAttributes();
}
