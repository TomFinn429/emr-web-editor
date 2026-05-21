using System.Collections;

namespace System.Xml.Schema;

internal sealed class ListFacetsChecker : FacetsChecker
{
	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		Array array = P_0 as Array;
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		if ((restrictionFlags & (RestrictionFlags.Length | RestrictionFlags.MinLength | RestrictionFlags.MaxLength)) != 0)
		{
			int length = array.Length;
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
		}
		if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, P_1))
		{
			return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		Array array = P_0 as Array;
		Datatype_List datatype_List = P_2 as Datatype_List;
		for (int i = 0; i < array.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < P_1.Count; j++)
			{
				Array array2 = P_1[j] as Array;
				if (datatype_List.ItemType.Compare(array.GetValue(i), array2.GetValue(0)) == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}
}
