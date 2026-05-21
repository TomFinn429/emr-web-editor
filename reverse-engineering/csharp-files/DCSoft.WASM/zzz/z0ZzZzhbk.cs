using System;

namespace zzz;

internal abstract class z0ZzZzhbk : IDisposable
{
	private static int z0pek = 0;

	private static int z0mek = 0;

	protected z0ZzZzevk z0nek;

	protected z0ZzZzink z0bek;

	protected z0ZzZzznk z0vek;

	private z0ZzZzevk z0cek;

	private static readonly string z0xek = "1";

	private static readonly string z0zek = "</";

	protected z0ZzZzkbk z0lrk;

	public virtual z0ZzZzevk z0lqk()
	{
		if (z0nek == null)
		{
			z0nek = new z0ZzZzevk();
			z0nek.z0eek(this);
			z0nek.z0tek_jiejie20260327142557(z0eek("style"));
		}
		return z0nek;
	}

	public z0ZzZzznk z0eek()
	{
		if (z0vek == this)
		{
			return null;
		}
		return z0vek;
	}

	protected virtual bool z0gqk()
	{
		return false;
	}

	public virtual void Dispose()
	{
		if (z0bek != null)
		{
			z0bek.Dispose();
			z0bek = null;
		}
		z0vek = null;
		z0lrk = null;
		if (z0nek != null)
		{
			z0nek.Dispose();
			z0nek = null;
		}
		if (z0cek != null)
		{
			z0cek.Dispose();
			z0cek = null;
		}
	}

	public string z0eek(string p0)
	{
		return z0bek?.z0tek(p0);
	}

	public virtual string z0cak()
	{
		string text = z0vak();
		if (text != null)
		{
			return text.Trim().ToLower();
		}
		return text;
	}

	protected virtual bool z0rek()
	{
		switch (z0cak())
		{
		case "input":
		case "source":
		case "img":
		case "br":
		case "col":
		case "area":
		case "meta":
		case "param":
			return false;
		default:
			return true;
		}
	}

	internal virtual bool z0yqk(z0ZzZzznk p0)
	{
		return true;
	}

	public virtual string z0vak()
	{
		return null;
	}

	public z0ZzZzkbk z0tek()
	{
		return z0lrk;
	}

	public virtual z0ZzZzgbk z0oqk()
	{
		return null;
	}

	public string z0rek(string p0)
	{
		return z0bek?.z0uek(p0);
	}

	public bool z0yek()
	{
		z0ZzZzgbk z0ZzZzgbk2 = z0oqk();
		if (z0ZzZzgbk2 != null)
		{
			return z0ZzZzgbk2.Count > 0;
		}
		return false;
	}

	public virtual string z0zak()
	{
		return null;
	}

	public string z0uek()
	{
		return z0rek("id");
	}

	public bool z0tek(string p0)
	{
		if (z0bek == null)
		{
			return false;
		}
		return z0bek.z0yek(p0);
	}

	internal virtual bool z0rqk(z0ZzZznvk p0)
	{
		z0eek(p0);
		if (!z0rek())
		{
			return true;
		}
		if (!p0.z0cek())
		{
			return z0dqk(p0);
		}
		return false;
	}

	public bool z0iek()
	{
		if (z0bek != null)
		{
			return z0bek.Count > 0;
		}
		return false;
	}

	public bool z0eek(string p0, out string p1)
	{
		if (z0bek != null)
		{
			for (int num = z0bek.Count - 1; num >= 0; num--)
			{
				if (z0bek[num].z0rek() == p0)
				{
					string text = z0bek[num].z0yek();
					if (text == null || text.Length <= 0)
					{
						break;
					}
					p1 = text;
					return true;
				}
			}
		}
		p1 = null;
		return false;
	}

	public virtual string z0jqk()
	{
		return z0zak();
	}

	internal virtual void z0eek(z0ZzZznvk p0)
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		z0ZzZzink z0ZzZzink2 = z0bek;
		if (z0ZzZzink2 == null)
		{
			z0ZzZzink2 = (z0bek = new z0ZzZzink());
		}
		while (!p0.z0cek())
		{
			p0.z0rek();
			char c = p0.z0iek();
			if (c == '/' && p0.z0mek() == '>')
			{
				p0.z0rek(2);
				break;
			}
			switch (c)
			{
			case '>':
				p0.z0uek();
				break;
			default:
				text = p0.z0oek();
				if (text == null)
				{
					break;
				}
				p0.z0rek();
				if (p0.z0cek() || p0.z0iek() != '=')
				{
					text2 = z0xek;
				}
				else
				{
					p0.z0uek();
					text2 = p0.z0pek();
					if (text2 != null && text2.Length > 0)
					{
						if (z0ZzZzkbk.z0vek)
						{
							z0pek++;
							switch (text)
							{
							case "class":
							case "align":
							case "bd2019":
							case "dspd":
							case "dctype":
							case "id":
								z0mek++;
								break;
							default:
								if (text2.Length > 1000)
								{
									if (text == "dcdocumentviewstate" || text2.StartsWith("data:image/", StringComparison.Ordinal))
									{
										z0mek++;
									}
									else
									{
										text2 = z0ZzZztwh.z0rek(text2);
									}
								}
								else
								{
									text2 = z0ZzZztwh.z0rek(text2);
								}
								break;
							}
						}
						else
						{
							text2 = z0ZzZztwh.z0rek(text2);
						}
					}
				}
				if (z0ZzZzkbk.z0vek || z0ZzZzcah.z0eek(text))
				{
					z0ZzZzunk item = p0.z0eek(text, text2);
					z0ZzZzink2.Add(item);
					if (text == "style")
					{
						text3 = text2;
					}
				}
				continue;
			case '<':
				break;
			}
			break;
		}
		if (text3 != null && text3.Length > 0)
		{
			z0nek = new z0ZzZzevk();
			z0nek.z0eek(text3, p0);
		}
		else
		{
			z0nek = null;
		}
	}

	public virtual void z0kqk(string p0)
	{
	}

	internal void z0eek(z0ZzZzkbk p0, z0ZzZzznk p1)
	{
		z0lrk = p0;
		z0vek = p1;
	}

	public virtual bool z0uqk(z0ZzZzhbk p0)
	{
		return false;
	}

	public virtual string z0hqk()
	{
		return null;
	}

	public virtual void FixDom()
	{
	}

	public z0ZzZzink z0oek()
	{
		return z0bek;
	}

	internal virtual bool z0dqk(z0ZzZznvk p0)
	{
		if (z0gqk())
		{
			string p1 = p0.z0tek();
			if (p0.z0tek(z0zek + z0vak()))
			{
				p0.z0eek('>');
			}
			z0kqk(p1);
		}
		return true;
	}

	public virtual void z0sqk(string p0)
	{
		z0kqk(p0);
	}
}
