using System.Collections.Generic;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class ObjectParameterList : List<ObjectParameter>
{
	public ObjectParameter this[string name]
	{
		get
		{
			using (List<ObjectParameter>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ObjectParameter current = enumerator.Current;
					if (current.Name == name)
					{
						return current;
					}
				}
			}
			return null;
		}
	}

	public void ComSetItem(int index, ObjectParameter item)
	{
		base[index] = item;
	}

	public ObjectParameterList Clone()
	{
		ObjectParameterList objectParameterList = new ObjectParameterList();
		using List<ObjectParameter>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ObjectParameter current = enumerator.Current;
			objectParameterList.Add(current.z0eek());
		}
		return objectParameterList;
	}

	public ObjectParameter ComGetItem(int index)
	{
		return base[index];
	}
}
