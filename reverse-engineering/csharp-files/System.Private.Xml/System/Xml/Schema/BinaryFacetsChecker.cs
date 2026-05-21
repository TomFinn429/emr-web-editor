using System.Collections;

namespace System.Xml.Schema;

internal sealed class BinaryFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		byte[] array = (byte[])P_0;
		return CheckValueFacets(array, P_1);
	}

	internal override Exception CheckValueFacets(byte[] P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		int num = P_0.Length;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if (restrictionFlags != 0)
		{
			if ((restrictionFlags & RestrictionFlags.Length) != 0 && restriction.Length != num)
			{
				return new XmlSchemaException("Sch_LengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MinLength) != 0 && num < restriction.MinLength)
			{
				return new XmlSchemaException("Sch_MinLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MaxLength) != 0 && restriction.MaxLength < num)
			{
				return new XmlSchemaException("Sch_MaxLengthConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, P_1))
			{
				return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
			}
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration((byte[])P_0, P_1, P_2);
	}

	private static bool MatchEnumeration(byte[] P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_2.Compare(P_0, (byte[])P_1[i]) == 0)
			{
				return true;
			}
		}
		return false;
	}
}
