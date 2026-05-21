using System.Collections;
using System.Text;

namespace zzz;

internal abstract class z0ZzZzznk : z0ZzZzhbk, IEnumerable
{
	protected new z0ZzZzgbk z0tek = new z0ZzZzgbk();

	public override void FixDom()
	{
		if (z0tek == null)
		{
			return;
		}
		foreach (z0ZzZzhbk item in z0tek.z0xrk())
		{
			item.FixDom();
		}
	}

	public override z0ZzZzgbk z0oqk()
	{
		return z0tek;
	}

	public z0ZzZzznk()
	{
	}

	protected virtual bool z0wqk()
	{
		return true;
	}

	internal new virtual z0ZzZzhbk z0eek(string p0)
	{
		z0ZzZzhbk z0ZzZzhbk2 = null;
		using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzhbk current = z0bpk.Current;
				if (current.z0uek() == p0)
				{
					return current;
				}
				if (current is z0ZzZzznk)
				{
					z0ZzZzhbk2 = ((z0ZzZzznk)current).z0eek(p0);
					if (z0ZzZzhbk2 != null)
					{
						return z0ZzZzhbk2;
					}
				}
			}
		}
		return null;
	}

	public override void z0sqk(string p0)
	{
		z0ZzZzmvk z0ZzZzmvk2 = new z0ZzZzmvk(p0);
		if (z0ZzZzmvk2.z0yqk(this))
		{
			z0tek.Clear();
			z0uqk(z0ZzZzmvk2);
		}
	}

	internal virtual bool z0xak(string p0)
	{
		switch (p0)
		{
		case "tr":
		case "td":
		case "li":
			return false;
		default:
			return true;
		}
	}

	internal virtual void z0eek(z0ZzZzgbk p0)
	{
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current = z0bpk.Current;
			p0.Add(current);
			if (current is z0ZzZzznk)
			{
				((z0ZzZzznk)current).z0eek(p0);
			}
		}
	}

	internal override bool z0dqk(z0ZzZznvk p0)
	{
		while (!p0.z0cek())
		{
			string text = p0.z0tek();
			if (text != null && text.Length > 0 && z0xak("#text"))
			{
				if (z0ZzZzkbk.z0vek)
				{
					if (z0ZzZzqik.z0rek(text))
					{
						z0iqk(p0.z0rek(text));
					}
				}
				else
				{
					z0iqk(p0.z0rek(text));
				}
			}
			if (p0.z0cek())
			{
				break;
			}
			if (p0.z0eek() == '!')
			{
				if (p0.z0tek("<!--"))
				{
					p0.z0rek(4);
					text = p0.z0oek("-->");
					if (text != null && z0xak("#comment"))
					{
						z0ZzZzxnk z0ZzZzxnk2 = new z0ZzZzxnk();
						z0ZzZzxnk2.z0kqk(text);
						z0iqk(z0ZzZzxnk2);
					}
					p0.z0rek(3);
				}
				else
				{
					p0.z0eek('>');
					p0.z0rek();
				}
				continue;
			}
			if (p0.z0eek() == '/')
			{
				p0.z0rek(2);
				string text2 = p0.z0vek();
				p0.z0rek(-2);
				if (text2 != null && z0fqk(p0, text2))
				{
					break;
				}
				p0.z0eek('>');
				continue;
			}
			if (p0.z0eek() == '?')
			{
				p0.z0eek('>');
				continue;
			}
			p0.z0uek();
			string text3 = p0.z0oek();
			if (text3 == null)
			{
				continue;
			}
			if (text3 == "colgroup")
			{
				p0.z0eek('>');
				continue;
			}
			if (!z0tqk(text3))
			{
				p0.z0rek('<');
				break;
			}
			if (!z0xak(text3))
			{
				continue;
			}
			z0ZzZzhbk z0ZzZzhbk2 = z0lrk.z0eek(text3, this);
			if (z0ZzZzhbk2 != null)
			{
				p0.z0rek();
				if (z0ZzZzhbk2 == this && this is z0ZzZzkbk)
				{
					z0ZzZzhbk2.z0eek(p0);
					z0ZzZzhbk2.z0dqk(p0);
				}
				else
				{
					z0uqk(z0ZzZzhbk2);
					z0ZzZzhbk2.z0rqk(p0);
				}
			}
			else
			{
				p0.z0yek(text3);
			}
		}
		return true;
	}

	internal virtual int z0eek(string p0, z0ZzZzgbk p1)
	{
		int num = 0;
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current = z0bpk.Current;
			if (current.z0rek("name") == p0)
			{
				p1.Add(current);
				num++;
			}
			if (current is z0ZzZzznk)
			{
				num += ((z0ZzZzznk)current).z0eek(p0, p1);
			}
		}
		return num;
	}

	public override string z0jqk()
	{
		StringBuilder stringBuilder = new StringBuilder();
		z0eqk(stringBuilder);
		return z0ZzZztwh.z0rek(stringBuilder.ToString());
	}

	public virtual void z0eqk(StringBuilder p0)
	{
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current = z0bpk.Current;
			if (current is z0ZzZzznk)
			{
				((z0ZzZzznk)current).z0eqk(p0);
			}
			else
			{
				p0.Append(current.z0jqk());
			}
		}
	}

	internal virtual int z0rek(string p0, z0ZzZzgbk p1)
	{
		int num = 0;
		using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0tek.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzhbk current = z0bpk.Current;
			if (current.z0vak() == p0)
			{
				p1.Add(current);
				num++;
			}
			if (current is z0ZzZzznk)
			{
				num += ((z0ZzZzznk)current).z0rek(p0, p1);
			}
		}
		return num;
	}

	internal virtual bool z0fqk(z0ZzZznvk p0, string p1)
	{
		if (p1 == z0cak() || !z0xak(p1))
		{
			p0.z0eek('>');
			return true;
		}
		return false;
	}

	public IEnumerator GetEnumerator()
	{
		return z0tek.z0ltk();
	}

	protected virtual bool z0tqk(string p0)
	{
		return true;
	}

	public override bool z0uqk(z0ZzZzhbk p0)
	{
		if (z0tek.Contains(p0))
		{
			return true;
		}
		if (z0iqk(p0))
		{
			return true;
		}
		if (z0vek != null && z0vek != this)
		{
			z0vek.z0uqk(p0);
		}
		return false;
	}

	internal virtual bool z0iqk(z0ZzZzhbk p0)
	{
		if (z0xak(p0.z0vak()) && p0.z0yqk(this))
		{
			z0tek.Add(p0);
			p0.z0eek(z0lrk, this);
			if (p0 is z0ZzZzlck)
			{
				for (z0ZzZzhbk z0ZzZzhbk2 = this; z0ZzZzhbk2 != null; z0ZzZzhbk2 = z0ZzZzhbk2.z0eek())
				{
					if (z0ZzZzhbk2 is z0ZzZzdbk)
					{
						((z0ZzZzdbk)z0ZzZzhbk2).z0eek((z0ZzZzlck)p0);
						break;
					}
				}
			}
			return true;
		}
		return false;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0tek != null)
		{
			z0tek.z0zrk();
			z0tek = null;
		}
	}
}
