using System.Collections;

namespace System.Xml.Schema;

internal sealed class XmlAnyListConverter : XmlListConverter
{
	public static readonly XmlValueConverter ItemList = new XmlAnyListConverter((XmlBaseConverter)XmlAnyConverter.Item);

	public static readonly XmlValueConverter AnyAtomicList = new XmlAnyListConverter((XmlBaseConverter)XmlAnyConverter.AnyAtomic);

	private XmlAnyListConverter(XmlBaseConverter P_0)
		: base(P_0)
	{
	}

	public override object ChangeType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (!(P_0 is IEnumerable) || P_0.GetType() == XmlBaseConverter.StringType || P_0.GetType() == XmlBaseConverter.ByteArrayType)
		{
			P_0 = new object[1] { P_0 };
		}
		return ChangeListType(P_0, P_1, P_2);
	}
}
