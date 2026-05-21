namespace System.Xml.Schema;

internal sealed class QmarkNode : InteriorNode
{
	public override bool IsNullable => true;

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		base.LeftChild.ConstructPos(P_0, P_1, P_2);
	}
}
