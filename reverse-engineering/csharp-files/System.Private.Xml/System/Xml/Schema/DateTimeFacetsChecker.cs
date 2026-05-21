using System.Collections;

namespace System.Xml.Schema;

internal sealed class DateTimeFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		DateTime dateTime = P_1.ValueConverter.ToDateTime(P_0);
		return CheckValueFacets(dateTime, P_1);
	}

	internal override Exception CheckValueFacets(DateTime P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if ((restrictionFlags & RestrictionFlags.MaxInclusive) != 0 && P_1.Compare(P_0, (DateTime)restriction.MaxInclusive) > 0)
		{
			return new XmlSchemaException("Sch_MaxInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MaxExclusive) != 0 && P_1.Compare(P_0, (DateTime)restriction.MaxExclusive) >= 0)
		{
			return new XmlSchemaException("Sch_MaxExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinInclusive) != 0 && P_1.Compare(P_0, (DateTime)restriction.MinInclusive) < 0)
		{
			return new XmlSchemaException("Sch_MinInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinExclusive) != 0 && P_1.Compare(P_0, (DateTime)restriction.MinExclusive) <= 0)
		{
			return new XmlSchemaException("Sch_MinExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, P_1))
		{
			return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration(P_2.ValueConverter.ToDateTime(P_0), P_1, P_2);
	}

	private static bool MatchEnumeration(DateTime P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_2.Compare(P_0, (DateTime)P_1[i]) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
