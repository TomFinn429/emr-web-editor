namespace System.Xml;

internal interface IDtdParser
{
	IDtdInfo ParseInternalDtd(IDtdParserAdapter P_0, bool P_1);

	IDtdInfo ParseFreeFloatingDtd(string P_0, string P_1, string P_2, string P_3, string P_4, IDtdParserAdapter P_5);
}
