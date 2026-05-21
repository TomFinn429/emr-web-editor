using System;
using System.Collections.Generic;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class PropertyExpressionInfoList : List<PropertyExpressionInfo>, z0ZzZzcuk
{
	[NonSerialized]
	private XTextElement _Owner;

	internal XTextElement Owner
	{
		get
		{
			return _Owner;
		}
		set
		{
			_Owner = value;
		}
	}

	public PropertyExpressionInfo ComGetItem(int index)
	{
		return base[index];
	}

	public void ComSetItem(int index, PropertyExpressionInfo item)
	{
		base[index] = item;
	}

	public PropertyExpressionInfoList Clone()
	{
		PropertyExpressionInfoList propertyExpressionInfoList = new PropertyExpressionInfoList();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			PropertyExpressionInfo current = enumerator.Current;
			propertyExpressionInfoList.Add(current.z0eek());
		}
		return propertyExpressionInfoList;
	}

	public string DCWriteString()
	{
		z0ZzZzsyk z0ZzZzsyk = new z0ZzZzsyk();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PropertyExpressionInfo current = enumerator.Current;
				z0ZzZzsyk.z0eek(current.Name, current.Expression);
			}
		}
		return z0ZzZzsyk.ToString();
	}

	public PropertyExpressionInfoList CloneNotDeeply()
	{
		PropertyExpressionInfoList propertyExpressionInfoList = new PropertyExpressionInfoList();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			PropertyExpressionInfo current = enumerator.Current;
			propertyExpressionInfoList.Add(current);
		}
		return propertyExpressionInfoList;
	}

	public PropertyExpressionInfoList()
	{
	}

	public string GetValue(string memberName)
	{
		return GetItem(memberName)?.Expression;
	}

	public PropertyExpressionInfo GetItem(string memberName)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PropertyExpressionInfo current = enumerator.Current;
				if (string.Compare(current.Name, memberName, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public override string ToString()
	{
		return DCWriteString();
	}

	public void SetValue(string memberName, string expression)
	{
		SetValueExt(memberName, expression, allowChainReaction: true);
	}

	public void DCReadString(string text)
	{
		foreach (z0ZzZzqyk item in new z0ZzZzsyk(text))
		{
			SetValue(item.z0eek(), item.z0rek());
		}
	}

	public void SetValueExt(string memberName, string expression, bool allowChainReaction)
	{
		if (string.IsNullOrEmpty(memberName))
		{
			return;
		}
		if (expression != null)
		{
			expression = expression.Trim();
		}
		PropertyExpressionInfo propertyExpressionInfo = GetItem(memberName);
		if (string.IsNullOrEmpty(expression))
		{
			if (propertyExpressionInfo != null)
			{
				Remove(propertyExpressionInfo);
			}
		}
		else
		{
			if (propertyExpressionInfo == null)
			{
				propertyExpressionInfo = new PropertyExpressionInfo();
				propertyExpressionInfo.Name = memberName;
				Add(propertyExpressionInfo);
			}
			propertyExpressionInfo.Expression = expression;
			propertyExpressionInfo.AllowChainReaction = allowChainReaction;
		}
		if (_Owner != null)
		{
			XTextElement owner = Owner;
			owner.z0jr()?.z0rik()?.z0mw_jiejie20260327142557(owner);
		}
	}

	internal PropertyExpressionInfoList(XTextElement owner)
	{
		_Owner = owner;
	}
}
