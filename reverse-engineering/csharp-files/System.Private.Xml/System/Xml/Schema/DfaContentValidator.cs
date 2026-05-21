namespace System.Xml.Schema;

internal sealed class DfaContentValidator : ContentValidator
{
	private readonly int[][] _transitionTable;

	private readonly SymbolsDictionary _symbols;

	internal DfaContentValidator(int[][] P_0, SymbolsDictionary P_1, XmlSchemaContentType P_2, bool P_3, bool P_4)
		: base(P_2, P_3, P_4)
	{
		_transitionTable = P_0;
		_symbols = P_1;
	}
}
