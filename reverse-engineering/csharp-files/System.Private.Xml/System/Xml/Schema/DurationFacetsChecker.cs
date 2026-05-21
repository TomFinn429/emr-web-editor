using System.Collections;

namespace System.Xml.Schema;

internal sealed class DurationFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		TimeSpan timeSpan = (TimeSpan)P_1.ValueConverter.ChangeType(P_0, typeof(TimeSpan));
		return CheckValueFacets(timeSpan, P_1);
	}

	internal override Exception CheckValueFacets(TimeSpan P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if ((restrictionFlags & RestrictionFlags.MaxInclusive) != 0 && TimeSpan.Compare(P_0, (TimeSpan)restriction.MaxInclusive) > 0)
		{
			return new XmlSchemaException("Sch_MaxInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MaxExclusive) != 0 && TimeSpan.Compare(P_0, (TimeSpan)restriction.MaxExclusive) >= 0)
		{
			return new XmlSchemaException("Sch_MaxExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinInclusive) != 0 && TimeSpan.Compare(P_0, (TimeSpan)restriction.MinInclusive) < 0)
		{
			return new XmlSchemaException("Sch_MinInclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.MinExclusive) != 0 && TimeSpan.Compare(P_0, (TimeSpan)restriction.MinExclusive) <= 0)
		{
			return new XmlSchemaException("Sch_MinExclusiveConstraintFailed", string.Empty);
		}
		if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration))
		{
			return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration((TimeSpan)P_0, P_1);
	}

	private static bool MatchEnumeration(TimeSpan P_0, ArrayList P_1)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (TimeSpan.Compare(P_0, (TimeSpan)P_1[i]) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
