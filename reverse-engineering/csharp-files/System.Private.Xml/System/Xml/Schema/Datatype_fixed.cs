namespace System.Xml.Schema;

internal sealed class Datatype_fixed : Datatype_decimal
{
	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		Exception ex;
		try
		{
			decimal num = XmlConvert.ToDecimal(P_0);
			ex = Numeric10FacetsChecker.CheckTotalAndFractionDigits(num, 18, 4, true, true);
			if (ex == null)
			{
				return num;
			}
		}
		catch (XmlSchemaException)
		{
			throw;
		}
		catch (Exception ex3)
		{
			throw new XmlSchemaException(System.SR.Format("Sch_InvalidValue", P_0), ex3);
		}
		throw ex;
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		decimal num;
		Exception ex = XmlConvert.TryToDecimal(P_0, out num);
		if (ex == null)
		{
			ex = Numeric10FacetsChecker.CheckTotalAndFractionDigits(num, 18, 4, true, true);
			if (ex == null)
			{
				P_3 = num;
				return null;
			}
		}
		return ex;
	}
}
