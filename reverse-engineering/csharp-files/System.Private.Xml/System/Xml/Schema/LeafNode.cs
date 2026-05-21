namespace System.Xml.Schema;

internal class LeafNode : SyntaxTreeNode
{
	private int _pos;

	public int Pos
	{
		get
		{
			return _pos;
		}
		set
		{
			_pos = pos;
		}
	}

	public override bool IsNullable => false;

	public LeafNode(int P_0)
	{
		_pos = P_0;
	}

	public override void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
	}

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		P_0.Set(_pos);
		P_1.Set(_pos);
	}
}
