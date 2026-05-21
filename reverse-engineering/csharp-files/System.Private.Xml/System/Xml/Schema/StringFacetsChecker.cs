using System.CodeDom.Compiler;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace System.Xml.Schema;

internal sealed class StringFacetsChecker : FacetsChecker
{
	[GeneratedRegex("^([a-zA-Z]{1,8})(-[a-zA-Z0-9]{1,8})*$", RegexOptions.ExplicitCapture)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "7.0.10.26716")]
	private static Regex LanguageRegex()
	{
		return _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__LanguageRegex_2.Instance;
	}

	internal override Exception CheckValueFacets(object P_0, XmlSchemaDatatype P_1)
	{
		string text = P_1.ValueConverter.ToString(P_0);
		return CheckValueFacets(text, P_1, true);
	}

	internal override Exception CheckValueFacets(string P_0, XmlSchemaDatatype P_1)
	{
		return CheckValueFacets(P_0, P_1, true);
	}

	internal static Exception CheckValueFacets(string P_0, XmlSchemaDatatype P_1, bool P_2)
	{
		int length = P_0.Length;
		RestrictionFacets restriction = P_1.Restriction;
		RestrictionFlags restrictionFlags = restriction?.Flags ?? ((RestrictionFlags)0);
		Exception ex = CheckBuiltInFacets(P_0, P_1.TypeCode, P_2);
		if (ex != null)
		{
			return ex;
		}
		if (restrictionFlags != 0)
		{
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
			if ((restrictionFlags & RestrictionFlags.Enumeration) != 0 && !MatchEnumeration(P_0, restriction.Enumeration, P_1))
			{
				return new XmlSchemaException("Sch_EnumerationConstraintFailed", string.Empty);
			}
		}
		return null;
	}

	internal override bool MatchEnumeration(object P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		return MatchEnumeration(P_2.ValueConverter.ToString(P_0), P_1, P_2);
	}

	private static bool MatchEnumeration(string P_0, ArrayList P_1, XmlSchemaDatatype P_2)
	{
		if (P_2.TypeCode == XmlTypeCode.AnyUri)
		{
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_0.Equals(((Uri)P_1[i]).OriginalString))
				{
					return true;
				}
			}
		}
		else
		{
			for (int j = 0; j < P_1.Count; j++)
			{
				if (P_0.Equals((string)P_1[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static Exception CheckBuiltInFacets(string P_0, XmlTypeCode P_1, bool P_2)
	{
		Exception result = null;
		switch (P_1)
		{
		case XmlTypeCode.AnyUri:
			if (P_2)
			{
				result = XmlConvert.TryToUri(P_0, out var _);
			}
			break;
		case XmlTypeCode.NormalizedString:
			result = XmlConvert.TryVerifyNormalizedString(P_0);
			break;
		case XmlTypeCode.Token:
			result = XmlConvert.TryVerifyTOKEN(P_0);
			break;
		case XmlTypeCode.Language:
			if (P_0 == null || P_0.Length == 0)
			{
				return new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
			}
			if (!LanguageRegex().IsMatch(P_0))
			{
				return new XmlSchemaException("Sch_InvalidLanguageId", string.Empty);
			}
			break;
		case XmlTypeCode.NmToken:
			result = XmlConvert.TryVerifyNMTOKEN(P_0);
			break;
		case XmlTypeCode.Name:
			result = XmlConvert.TryVerifyName(P_0);
			break;
		case XmlTypeCode.NCName:
		case XmlTypeCode.Id:
		case XmlTypeCode.Idref:
		case XmlTypeCode.Entity:
			result = XmlConvert.TryVerifyNCName(P_0);
			break;
		}
		return result;
	}
}
