using System;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzvjh : IDisposable
{
	private z0ZzZzcjh z0nek;

	private string z0bek;

	internal string z0vek;

	private XTextElementList z0cek = new XTextElementList();

	private int z0xek;

	public string z0eek()
	{
		return z0vek;
	}

	internal void z0eek(z0ZzZzvjh p0)
	{
		if (z0nek == null)
		{
			z0nek = new z0ZzZzcjh();
		}
		z0nek.Add(p0);
	}

	public XTextElementList z0rek()
	{
		return z0cek;
	}

	public int z0tek()
	{
		if (z0cek != null && z0cek.Count > 0)
		{
			return z0cek[0].z0jrk();
		}
		return -1;
	}

	public void z0eek(XTextElementList p0)
	{
		z0cek = p0;
	}

	internal void z0eek(XTextElement p0)
	{
		if (z0cek == null)
		{
			z0cek = new XTextElementList();
		}
		z0cek.Add(p0);
		z0bek = null;
	}

	public void Dispose()
	{
		z0vek = null;
		z0bek = null;
		if (z0nek != null)
		{
			foreach (z0ZzZzvjh item in z0nek)
			{
				item.Dispose();
			}
			z0nek.Clear();
		}
		z0nek = null;
		if (z0cek != null)
		{
			z0cek.Clear();
			z0cek = null;
		}
	}

	public bool z0yek()
	{
		if (z0nek != null)
		{
			return z0nek.Count > 0;
		}
		return false;
	}

	public int z0uek()
	{
		if (z0cek != null && z0cek.Count > 0)
		{
			return z0cek.LastElement.z0jrk();
		}
		return -1;
	}

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public z0ZzZzvjh(string p0)
	{
		z0vek = p0;
	}

	public void z0eek(z0ZzZzcjh p0)
	{
		z0nek = p0;
	}

	public string z0iek()
	{
		if (z0bek == null && z0cek != null && z0cek.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0cek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (current is XTextCharElement)
					{
						stringBuilder.Append(((XTextCharElement)current).z0mek());
					}
					else if (current is XTextLabelElement)
					{
						stringBuilder.Append(current.Text);
					}
				}
			}
			z0bek = stringBuilder.ToString();
		}
		return z0bek;
	}

	public int z0oek()
	{
		if (z0cek != null && z0cek.Count > 0)
		{
			return z0cek[0].z0jrk();
		}
		return -1;
	}

	public int z0pek()
	{
		return z0xek;
	}

	public z0ZzZzcjh z0mek()
	{
		if (z0nek == null)
		{
			z0nek = new z0ZzZzcjh();
		}
		return z0nek;
	}
}
