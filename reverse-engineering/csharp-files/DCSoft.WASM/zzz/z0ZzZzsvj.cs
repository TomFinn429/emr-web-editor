using System;
using System.Collections;
using System.ComponentModel;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace zzz;

public sealed class z0ZzZzsvj : ICloneable
{
	[NonSerialized]
	private z0ZzZzdvj z0tek;

	private string z0yek;

	private string z0uek;

	private z0ZzZzdvj z0iek;

	private bool z0oek = true;

	private string z0pek;

	private string z0mek;

	[z0ZzZzrqh("Item", typeof(ListItem))]
	public z0ZzZzdvj Items
	{
		get
		{
			if (z0iek != null)
			{
				z0iek.z0eek(p0: false);
			}
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(null)]
	public string Name
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (Items != null && Items.Count > 0)
			{
				return false;
			}
			if (z0eek() != null && z0eek().Count > 0)
			{
				return false;
			}
			if (string.IsNullOrEmpty(z0mek))
			{
				return string.IsNullOrEmpty(z0pek);
			}
			return false;
		}
	}

	[DefaultValue(null)]
	public string SourceName
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(true)]
	public bool BufferItems
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public string DisplayPath
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public string ValuePath
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	private static string z0eek(object p0, z0ZzZzsvj p1, int p2, z0ZzZzyvj p3)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return null;
		}
		string text = null;
		switch (p2)
		{
		case 0:
			text = p1.DisplayPath;
			break;
		case 1:
			text = p1.ValuePath;
			break;
		}
		if (p0 is ListItem)
		{
			ListItem listItem = (ListItem)p0;
			switch (p2)
			{
			case 0:
				if (string.IsNullOrEmpty(p1.DisplayPath))
				{
					return listItem.Text;
				}
				break;
			case 1:
				if (string.IsNullOrEmpty(p1.ValuePath))
				{
					return listItem.Value;
				}
				break;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			object obj = null;
			if (p0 is IList)
			{
				IList list = (IList)p0;
				obj = ((list.Count <= p2) ? list[0] : list[p2]);
				return Convert.ToString(obj);
			}
			obj = p0;
			if (obj == null || DBNull.Value.Equals(obj))
			{
				return null;
			}
			return Convert.ToString(obj);
		}
		z0ZzZzrvj z0ZzZzrvj2 = z0ZzZzrvj.z0rek(p0.GetType(), (p2 == 0) ? p1.DisplayPath : p1.ValuePath, p2: false);
		if (z0ZzZzrvj2 == null)
		{
			return null;
		}
		object obj2 = p0;
		obj2 = z0ZzZzyvj.z0eek(z0ZzZzrvj2, p0, null, p3: false, p3);
		if (obj2 == null || DBNull.Value.Equals(obj2))
		{
			return null;
		}
		return Convert.ToString(obj2);
	}

	public static z0ZzZzdvj z0eek(z0ZzZzdbj p0, XTextElement p1, z0ZzZzlfh p2, z0ZzZzsvj p3, z0ZzZzgvj p4, object p5, string p6, bool p7, string p8)
	{
		bool flag = true;
		if (p1 is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1;
			if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0uek())
			{
				flag = false;
			}
		}
		if (flag && p3 != null && p3.BufferItems && p3.z0eek() != null)
		{
			return p3.z0eek();
		}
		if (flag && p3 != null && p3.Items != null && p3.Items.Count > 0)
		{
			return p3.Items;
		}
		if (p5 == null)
		{
			if (p0 != null && p1 != null)
			{
				QueryListItemsEventArgs e = new QueryListItemsEventArgs(p0, p1.z0jr(), p1);
				e.RaiseEvent = p7;
				e.SpellCode = p6;
				e.SpecifyValue = p8;
				if (p3 != null)
				{
					e.ListSourceName = p3.SourceName;
				}
				if (e.Handled || (e.Result != null && e.Result.Count > 0))
				{
					return e.Result;
				}
			}
			if (p5 == null && p4 != null)
			{
				ListSourceEventArgs p9 = new ListSourceEventArgs(p2, p2.z0tek(), p3);
				p5 = p4.z0tek(p9);
			}
		}
		if (p5 == null)
		{
			return null;
		}
		z0ZzZzdvj z0ZzZzdvj2 = null;
		z0ZzZzdvj2 = new z0ZzZzdvj();
		IEnumerable enumerable = null;
		if (p5 is IEnumerable)
		{
			enumerable = (IEnumerable)p5;
		}
		else if (p5 is z0ZzZzoah)
		{
			enumerable = ((z0ZzZzoah)p5).z0tek();
		}
		if (enumerable != null)
		{
			z0ZzZzyvj bindingProvider = (z0ZzZzyvj)p2.z0tek().z0eek(typeof(z0ZzZzyvj));
			foreach (object item in enumerable)
			{
				if (item is ListItem)
				{
					z0ZzZzdvj2.Add((ListItem)item);
					continue;
				}
				ListItem listItem = new ListItem();
				if (p4 == null)
				{
					listItem.Text = StdGetDisplayText(item, p3, bindingProvider);
					listItem.Value = StdGetValue(item, p3, bindingProvider);
					listItem.Tag = StdGetTag(item, p3, bindingProvider);
				}
				else
				{
					ListSourceEventArgs e2 = new ListSourceEventArgs(p2, p2.z0tek(), p3);
					e2.Value = item;
					listItem.Text = p4.z0rek(e2);
					listItem.Value = p4.z0yek(e2);
					listItem.Tag = p4.z0eek(e2);
				}
				z0ZzZzdvj2.Add(listItem);
			}
		}
		if (p3 != null && p3.BufferItems)
		{
			p3.z0eek(z0ZzZzdvj2);
		}
		if (p1.z0bu() != null && p1.z0bu().DebugMode)
		{
			z0ZzZzqok.z0rek.z0sh(string.Format(z0ZzZziok.z0eik(), (p4 == null) ? "NULL" : p4.GetType().Name, (p3 == null) ? string.Empty : p3.SourceName, (z0ZzZzdvj2 == null) ? "NULL" : z0ZzZzdvj2.Count.ToString()));
		}
		return z0ZzZzdvj2;
	}

	public static string StdGetValue(object Value, z0ZzZzsvj info, z0ZzZzyvj bindingProvider)
	{
		return z0eek(Value, info, 1, bindingProvider);
	}

	public z0ZzZzsvj Clone()
	{
		return (z0ZzZzsvj)((ICloneable)this).Clone();
	}

	public static string StdGetDisplayText(object Value, z0ZzZzsvj info, z0ZzZzyvj bindingProvider)
	{
		return z0eek(Value, info, 0, bindingProvider);
	}

	public z0ZzZzdvj z0eek()
	{
		return z0tek;
	}

	public void z0eek(z0ZzZzdvj p0)
	{
		z0tek = p0;
	}

	private object z0rek()
	{
		z0ZzZzsvj z0ZzZzsvj2 = (z0ZzZzsvj)MemberwiseClone();
		if (z0iek != null)
		{
			z0ZzZzsvj2.z0iek = new z0ZzZzdvj();
			foreach (ListItem item in z0iek.z0xrk())
			{
				z0ZzZzsvj2.z0iek.Add(item.z0tek());
			}
		}
		return z0ZzZzsvj2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public override string ToString()
	{
		if (Items != null && Items.Count > 0)
		{
			return Items.Count + " items";
		}
		return SourceName;
	}

	public static string StdGetTag(object Value, z0ZzZzsvj info, z0ZzZzyvj bindingProvider)
	{
		if (Value is ListItem)
		{
			return ((ListItem)Value).Tag;
		}
		return null;
	}
}
