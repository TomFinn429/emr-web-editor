using System.Collections;
using System.Reflection;

namespace System.Xml.Schema;

[DefaultMember("Item")]
public class XmlSchemaObjectCollection : CollectionBase
{
	private readonly XmlSchemaObject _parent;

	public int Add(XmlSchemaObject P_0)
	{
		return base.List.Add(P_0);
	}

	protected override void OnInsert(int P_0, object? P_1)
	{
		_parent?.OnAdd(this, P_1);
	}

	protected override void OnSet(int P_0, object? P_1, object? P_2)
	{
		if (_parent != null)
		{
			_parent.OnRemove(this, P_1);
			_parent.OnAdd(this, P_2);
		}
	}

	protected override void OnClear()
	{
		_parent?.OnClear(this);
	}

	protected override void OnRemove(int P_0, object? P_1)
	{
		_parent?.OnRemove(this, P_1);
	}
}
