using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SortedSet<T> : ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, ISerializable
{
	internal sealed class Node
	{
		public T Item
		{
			[CompilerGenerated]
			get
			{
				return _003CItem_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CItem_003Ek__BackingField = val;
			}
		}

		public Node Left
		{
			[CompilerGenerated]
			get
			{
				return _003CLeft_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CLeft_003Ek__BackingField = node;
			}
		}

		public Node Right
		{
			[CompilerGenerated]
			get
			{
				return _003CRight_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CRight_003Ek__BackingField = node;
			}
		}

		public NodeColor Color
		{
			[CompilerGenerated]
			get
			{
				return _003CColor_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CColor_003Ek__BackingField = nodeColor;
			}
		}

		public bool IsBlack => Color == NodeColor.Black;

		public bool IsRed => Color == NodeColor.Red;

		public bool Is2Node
		{
			get
			{
				if (IsBlack && IsNullOrBlack(Left))
				{
					return IsNullOrBlack(Right);
				}
				return false;
			}
		}

		public bool Is4Node
		{
			get
			{
				if (IsNonNullRed(Left))
				{
					return IsNonNullRed(Right);
				}
				return false;
			}
		}

		public Node(T P_0, NodeColor P_1)
		{
			Item = P_0;
			Color = P_1;
		}

		public static bool IsNonNullRed(Node P_0)
		{
			return P_0?.IsRed ?? false;
		}

		public static bool IsNullOrBlack(Node P_0)
		{
			return P_0?.IsBlack ?? true;
		}

		public void ColorBlack()
		{
			Color = NodeColor.Black;
		}

		public void ColorRed()
		{
			Color = NodeColor.Red;
		}

		public TreeRotation GetRotation(Node P_0, Node P_1)
		{
			bool flag = Left == P_0;
			if (!IsNonNullRed(P_1.Left))
			{
				if (!flag)
				{
					return TreeRotation.LeftRight;
				}
				return TreeRotation.Left;
			}
			if (!flag)
			{
				return TreeRotation.Right;
			}
			return TreeRotation.RightLeft;
		}

		public Node GetSibling(Node P_0)
		{
			if (P_0 != Left)
			{
				return Left;
			}
			return Right;
		}

		public void Split4Node()
		{
			ColorRed();
			Left.ColorBlack();
			Right.ColorBlack();
		}

		public Node Rotate(TreeRotation P_0)
		{
			switch (P_0)
			{
			case TreeRotation.Right:
			{
				Node right = Left.Left;
				right.ColorBlack();
				return RotateRight();
			}
			case TreeRotation.Left:
			{
				Node right = Right.Right;
				right.ColorBlack();
				return RotateLeft();
			}
			case TreeRotation.RightLeft:
				return RotateRightLeft();
			case TreeRotation.LeftRight:
				return RotateLeftRight();
			default:
				return null;
			}
		}

		public Node RotateLeft()
		{
			Node right = Right;
			Right = right.Left;
			right.Left = this;
			return right;
		}

		public Node RotateLeftRight()
		{
			Node left = Left;
			Node right = left.Right;
			Left = right.Right;
			right.Right = this;
			left.Right = right.Left;
			right.Left = left;
			return right;
		}

		public Node RotateRight()
		{
			Node left = Left;
			Left = left.Right;
			left.Right = this;
			return left;
		}

		public Node RotateRightLeft()
		{
			Node right = Right;
			Node left = right.Left;
			Right = left.Left;
			left.Left = this;
			right.Left = left.Right;
			left.Right = right;
			return left;
		}

		public void Merge2Nodes()
		{
			ColorBlack();
			Left.ColorRed();
			Right.ColorRed();
		}

		public void ReplaceChild(Node P_0, Node P_1)
		{
			if (Left == P_0)
			{
				Left = P_1;
			}
			else
			{
				Right = P_1;
			}
		}
	}

	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable, ISerializable
	{
		private readonly SortedSet<T> _tree;

		private readonly int _version;

		private readonly Stack<Node> _stack;

		private Node _current;

		private readonly bool _reverse;

		public T Current
		{
			get
			{
				if (_current != null)
				{
					return _current.Item;
				}
				return default(T);
			}
		}

		object? IEnumerator.Current
		{
			get
			{
				if (_current == null)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return _current.Item;
			}
		}

		internal bool NotStartedOrEnded => _current == null;

		internal Enumerator(SortedSet<T> P_0)
			: this(P_0, false)
		{
		}

		internal Enumerator(SortedSet<T> P_0, bool P_1)
		{
			_tree = P_0;
			P_0.VersionCheck();
			_version = P_0.version;
			_stack = new Stack<Node>(2 * SortedSet<T>.Log2(P_0.TotalCount() + 1));
			_current = null;
			_reverse = P_1;
			Initialize();
		}

		void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
		{
			throw new PlatformNotSupportedException();
		}

		private void Initialize()
		{
			_current = null;
			Node node = _tree.root;
			while (node != null)
			{
				Node node2 = (_reverse ? node.Right : node.Left);
				Node node3 = (_reverse ? node.Left : node.Right);
				if (_tree.IsWithinRange(node.Item))
				{
					_stack.Push(node);
					node = node2;
				}
				else
				{
					node = ((node2 != null && _tree.IsWithinRange(node2.Item)) ? node2 : node3);
				}
			}
		}

		public bool MoveNext()
		{
			_tree.VersionCheck();
			if (_version != _tree.version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			if (_stack.Count == 0)
			{
				_current = null;
				return false;
			}
			_current = _stack.Pop();
			Node node = (_reverse ? _current.Left : _current.Right);
			while (node != null)
			{
				Node node2 = (_reverse ? node.Right : node.Left);
				Node node3 = (_reverse ? node.Left : node.Right);
				if (_tree.IsWithinRange(node.Item))
				{
					_stack.Push(node);
					node = node2;
				}
				else
				{
					node = ((node3 != null && _tree.IsWithinRange(node3.Item)) ? node3 : node2);
				}
			}
			return true;
		}

		public void Dispose()
		{
		}

		internal void Reset()
		{
			if (_version != _tree.version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			_stack.Clear();
			Initialize();
		}

		void IEnumerator.Reset()
		{
			Reset();
		}
	}

	private Node root;

	private IComparer<T> comparer;

	private int count;

	private int version;

	public int Count
	{
		get
		{
			VersionCheck(true);
			return count;
		}
	}

	bool ICollection<T>.IsReadOnly => false;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	public SortedSet(IComparer<T>? P_0)
	{
		comparer = P_0 ?? Comparer<T>.Default;
	}

	internal virtual bool InOrderTreeWalk(TreeWalkPredicate<T> P_0)
	{
		if (root == null)
		{
			return true;
		}
		Stack<Node> stack = new Stack<Node>(2 * Log2(Count + 1));
		for (Node left = root; left != null; left = left.Left)
		{
			stack.Push(left);
		}
		while (stack.Count != 0)
		{
			Node left = stack.Pop();
			if (!P_0(left))
			{
				return false;
			}
			for (Node node = left.Right; node != null; node = node.Left)
			{
				stack.Push(node);
			}
		}
		return true;
	}

	internal virtual void VersionCheck(bool P_0 = false)
	{
	}

	internal virtual int TotalCount()
	{
		return Count;
	}

	internal virtual bool IsWithinRange(T P_0)
	{
		return true;
	}

	public bool Add(T P_0)
	{
		return AddIfNotPresent(P_0);
	}

	void ICollection<T>.Add(T P_0)
	{
		Add(P_0);
	}

	internal virtual bool AddIfNotPresent(T P_0)
	{
		if (root == null)
		{
			root = new Node(P_0, NodeColor.Black);
			count = 1;
			version++;
			return true;
		}
		Node node = root;
		Node node2 = null;
		Node node3 = null;
		Node node4 = null;
		version++;
		int num = 0;
		while (node != null)
		{
			num = comparer.Compare(P_0, node.Item);
			if (num == 0)
			{
				root.ColorBlack();
				return false;
			}
			if (node.Is4Node)
			{
				node.Split4Node();
				if (Node.IsNonNullRed(node2))
				{
					InsertionBalance(node, ref node2, node3, node4);
				}
			}
			node4 = node3;
			node3 = node2;
			node2 = node;
			node = ((num < 0) ? node.Left : node.Right);
		}
		Node node5 = new Node(P_0, NodeColor.Red);
		if (num > 0)
		{
			node2.Right = node5;
		}
		else
		{
			node2.Left = node5;
		}
		if (node2.IsRed)
		{
			InsertionBalance(node5, ref node2, node3, node4);
		}
		root.ColorBlack();
		count++;
		return true;
	}

	public bool Remove(T P_0)
	{
		return DoRemove(P_0);
	}

	internal virtual bool DoRemove(T P_0)
	{
		if (root == null)
		{
			return false;
		}
		version++;
		Node node = root;
		Node node2 = null;
		Node node3 = null;
		Node node4 = null;
		Node node5 = null;
		bool flag = false;
		while (node != null)
		{
			if (node.Is2Node)
			{
				if (node2 == null)
				{
					node.ColorRed();
				}
				else
				{
					Node sibling = node2.GetSibling(node);
					if (sibling.IsRed)
					{
						if (node2.Right == sibling)
						{
							node2.RotateLeft();
						}
						else
						{
							node2.RotateRight();
						}
						node2.ColorRed();
						sibling.ColorBlack();
						ReplaceChildOrRoot(node3, node2, sibling);
						node3 = sibling;
						if (node2 == node4)
						{
							node5 = sibling;
						}
						sibling = node2.GetSibling(node);
					}
					if (sibling.Is2Node)
					{
						node2.Merge2Nodes();
					}
					else
					{
						Node node6 = node2.Rotate(node2.GetRotation(node, sibling));
						node6.Color = node2.Color;
						node2.ColorBlack();
						node.ColorRed();
						ReplaceChildOrRoot(node3, node2, node6);
						if (node2 == node4)
						{
							node5 = node6;
						}
					}
				}
			}
			int num = (flag ? (-1) : comparer.Compare(P_0, node.Item));
			if (num == 0)
			{
				flag = true;
				node4 = node;
				node5 = node2;
			}
			node3 = node2;
			node2 = node;
			node = ((num < 0) ? node.Left : node.Right);
		}
		if (node4 != null)
		{
			ReplaceNode(node4, node5, node2, node3);
			count--;
		}
		root?.ColorBlack();
		return flag;
	}

	public virtual void Clear()
	{
		root = null;
		count = 0;
		version++;
	}

	public virtual bool Contains(T P_0)
	{
		return FindNode(P_0) != null;
	}

	public void CopyTo(T[] P_0, int P_1)
	{
		CopyTo(P_0, P_1, Count);
	}

	public void CopyTo(T[] P_0, int P_1, int P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("count", "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_2 > P_0.Length - P_1)
		{
			throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
		}
		P_2 += P_1;
		InOrderTreeWalk(delegate(Node node)
		{
			if (P_1 >= P_2)
			{
				return false;
			}
			P_0[P_1++] = node.Item;
			return true;
		});
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_0.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
		}
		if (P_0.GetLowerBound(0) != 0)
		{
			throw new ArgumentException("Arg_NonZeroLowerBound", "array");
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_0.Length - P_1 < Count)
		{
			throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
		}
		if (P_0 is T[] array)
		{
			CopyTo(array, P_1);
			return;
		}
		object[] objects = P_0 as object[];
		if (objects == null)
		{
			throw new ArgumentException("Argument_InvalidArrayType", "array");
		}
		try
		{
			InOrderTreeWalk(delegate(Node node)
			{
				objects[P_1++] = node.Item;
				return true;
			});
		}
		catch (ArrayTypeMismatchException)
		{
			throw new ArgumentException("Argument_InvalidArrayType", "array");
		}
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private void InsertionBalance(Node P_0, ref Node P_1, Node P_2, Node P_3)
	{
		bool flag = P_2.Right == P_1;
		bool flag2 = P_1.Right == P_0;
		Node node;
		if (flag == flag2)
		{
			node = (flag2 ? P_2.RotateLeft() : P_2.RotateRight());
		}
		else
		{
			node = (flag2 ? P_2.RotateLeftRight() : P_2.RotateRightLeft());
			P_1 = P_3;
		}
		P_2.ColorRed();
		node.ColorBlack();
		ReplaceChildOrRoot(P_3, P_2, node);
	}

	private void ReplaceChildOrRoot(Node P_0, Node P_1, Node P_2)
	{
		if (P_0 != null)
		{
			P_0.ReplaceChild(P_1, P_2);
		}
		else
		{
			root = P_2;
		}
	}

	private void ReplaceNode(Node P_0, Node P_1, Node P_2, Node P_3)
	{
		if (P_2 == P_0)
		{
			P_2 = P_0.Left;
		}
		else
		{
			P_2.Right?.ColorBlack();
			if (P_3 != P_0)
			{
				P_3.Left = P_2.Right;
				P_2.Right = P_0.Right;
			}
			P_2.Left = P_0.Left;
		}
		if (P_2 != null)
		{
			P_2.Color = P_0.Color;
		}
		ReplaceChildOrRoot(P_1, P_0, P_2);
	}

	internal virtual Node FindNode(T P_0)
	{
		Node node = root;
		while (node != null)
		{
			int num = comparer.Compare(P_0, node.Item);
			if (num == 0)
			{
				return node;
			}
			node = ((num < 0) ? node.Left : node.Right);
		}
		return null;
	}

	internal void UpdateVersion()
	{
		version++;
	}

	void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		GetObjectData(P_0, P_1);
	}

	protected virtual void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "info");
		P_0.AddValue("Count", count);
		P_0.AddValue("Comparer", comparer, typeof(IComparer<T>));
		P_0.AddValue("Version", version);
		if (root != null)
		{
			T[] array = new T[Count];
			CopyTo(array, 0);
			P_0.AddValue("Items", array, typeof(T[]));
		}
	}

	private static int Log2(int P_0)
	{
		return BitOperations.Log2((uint)P_0);
	}
}
