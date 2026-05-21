using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Schema;

internal sealed class ParticleContentValidator : ContentValidator
{
	private SymbolsDictionary _symbols;

	private Positions _positions;

	private Stack<SyntaxTreeNode> _stack;

	private SyntaxTreeNode _contentNode;

	private bool _isPartial;

	private int _minMaxNodesCount;

	private readonly bool _enableUpaCheck;

	public ParticleContentValidator(XmlSchemaContentType P_0)
		: this(P_0, true)
	{
	}

	public ParticleContentValidator(XmlSchemaContentType P_0, bool P_1)
		: base(P_0)
	{
		_enableUpaCheck = P_1;
	}

	public void Start()
	{
		_symbols = new SymbolsDictionary();
		_positions = new Positions();
		_stack = new Stack<SyntaxTreeNode>();
	}

	public void OpenGroup()
	{
		_stack.Push(null);
	}

	public void CloseGroup()
	{
		SyntaxTreeNode syntaxTreeNode = _stack.Pop();
		if (syntaxTreeNode == null)
		{
			return;
		}
		if (_stack.Count == 0)
		{
			_contentNode = syntaxTreeNode;
			_isPartial = false;
			return;
		}
		InteriorNode interiorNode = (InteriorNode)_stack.Pop();
		if (interiorNode != null)
		{
			interiorNode.RightChild = syntaxTreeNode;
			syntaxTreeNode = interiorNode;
			_isPartial = true;
		}
		else
		{
			_isPartial = false;
		}
		_stack.Push(syntaxTreeNode);
	}

	public bool Exists(XmlQualifiedName P_0)
	{
		if (_symbols.Exists(P_0))
		{
			return true;
		}
		return false;
	}

	public void AddName(XmlQualifiedName P_0, object P_1)
	{
		AddLeafNode(new LeafNode(_positions.Add(_symbols.AddName(P_0, P_1), P_1)));
	}

	public void AddNamespaceList(NamespaceList P_0, object P_1)
	{
		_symbols.AddNamespaceList(P_0, P_1, false);
		AddLeafNode(new NamespaceListNode(P_0, P_1));
	}

	private void AddLeafNode(SyntaxTreeNode P_0)
	{
		if (_stack.Count > 0)
		{
			InteriorNode interiorNode = (InteriorNode)_stack.Pop();
			if (interiorNode != null)
			{
				interiorNode.RightChild = P_0;
				P_0 = interiorNode;
			}
		}
		_stack.Push(P_0);
		_isPartial = true;
	}

	public void AddChoice()
	{
		SyntaxTreeNode leftChild = _stack.Pop();
		InteriorNode interiorNode = new ChoiceNode();
		interiorNode.LeftChild = leftChild;
		_stack.Push(interiorNode);
	}

	public void AddSequence()
	{
		SyntaxTreeNode leftChild = _stack.Pop();
		InteriorNode interiorNode = new SequenceNode();
		interiorNode.LeftChild = leftChild;
		_stack.Push(interiorNode);
	}

	public void AddStar()
	{
		Closure(new StarNode());
	}

	public void AddPlus()
	{
		Closure(new PlusNode());
	}

	public void AddQMark()
	{
		Closure(new QmarkNode());
	}

	private void Closure(InteriorNode P_0)
	{
		if (_stack.Count > 0)
		{
			SyntaxTreeNode syntaxTreeNode = _stack.Pop();
			InteriorNode interiorNode = syntaxTreeNode as InteriorNode;
			if (_isPartial && interiorNode != null)
			{
				P_0.LeftChild = interiorNode.RightChild;
				interiorNode.RightChild = P_0;
			}
			else
			{
				P_0.LeftChild = syntaxTreeNode;
				syntaxTreeNode = P_0;
			}
			_stack.Push(syntaxTreeNode);
		}
		else if (_contentNode != null)
		{
			P_0.LeftChild = _contentNode;
			_contentNode = P_0;
		}
	}

	public ContentValidator Finish(bool P_0)
	{
		if (_contentNode == null)
		{
			if (base.ContentType == XmlSchemaContentType.Mixed)
			{
				if (!base.IsOpen)
				{
					return ContentValidator.TextOnly;
				}
				return ContentValidator.Any;
			}
			return ContentValidator.Empty;
		}
		InteriorNode interiorNode = new SequenceNode();
		interiorNode.LeftChild = _contentNode;
		LeafNode leafNode = (LeafNode)(interiorNode.RightChild = new LeafNode(_positions.Add(_symbols.AddName(XmlQualifiedName.Empty, null), null)));
		_contentNode.ExpandTree(interiorNode, _symbols, _positions);
		int count = _positions.Count;
		BitSet bitSet = new BitSet(count);
		BitSet bitSet2 = new BitSet(count);
		BitSet[] array = new BitSet[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = new BitSet(count);
		}
		interiorNode.ConstructPos(bitSet, bitSet2, array);
		if (_minMaxNodesCount > 0)
		{
			BitSet bitSet3;
			BitSet[] array2 = CalculateTotalFollowposForRangeNodes(bitSet, array, out bitSet3);
			if (_enableUpaCheck)
			{
				CheckCMUPAWithLeafRangeNodes(GetApplicableMinMaxFollowPos(bitSet, bitSet3, array2));
				for (int j = 0; j < count; j++)
				{
					CheckCMUPAWithLeafRangeNodes(GetApplicableMinMaxFollowPos(array[j], bitSet3, array2));
				}
			}
			return new RangeContentValidator(bitSet, array, _symbols, _positions, leafNode.Pos, base.ContentType, interiorNode.LeftChild.IsNullable, bitSet3, _minMaxNodesCount);
		}
		int[][] array3 = null;
		if (!_symbols.IsUpaEnforced)
		{
			if (_enableUpaCheck)
			{
				CheckUniqueParticleAttribution(bitSet, array);
			}
		}
		else if (P_0)
		{
			array3 = BuildTransitionTable(bitSet, array, leafNode.Pos);
		}
		if (array3 != null)
		{
			return new DfaContentValidator(array3, _symbols, base.ContentType, base.IsOpen, interiorNode.LeftChild.IsNullable);
		}
		return new NfaContentValidator(bitSet, array, _symbols, _positions, leafNode.Pos, base.ContentType, base.IsOpen, interiorNode.LeftChild.IsNullable);
	}

