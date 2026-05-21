using System;
using System.Collections.Generic;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentContentStyleContainer : z0ZzZzxok
{
	private class z0gmk : IEqualityComparer<DocumentContentStyle>
	{
		public int GetHashCode(DocumentContentStyle obj)
		{
			return ((z0ZzZzvik)obj).z0uek();
		}

		public bool Equals(DocumentContentStyle x, DocumentContentStyle y)
		{
			if (x == y)
			{
				return true;
			}
			return x.z0tek(y);
		}
	}

	internal bool z0pek = true;

	[NonSerialized]
	private XTextDocument z0mek;

	[NonSerialized]
	private Dictionary<int, int> z0nek;

	private Dictionary<DocumentContentStyle, int> z0bek;

	internal bool z0vek = true;

	[z0ZzZzrqh("Style", typeof(DocumentContentStyle))]
	public override z0ZzZzzok Styles
	{
		get
		{
			return base.Styles;
		}
		set
		{
			base.Styles = value;
		}
	}

	[z0ZzZzyqh("Default", typeof(DocumentContentStyle))]
	public override z0ZzZzcok Default
	{
		get
		{
			return base.z0tek;
		}
		set
		{
			if (value != null && value.GetType().Equals(typeof(z0ZzZzcok)))
			{
				DocumentContentStyle documentContentStyle = new DocumentContentStyle();
				z0ZzZzvik.z0rek(value, documentContentStyle);
				base.Default = documentContentStyle;
			}
			else
			{
				base.Default = value;
			}
		}
	}

	internal new bool[] z0eek()
	{
		z0ZzZzzok styles = Styles;
		bool[] array = new bool[styles.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = false;
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[i];
			if (documentContentStyle.z0xek != null)
			{
				if (documentContentStyle.z0xek.z0jyk >= 0)
				{
					array[i] = true;
				}
			}
			else if (documentContentStyle.DeleterIndex >= 0)
			{
				array[i] = true;
			}
		}
		return array;
	}

	internal new List<int> z0rek()
	{
		List<int> list = new List<int>();
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = Styles.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
				if (documentContentStyle.HasTitleLevel)
				{
					list.Add(Styles.IndexOf(documentContentStyle));
				}
			}
		}
		if (list.Count > 0)
		{
			return list;
		}
		return null;
	}

	internal new Dictionary<int, int> z0tek()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int count = Styles.Count;
		for (int i = 0; i < count; i++)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)Styles[i];
			if (documentContentStyle.z0xek != null)
			{
				if (documentContentStyle.z0xek.z0jyk >= 0)
				{
					dictionary.Add(i, 0);
				}
			}
			else if (documentContentStyle.DeleterIndex >= 0)
			{
				dictionary.Add(i, 0);
			}
		}
		return dictionary;
	}

	public void z0yek()
	{
		if (z0bek != null)
		{
			z0bek.Clear();
			z0bek = null;
		}
	}

	public new z0ZzZzrzj z0eek(int p0)
	{
		DocumentContentStyle documentContentStyle = (DocumentContentStyle)base.z0uek.z0eek(p0, base.z0tek);
		if (documentContentStyle == null)
		{
			return ((DocumentContentStyle)base.z0tek).z0eek_jiejie20260327142557();
		}
		return documentContentStyle.z0eek_jiejie20260327142557();
	}

	internal new void z0uek()
	{
		using zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = Styles.z0ltk();
		while (z0bpk.MoveNext())
		{
			((DocumentContentStyle)z0bpk.Current).z0eek_jiejie20260327142557();
		}
	}

	public int z0eek(DocumentContentStyle p0)
	{
		if (p0 == null || p0 == base.z0tek || z0ZzZzvik.z0eek(p0) == 0)
		{
			return -1;
		}
		if (z0bek == null)
		{
			z0bek = new Dictionary<DocumentContentStyle, int>(new z0gmk());
		}
		int num = -1;
		if (!z0bek.TryGetValue(p0, out num))
		{
			num = GetStyleIndex(p0);
			z0bek[p0] = num;
		}
		return num;
	}

	internal XTextDocument z0iek()
	{
		return z0mek;
	}

	internal void z0eek(XTextDocument p0)
	{
		z0mek = p0;
	}

	public void z0eek(z0ZzZzjpk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		z0nn();
		if (Default != null)
		{
			((DocumentContentStyle)Default).z0eek_jiejie20260327142557(p0);
		}
		for (int i = 0; i < Styles.Count; i++)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)Styles[i];
			documentContentStyle.z0eek_jiejie20260327142557(p0);
			DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)base.z0eek(i);
			if (documentContentStyle2 != documentContentStyle)
			{
				documentContentStyle2.z0eek_jiejie20260327142557(p0);
			}
		}
	}

	internal void z0oek()
	{
		z0pek = false;
		z0vek = false;
		using zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = Styles.z0ltk();
		while (z0bpk.MoveNext())
		{
			DocumentContentStyle obj = (DocumentContentStyle)z0bpk.Current;
			if (obj.LetterSpacing != 0f)
			{
				z0pek = true;
			}
			if (obj.FixedSpacing)
			{
				z0vek = true;
			}
		}
	}

	public override void z0bn()
	{
		base.z0bn();
		z0nek = null;
	}

	public override z0ZzZzcok CreateStyleInstance()
	{
		return new DocumentContentStyle();
	}

	internal bool[] z0eek(bool p0)
	{
		if (base.z0uek == null || base.z0uek.Count == 0)
		{
			return null;
		}
		bool[] array = new bool[base.z0uek.Count];
		for (int i = 0; i < base.z0uek.Count; i++)
		{
			array[i] = true;
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)base.z0uek[i];
			if (!p0 && documentContentStyle.DeleterIndex >= 0)
			{
				array[i] = false;
			}
		}
		return array;
	}

	internal bool z0eek(int p0, bool p1)
	{
		if (p0 < 0 || p1)
		{
			return true;
		}
		if (base.z0uek == null)
		{
			return true;
		}
		if (z0nek == null)
		{
			z0nek = z0tek();
		}
		if (z0nek.Count == 0)
		{
			return true;
		}
		return !z0nek.ContainsKey(p0);
	}

	public override void z0nn()
	{
		if (base.Default != null)
		{
			((DocumentContentStyle)base.Default).z0eek_jiejie20260327142557((z0ZzZzrzj)null);
		}
		foreach (DocumentContentStyle item in Styles.z0xrk())
		{
			item.z0rek(null);
			item.z0eek_jiejie20260327142557((z0ZzZzrzj)null);
		}
	}
}
