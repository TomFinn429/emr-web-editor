using System.Collections;

namespace System.Xml.Schema;

internal sealed class QNameFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		XmlQualifiedName xmlQualifiedName = (XmlQualifiedName)P_1.ValueConverter.ChangeType(P_0, typeof(XmlQualifiedName));
		return CheckValueFacets(xmlQualifiedName, P_1);
	}

	internal override Exception CheckValueFacets(XmlQualifiedName P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if (restrictionFlags != 0)
		{
			string text = P_0.ToString();
			int length = text.Length;
			if ((restrictionFlags & RestrictionFlags.Length) != 0 && restriction.Length != length)
			{
				return new XmlSchemaException("Sch_LengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MinLength) != 0 && length < restriction.MinLength)
			{
				return new XmlSchemaException("Sch_MinLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MaxLength) != 0 && restriction.MaxLength < length)
			{
				return new XmlSchemaException("Sch_MaxLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration))
			{
				return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
			}
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration((XmlQualifiedName)P_2.ValueConverter.ChangeType(P_0, typeof(XmlQualifiedName)), P_1);
	}

	private static bool MatchEnumeration(XmlQualifiedName P_0, ArrayList P_1)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_0.Equals((XmlQualifiedName)P_1[i]))
			{
				return true;
			}
		}
		return false;
	}
}
