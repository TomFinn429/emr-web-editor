namespace System.Xml.Schema;

internal sealed class Datatype_untypedAtomicType : Datatype_anyAtomicType
{
	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Preserve;

	public override XmlTypeCode TypeCode => XmlTypeCode.UntypedAtomic;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlUntypedConverter.Untyped;
	}
}
