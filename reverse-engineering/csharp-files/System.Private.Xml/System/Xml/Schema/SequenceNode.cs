using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class SequenceNode : InteriorNode
{
	private struct SequenceConstructPosContext
	{
		public SequenceNode this_;

		public BitSet firstpos;

		public BitSet lastpos;

		public BitSet lastposLeft;

		public BitSet firstposRight;

		public SequenceConstructPosContext(SequenceNode P_0, BitSet P_1, BitSet P_2)
		{
			this_ = P_0;
			firstpos = P_1;
			lastpos = P_2;
			lastposLeft = null;
			firstposRight = null;
		}
	}

	public override bool IsNullable
	{
		get
		{
			SequenceNode sequenceNode = this;
			SyntaxTreeNode leftChild;
			do
			{
				if (sequenceNode.RightChild.IsRangeNode && ((LeafRangeNode)sequenceNode.RightChild).Min == 0m)
				{
					return true;
				}
				if (!sequenceNode.RightChild.IsNullable && !sequenceNode.RightChild.IsRangeNode)
				{
					return false;
				}
				leftChild = sequenceNode.LeftChild;
				sequenceNode = leftChild as SequenceNode;
			}
			while (sequenceNode != null);
			return leftChild.IsNullable;
		}
	}

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		Stack<SequenceConstructPosContext> stack = new Stack<SequenceConstructPosContext>();
		SequenceConstructPosContext sequenceConstructPosContext = new SequenceConstructPosContext(this, P_0, P_1);
		SequenceNode this_;
		while (true)
		{
			this_ = sequenceConstructPosContext.this_;
			sequenceConstructPosContext.lastposLeft = new BitSet(P_1.Count);
			if (!(this_.LeftChild is SequenceNode))
			{
				break;
			}
			stack.Push(sequenceConstructPosContext);
			sequenceConstructPosContext = new SequenceConstructPosContext((SequenceNode)this_.LeftChild, sequenceConstructPosContext.firstpos, sequenceConstructPosContext.lastposLeft);
		}
		this_.LeftChild.ConstructPos(sequenceConstructPosContext.firstpos, sequenceConstructPosContext.lastposLeft, P_2);
		while (true)
		{
			sequenceConstructPosContext.firstposRight = new BitSet(P_0.Count);
			this_.RightChild.ConstructPos(sequenceConstructPosContext.firstposRight, sequenceConstructPosContext.lastpos, P_2);
			if (this_.LeftChild.IsNullable && !this_.RightChild.IsRangeNode)
			{
				sequenceConstructPosContext.firstpos.Or(sequenceConstructPosContext.firstposRight);
			}
			if (this_.RightChild.IsNullable)
			{
				sequenceConstructPosContext.lastpos.Or(sequenceConstructPosContext.lastposLeft);
			}
			for (int num = sequenceConstructPosContext.lastposLeft.NextSet(-1); num != -1; num = sequenceConstructPosContext.lastposLeft.NextSet(num))
			{
				P_2[num].Or(sequenceConstructPosContext.firstposRight);
			}
			if (this_.RightChild.IsRangeNode)
			{
				((LeafRangeNode)this_.RightChild).NextIteration = sequenceConstructPosContext.firstpos.Clone();
			}
			if (stack.Count != 0)
			{
				sequenceConstructPosContext = stack.Pop();
				this_ = sequenceConstructPosContext.this_;
				continue;
			}
			break;
		}
	}

	public override void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
		ExpandTreeNoRecursive(P_0, P_1, P_2);
	}
}
