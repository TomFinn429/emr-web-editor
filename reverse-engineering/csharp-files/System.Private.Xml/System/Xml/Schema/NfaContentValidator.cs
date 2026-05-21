namespace System.Xml.Schema;

internal sealed class NfaContentValidator : ContentValidator
{
	private readonly BitSet _firstpos;

	private readonly BitSet[] _followpos;

	private readonly SymbolsDictionary _symbols;

	private readonly Positions _positions;

	private readonly int _endMarkerPos;

	internal NfaContentValidator(BitSet P_0, BitSet[] P_1, SymbolsDictionary P_2, Positions P_3, int P_4, XmlSchemaContentType P_5, bool P_6, bool P_7)
		: base(P_5, P_6, P_7)
	{
		_firstpos = P_0;
		_followpos = P_1;
		_symbols = P_2;
		_positions = P_3;
		_endMarkerPos = P_4;
	}
}
