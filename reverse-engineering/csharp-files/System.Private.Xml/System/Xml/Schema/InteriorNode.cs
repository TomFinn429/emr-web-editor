using System.Collections.Generic;

namespace System.Xml.Schema;

internal abstract class InteriorNode : SyntaxTreeNode
{
	private SyntaxTreeNode _leftChild;

	private SyntaxTreeNode _rightChild;

	public SyntaxTreeNode LeftChild
	{
		get
		{
			return _leftChild;
		}
		set
		{
			_leftChild = leftChild;
		}
	}

	public SyntaxTreeNode RightChild
	{
		get
		{
			return _rightChild;
		}
		set
		{
			_rightChild = rightChild;
		}
	}

	protected void ExpandTreeNoRecursive(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
		Stack<InteriorNode> stack = new Stack<InteriorNode>();
		InteriorNode interiorNode = this;
		while (interiorNode._leftChild is ChoiceNode || interiorNode._leftChild is SequenceNode)
		{
			stack.Push(interiorNode);
			interiorNode = (InteriorNode)interiorNode._leftChild;
		}
		interiorNode._leftChild.ExpandTree(interiorNode, P_1, P_2);
		while (true)
		{
			interiorNode._rightChild?.ExpandTree(interiorNode, P_1, P_2);
			if (stack.Count != 0)
			{
				interiorNode = stack.Pop();
				continue;
			}
			break;
		}
	}

	public override void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
		_leftChild.ExpandTree(this, P_1, P_2);
		_rightChild?.ExpandTree(this, P_1, P_2);
	}
}
