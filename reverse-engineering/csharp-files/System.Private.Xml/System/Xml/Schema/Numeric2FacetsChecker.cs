using System.Collections;

namespace System.Xml.Schema;

internal sealed class Numeric2FacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		double num = P_1.ValueConverter.ToDouble(P_0);
		return CheckValueFacets(num, P_1);
	}

	internal override Exception CheckValueFacets(double P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		XmlValueConverter valueConverter = P_1.ValueConverter;
		if ((restrictionFlags & RestrictionFlags.MaxInclusive) != 0 && P_0 > valueConverter.ToDouble(restriction.MaxInclusive))
		{
			return new XmlSchemaException("Sch_MaxInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MaxExclusive) != 0 && P_0 >= valueConverter.ToDouble(restriction.MaxExclusive))
		{
			return new XmlSchemaException("Sch_MaxExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinInclusive) != 0 && P_0 < valueConverter.ToDouble(restriction.MinInclusive))
		{
			return new XmlSchemaException("Sch_MinInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinExclusive) != 0 && P_0 <= valueConverter.ToDouble(restriction.MinExclusive))
		{
			return new XmlSchemaException("Sch_MinExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, valueConverter))
		{
			return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
		}
		return null;
	}

	internal override Exception CheckValueFacets(float P_0, XmlSchemaDatatype P_1)
	{
		double num = P_0;
		return CheckValueFacets(num, P_1);
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration(P_2.ValueConverter.ToDouble(P_0), P_1, P_2.ValueConverter);
	}

	private static bool MatchEnumeration(double P_0, ArrayList P_1, XmlValueConverter P_2)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_0 == P_2.ToDouble(P_1[i]))
			{
				return true;
			}
		}
		return false;
	}
}
