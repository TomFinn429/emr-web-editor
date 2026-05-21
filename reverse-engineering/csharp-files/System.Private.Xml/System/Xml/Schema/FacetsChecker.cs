using System.Collections;
using System.Text.RegularExpressions;

namespace System.Xml.Schema;

internal abstract class FacetsChecker
{
	internal virtual Exception CheckLexicalFacets(ref string P_0, XmlSchemaDatatype P_1)
	{
		CheckWhitespaceFacets(ref P_0, P_1);
		return CheckPatternFacets(P_1.Restriction, P_0);
	}

	internal virtual Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(decimal P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(long P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(int P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(short P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(DateTime P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(double P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(float P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(string P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(byte[] P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(TimeSpan P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal virtual Exception CheckValueFacets(XmlQualifiedName P_0, XmlSchemaDatatype P_1)
	{
		return null;
	}

	internal static void CheckWhitespaceFacets(ref string P_0, XmlSchemaDatatype P_1)
	{
		RestrictionFacets restriction = P_1.Restriction;
		switch (P_1.Variety)
		{
		case XmlSchemaDatatypeVariety.List:
			P_0 = P_0.Trim();
			break;
		case XmlSchemaDatatypeVariety.Atomic:
			if (P_1.BuiltInWhitespaceFacet == XmlSchemaWhiteSpace.Collapse)
			{
				P_0 = XmlComplianceUtil.NonCDataNormalize(P_0);
			}
			else if (P_1.BuiltInWhitespaceFacet == XmlSchemaWhiteSpace.Replace)
			{
				P_0 = XmlComplianceUtil.CDataNormalize(P_0);
			}
			else if (restriction != null && (restriction.Flags & RestrictionFlags.WhiteSpace) != 0)
			{
				if (restriction.WhiteSpace == XmlSchemaWhiteSpace.Replace)
				{
					P_0 = XmlComplianceUtil.CDataNormalize(P_0);
				}
				else if (restriction.WhiteSpace == XmlSchemaWhiteSpace.Collapse)
				{
					P_0 = XmlComplianceUtil.NonCDataNormalize(P_0);
				}
			}
			break;
		}
	}

	internal static Exception CheckPatternFacets(RestrictionFacets P_0, string P_1)
	{
		if (P_0 != null && (P_0.Flags & RestrictionFlags.Pattern) != 0)
		{
			for (int i = 0; i < P_0.Patterns.Count; i++)
			{
				Regex regex = (Regex)P_0.Patterns[i];
				if (!regex.IsMatch(P_1))
				{
					return new XmlSchemaException("Sch_PatternConstraintFailed", string.Empty);
				}
			}
		}
		return null;
	}

	internal virtual bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return false;
	}

	internal static decimal Power(int P_0, int P_1)
	{
		decimal result = 1m;
		decimal num = P_0;
		if (P_1 > 28)
		{
			return decimal.MaxValue;
		}
		for (int i = 0; i < P_1; i++)
		{
			result *= num;
		}
		return result;
	}
}