	private BitSet[] CalculateTotalFollowposForRangeNodes(BitSet P_0, BitSet[] P_1, out BitSet P_2)
	{
		int count = _positions.Count;
		P_2 = new BitSet(count);
		BitSet[] array = new BitSet[_minMaxNodesCount];
		int num = 0;
		for (int num2 = count - 1; num2 >= 0; num2--)
		{
			Position position = _positions[num2];
			if (position.symbol == -2)
			{
				_ = position.particle;
				LeafRangeNode leafRangeNode = null;
				BitSet bitSet = new BitSet(count);
				bitSet.Clear();
				bitSet.Or(P_1[num2]);
				if (leafRangeNode.Min != leafRangeNode.Max)
				{
					bitSet.Or(leafRangeNode.NextIteration);
				}
				for (int num3 = bitSet.NextSet(-1); num3 != -1; num3 = bitSet.NextSet(num3))
				{
					if (num3 > num2)
					{
						Position position2 = _positions[num3];
						if (position2.symbol == -2)
						{
							_ = position2.particle;
							LeafRangeNode leafRangeNode2 = null;
							bitSet.Or(array[leafRangeNode2.Pos]);
						}
					}
				}
				array[num] = bitSet;
				leafRangeNode.Pos = num++;
				P_2.Set(num2);
			}
		}
		return array;
	}

	private void CheckCMUPAWithLeafRangeNodes(BitSet P_0)
	{
		object[] array = new object[_symbols.Count];
		for (int num = P_0.NextSet(-1); num != -1; num = P_0.NextSet(num))
		{
			Position position = _positions[num];
			int symbol = position.symbol;
			if (symbol >= 0)
			{
				if (array[symbol] != null)
				{
					throw new UpaException(array[symbol], position.particle);
				}
				array[symbol] = position.particle;
			}
		}
	}

	private BitSet GetApplicableMinMaxFollowPos(BitSet P_0, BitSet P_1, BitSet[] P_2)
	{
		if (P_0.Intersects(P_1))
		{
			BitSet bitSet = new BitSet(_positions.Count);
			bitSet.Or(P_0);
			bitSet.And(P_1);
			P_0 = P_0.Clone();
			for (int num = bitSet.NextSet(-1); num != -1; num = bitSet.NextSet(num))
			{
				_ = _positions[num].particle;
				LeafRangeNode leafRangeNode = null;
				P_0.Or(P_2[leafRangeNode.Pos]);
			}
		}
		return P_0;
	}

	private void CheckUniqueParticleAttribution(BitSet P_0, BitSet[] P_1)
	{
		CheckUniqueParticleAttribution(P_0);
		for (int i = 0; i < _positions.Count; i++)
		{
			CheckUniqueParticleAttribution(P_1[i]);
		}
	}

	private void CheckUniqueParticleAttribution(BitSet P_0)
	{
		object[] array = new object[_symbols.Count];
		for (int num = P_0.NextSet(-1); num != -1; num = P_0.NextSet(num))
		{
			int symbol = _positions[num].symbol;
			if (array[symbol] == null)
			{
				array[symbol] = _positions[num].particle;
			}
			else if (array[symbol] != _positions[num].particle)
			{
				throw new UpaException(array[symbol], _positions[num].particle);
			}
		}
	}

	private int[][] BuildTransitionTable(BitSet P_0, BitSet[] P_1, int P_2)
	{
		int count = _positions.Count;
		int num = 8192 / count;
		int count2 = _symbols.Count;
		ArrayList arrayList = new ArrayList();
		Dictionary<BitSet, int> dictionary = new Dictionary<BitSet, int>();
		dictionary.Add(new BitSet(count), -1);
		Queue<BitSet> queue = new Queue<BitSet>();
		int num2 = 0;
		queue.Enqueue(P_0);
		dictionary.Add(P_0, 0);
		arrayList.Add(new int[count2 + 1]);
		while (queue.Count > 0)
		{
			BitSet bitSet = queue.Dequeue();
			int[] array = (int[])arrayList[num2];
			if (bitSet[P_2])
			{
				array[count2] = 1;
			}
			for (int i = 0; i < count2; i++)
			{
				BitSet bitSet2 = new BitSet(count);
				for (int num3 = bitSet.NextSet(-1); num3 != -1; num3 = bitSet.NextSet(num3))
				{
					if (i == _positions[num3].symbol)
					{
						bitSet2.Or(P_1[num3]);
					}
				}
				if (dictionary.TryGetValue(bitSet2, out var num4))
				{
					array[i] = num4;
					continue;
				}
				int num5 = dictionary.Count - 1;
				if (num5 >= num)
				{
					return null;
				}
				queue.Enqueue(bitSet2);
				dictionary.Add(bitSet2, num5);
				arrayList.Add(new int[count2 + 1]);
				array[i] = num5;
			}
			num2++;
		}
		return (int[][])arrayList.ToArray(typeof(int[]));
	}
}
