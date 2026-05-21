using System.Collections;

namespace System.Xml.Schema;

internal sealed class NamespaceListNode : SyntaxTreeNode
{
	private NamespaceList namespaceList;

	private object particle;

	public override bool IsNullable
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public NamespaceListNode(NamespaceList P_0, object P_1)
	{
		namespaceList = P_0;
		particle = P_1;
	}

	public ICollection GetResolvedSymbols(SymbolsDictionary P_0)
	{
		return P_0.GetNamespaceListSymbols(namespaceList);
	}

	public override void ExpandTree(InteriorNode P_0, SymbolsDictionary P_1, Positions P_2)
	{
		SyntaxTreeNode syntaxTreeNode = null;
		foreach (int resolvedSymbol in GetResolvedSymbols(P_1))
		{
			if (P_1.GetParticle(resolvedSymbol) != particle)
			{
				P_1.IsUpaEnforced = false;
			}
			LeafNode leafNode = new LeafNode(P_2.Add(resolvedSymbol, particle));
			if (syntaxTreeNode == null)
			{
				syntaxTreeNode = leafNode;
				continue;
			}
			InteriorNode interiorNode = new ChoiceNode();
			interiorNode.LeftChild = syntaxTreeNode;
			interiorNode.RightChild = leafNode;
			syntaxTreeNode = interiorNode;
		}
		if (P_0.LeftChild == this)
		{
			P_0.LeftChild = syntaxTreeNode;
		}
		else
		{
			P_0.RightChild = syntaxTreeNode;
		}
	}

	public override void ConstructPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		throw new InvalidOperationException();
	}
}
