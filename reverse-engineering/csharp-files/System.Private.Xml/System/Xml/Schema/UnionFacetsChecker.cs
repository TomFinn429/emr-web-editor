using System.Collections;

namespace System.Xml.Schema;

internal sealed class UnionFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, P_1))
		{
			return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_2.Compare(P_0, P_1[i]) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
