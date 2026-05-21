using System.Collections;
using System.Globalization;

namespace System.Xml.Schema;

internal sealed class Numeric10FacetsChecker : FacetsChecker
{
	private readonly decimal _maxValue;

	private readonly decimal _minValue;

	internal Numeric10FacetsChecker(decimal P_0, decimal P_1)
	{
		_minValue = P_0;
		_maxValue = P_1;
	}

	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		decimal num = P_1.ValueConverter.ToDecimal(P_0);
		return CheckValueFacets(num, P_1);
	}

	internal override Exception CheckValueFacets(decimal P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		XmlValueConverter valueConverter = P_1.ValueConverter;
		if (P_0 > _maxValue || P_0 < _minValue)
		{
			return new OverflowException(System.SR.Format("XmlConvert_Overflow", P_0.ToString(CultureInfo.InvariantCulture), P_1.TypeCodeString));
		}
		if (restrictionFlags != 0)
		{
			if ((restrictionFlags & RestrictionFlags.MaxInclusive) != 0 && P_0 > valueConverter.ToDecimal(restriction.MaxInclusive))
			{
				return new XmlSchemaException("Sch_MaxInclusiveConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MaxExclusive) != 0 && P_0 >= valueConverter.ToDecimal(restriction.MaxExclusive))
			{
				return new XmlSchemaException("Sch_MaxExclusiveConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MinInclusive) != 0 && P_0 < valueConverter.ToDecimal(restriction.MinInclusive))
			{
				return new XmlSchemaException("Sch_MinInclusiveConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.MinExclusive) != 0 && P_0 <= valueConverter.ToDecimal(restriction.MinExclusive))
			{
				return new XmlSchemaException("Sch_MinExclusiveConstraintFailed", string.Empty);
			}
			if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, valueConverter))
			{
				return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
			}
			return CheckTotalAndFractionDigits(P_0, restriction.TotalDigits, restriction.FractionDigits, (restrictionFlags & RestrictionFlags.TotalDigits) != 0, (restrictionFlags & RestrictionFlags.FractionDigits) != 0);
		}
		return null;
	}

	internal override Exception CheckValueFacets(long P_0, XmlSchemaDatatype P_1)
	{
		decimal num = P_0;
		return CheckValueFacets(num, P_1);
	}

	internal override Exception CheckValueFacets(int P_0, XmlSchemaDatatype P_1)
	{
		decimal num = P_0;
		return CheckValueFacets(num, P_1);
	}

	internal override Exception CheckValueFacets(short P_0, XmlSchemaDatatype P_1)
	{
		decimal num = P_0;
		return CheckValueFacets(num, P_1);
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration(P_2.ValueConverter.ToDecimal(P_0), P_1, P_2.ValueConverter);
	}

	internal static bool MatchEnumeration(decimal P_0, ArrayList P_1, XmlValueConverter P_2)
	{
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_0 == P_2.ToDecimal(P_1[i]))
			{
				return true;
			}
		}
		return false;
	}

	internal static Exception CheckTotalAndFractionDigits(decimal P_0, int P_1, int P_2, bool P_3, bool P_4)
	{
		decimal num = FacetsChecker.Power(10, P_1) - 1m;
		int num2 = 0;
		if (P_0 < 0m)
		{
			P_0 = decimal.Negate(P_0);
		}
		while (decimal.Truncate(P_0) != P_0)
		{
			P_0 *= 10m;
			num2++;
		}
		if (P_3 && (P_0 > num || num2 > P_1))
		{
			return new XmlSchemaException("Sch_TotalDigitsConstraintFailed", string.Empty);
		}
		if (P_4 && num2 > P_2)
		{
			return new XmlSchemaException("Sch_FractionDigitsConstraintFailed", string.Empty);
		}
		return null;
	}
}
