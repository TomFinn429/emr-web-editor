using System.Collections;
using System.Collections.Generic;

namespace System.Xml;

public class XmlNamedNodeMap : IEnumerable
{
	internal struct SmallXmlNodeList
	{
		private sealed class SingleObjectEnumerator : IEnumerator
		{
			private readonly object _loneValue;

			private int _position = -1;

			public object Current
			{
				get
				{
					if (_position != 0)
					{
						throw new InvalidOperationException();
					}
					return _loneValue;
				}
			}

			public SingleObjectEnumerator(object P_0)
			{
				_loneValue = P_0;
			}

			public bool MoveNext()
			{
				if (_position < 0)
				{
					_position = 0;
					return true;
				}
				_position = 1;
				return false;
			}

			public void Reset()
			{
				_position = -1;
			}
		}

		private object _field;

		public int Count
		{
			get
			{
				if (_field == null)
				{
					return 0;
				}
				if (_field is List<object> list)
				{
					return list.Count;
				}
				return 1;
			}
		}

		public object this[int P_0]
		{
			get
			{
				if (_field == null)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				if (_field is List<object> list)
				{
					return list[P_0];
				}
				if (P_0 != 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return _field;
			}
		}

		public void Add(object P_0)
		{
			if (_field == null)
			{
				if (P_0 == null)
				{
					List<object> list = new List<object>();
					list.Add(null);
					_field = list;
				}
				else
				{
					_field = P_0;
				}
			}
			else if (_field is List<object> list2)
			{
				list2.Add(P_0);
			}
			else
			{
				List<object> list3 = new List<object>();
				list3.Add(_field);
				list3.Add(P_0);
				_field = list3;
			}
		}

		public void RemoveAt(int P_0)
		{
			if (_field == null)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_field is List<object> list)
			{
				list.RemoveAt(P_0);
				return;
			}
			if (P_0 != 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			_field = null;
		}

		public void Insert(int P_0, object P_1)
		{
			if (_field == null)
			{
				if (P_0 != 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				Add(P_1);
				return;
			}
			if (_field is List<object> list)
			{
				list.Insert(P_0, P_1);
				return;
			}
			switch (P_0)
			{
			case 0:
			{
				List<object> list2 = new List<object>();
				list2.Add(P_1);
				list2.Add(_field);
				_field = list2;
				break;
			}
			case 1:
			{
				List<object> list2 = new List<object>();
				list2.Add(_field);
				list2.Add(P_1);
				_field = list2;
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		public IEnumerator GetEnumerator()
		{
			if (_field == null)
			{
				return XmlDocument.EmptyEnumerator;
			}
			if (_field is List<object> list)
			{
				return list.GetEnumerator();
			}
			return new SingleObjectEnumerator(_field);
		}
	}

	internal XmlNode parent;

	internal SmallXmlNodeList nodes;

	public virtual int Count => nodes.Count;

	internal XmlNamedNodeMap(XmlNode P_0)
	{
		parent = P_0;
	}

	public virtual XmlNode? GetNamedItem(string P_0)
	{
		int num = FindNodeOffset(P_0);
		if (num >= 0)
		{
			return (XmlNode)nodes[num];
		}
		return null;
	}

	public virtual XmlNode? SetNamedItem(XmlNode? P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		int num = FindNodeOffset(P_0.LocalName, P_0.NamespaceURI);
		if (num == -1)
		{
			AddNode(P_0);
			return null;
		}
		return ReplaceNodeAt(num, P_0);
	}

	public virtual IEnumerator GetEnumerator()
	{
		return nodes.GetEnumerator();
	}

	internal int FindNodeOffset(string P_0)
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			XmlNode xmlNode = (XmlNode)nodes[i];
			if (P_0 == xmlNode.Name)
			{
				return i;
			}
		}
		return -1;
	}

	internal int FindNodeOffset(string P_0, string P_1)
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			XmlNode xmlNode = (XmlNode)nodes[i];
			if (xmlNode.LocalName == P_0 && xmlNode.NamespaceURI == P_1)
			{
				return i;
			}
		}
		return -1;
	}

	internal virtual XmlNode AddNode(XmlNode P_0)
	{
		XmlNode xmlNode = ((P_0.NodeType != XmlNodeType.Attribute) ? P_0.ParentNode : ((XmlAttribute)P_0).OwnerElement);
		string value = P_0.Value;
		XmlNodeChangedEventArgs eventArgs = parent.GetEventArgs(P_0, xmlNode, parent, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			parent.BeforeEvent(eventArgs);
		}
		nodes.Add(P_0);
		P_0.SetParent(parent);
		if (eventArgs != null)
		{
			parent.AfterEvent(eventArgs);
		}
		return P_0;
	}

	internal virtual XmlNode AddNodeForLoad(XmlNode P_0, XmlDocument P_1)
	{
		XmlNodeChangedEventArgs insertEventArgsForLoad = P_1.GetInsertEventArgsForLoad(P_0, parent);
		if (insertEventArgsForLoad != null)
		{
			P_1.BeforeEvent(insertEventArgsForLoad);
		}
		nodes.Add(P_0);
		P_0.SetParent(parent);
		if (insertEventArgsForLoad != null)
		{
			P_1.AfterEvent(insertEventArgsForLoad);
		}
		return P_0;
	}

	internal virtual XmlNode RemoveNodeAt(int P_0)
	{
		XmlNode xmlNode = (XmlNode)nodes[P_0];
		string value = xmlNode.Value;
		XmlNodeChangedEventArgs eventArgs = parent.GetEventArgs(xmlNode, parent, null, value, value, XmlNodeChangedAction.Remove);
		if (eventArgs != null)
		{
			parent.BeforeEvent(eventArgs);
		}
		nodes.RemoveAt(P_0);
		xmlNode.SetParent(null);
		if (eventArgs != null)
		{
			parent.AfterEvent(eventArgs);
		}
		return xmlNode;
	}

	internal XmlNode ReplaceNodeAt(int P_0, XmlNode P_1)
	{
		XmlNode result = RemoveNodeAt(P_0);
		InsertNodeAt(P_0, P_1);
		return result;
	}

	internal virtual XmlNode InsertNodeAt(int P_0, XmlNode P_1)
	{
		XmlNode xmlNode = ((P_1.NodeType != XmlNodeType.Attribute) ? P_1.ParentNode : ((XmlAttribute)P_1).OwnerElement);
		string value = P_1.Value;
		XmlNodeChangedEventArgs eventArgs = parent.GetEventArgs(P_1, xmlNode, parent, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			parent.BeforeEvent(eventArgs);
		}
		nodes.Insert(P_0, P_1);
		P_1.SetParent(parent);
		if (eventArgs != null)
		{
			parent.AfterEvent(eventArgs);
		}
		return P_1;
	}
}
