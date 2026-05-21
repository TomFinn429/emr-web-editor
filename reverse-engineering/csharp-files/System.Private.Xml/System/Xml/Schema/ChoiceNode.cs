namespace System.Xml.Schema;

internal sealed class ChoiceNode : InteriorNode
{
	public override bool IsNullable
	{
		get
		{
			ChoiceNode choiceNode = this;
			SyntaxTreeNode leftChild;
			do
			{
				if (choiceNode.RightChild.IsNullable)
				{
					return true;
				}
				leftChild = choiceNode.LeftChild;
				choiceNode = leftChild as ChoiceNode;
			}
			while (choiceNode != null);
			return leftChild.IsNullable;
		}
	}

	private static void ConstructChildPos(SyntaxTreeNode P_0, BitSet P_1, BitSet P_2, BitSet[] P_3)
	{
		BitSet bitSet = new BitSet(P_1.Count);
		BitSet bitSet2 = new BitSet(P_2.Count);
		P_0.ConstructPos(bitSet, bitSet2, P_3);
		P_1.Or(bitSet);
		P_2.Or(bitSet2);
	}

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		BitSet bitSet = new BitSet(P_0.Count);
		BitSet bitSet2 = new BitSet(P_1.Count);
		ChoiceNode choiceNode = this;
		SyntaxTreeNode leftChild;
		do
		{
			ConstructChildPos(choiceNode.RightChild, bitSet, bitSet2, P_2);
			leftChild = choiceNode.LeftChild;
			choiceNode = leftChild as ChoiceNode;
		}
		while (choiceNode != null);
		leftChild.ConstructPos(P_0, P_1, P_2);
		P_0.Or(bitSet);
		P_1.Or(bitSet2);
	}

	public override void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
		ExpandTreeNoRecursive(P_0, P_1, P_2);
	}
}
