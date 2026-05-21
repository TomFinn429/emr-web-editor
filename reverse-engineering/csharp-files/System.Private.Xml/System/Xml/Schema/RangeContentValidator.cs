namespace System.Xml.Schema;

internal sealed class RangeContentValidator : ContentValidator
{
	private readonly BitSet _firstpos;

	private readonly BitSet[] _followpos;

	private readonly BitSet _positionsWithRangeTerminals;

	private readonly SymbolsDictionary _symbols;

	private readonly Positions _positions;

	private readonly int _minMaxNodesCount;

	private readonly int _endMarkerPos;

	internal RangeContentValidator(BitSet P_0, BitSet[] P_1, SymbolsDictionary P_2, Positions P_3, int P_4, XmlSchemaContentType P_5, bool P_6, BitSet P_7, int P_8)
		: base(P_5, false, P_6)
	{
		_firstpos = P_0;
		_followpos = P_1;
		_symbols = P_2;
		_positions = P_3;
		_positionsWithRangeTerminals = P_7;
		_minMaxNodesCount = P_8;
		_endMarkerPos = P_4;
	}
}
