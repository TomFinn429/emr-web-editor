namespace System.Xml.Schema;

internal abstract class SyntaxTreeNode
{
	public abstract bool IsNullable { get; }

	public virtual bool IsRangeNode => false;

	public abstract void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2);

	public abstract void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2);
}
