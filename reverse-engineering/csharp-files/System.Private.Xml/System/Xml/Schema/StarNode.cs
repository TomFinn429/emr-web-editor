namespace System.Xml.Schema;

internal sealed class StarNode : InteriorNode
{
	public override bool IsNullable => true;

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		base.LeftChild.ConstructPos(P_0, P_1, P_2);
		for (int num = P_1.NextSet(-1); num != -1; num = P_1.NextSet(num))
		{
			P_2[num].Or(P_0);
		}
	}
}
