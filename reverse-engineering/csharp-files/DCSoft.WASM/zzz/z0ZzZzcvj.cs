using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzcvj : IDisposable
{
	private class z0xck : z0ZzZzoik
	{
		public override IEnumerable GetChildNodes(object instance)
		{
			return ((z0ZzZzvjh)instance).z0mek();
		}

		public z0xck(z0ZzZzcjh p0)
			: base(p0)
		{
		}
	}

	private z0ZzZzcjh z0oek = new z0ZzZzcjh();

	private z0ZzZzdbj z0pek;

	private XTextDocument z0mek;

	public z0ZzZzdbj z0eek()
	{
		return z0pek;
	}

	public void z0rek()
	{
		int num = 1;
		XTextDocument xTextDocument = z0yek();
		z0oek.Clear();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = xTextDocument.z0gnk().Styles.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
				if (documentContentStyle.HasTitleLevel)
				{
					dictionary[xTextDocument.z0gnk().Styles.IndexOf(documentContentStyle)] = documentContentStyle.TitleLevel;
				}
			}
		}
		if (dictionary.Count <= 0)
		{
			return;
		}
		Stack<z0ZzZzvjh> stack = new Stack<z0ZzZzvjh>();
		int num2 = 0;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextDocument.z0xyk().z0frk().z0ltk();
		while (z0bpk2.MoveNext())
		{
			XTextElement current = z0bpk2.Current;
			if (dictionary.ContainsKey(current.z0pek()))
			{
				int num3 = dictionary[current.z0pek()];
				if (num2 > 0)
				{
					num2 = 0;
					while (stack.Count > 0 && stack.Peek().z0pek() >= num3)
					{
						stack.Pop();
					}
				}
				else
				{
					while (stack.Count > 0 && stack.Peek().z0pek() > num3)
					{
						stack.Pop();
					}
				}
				if (stack.Count > 0 && stack.Peek().z0pek() == num3)
				{
					stack.Peek().z0eek(current);
					continue;
				}
				z0ZzZzvjh z0ZzZzvjh2 = new z0ZzZzvjh(Convert.ToString(num++));
				z0ZzZzvjh2.z0eek(num3);
				z0ZzZzvjh2.z0eek(current);
				if (stack.Count == 0)
				{
					z0iek().Add(z0ZzZzvjh2);
				}
				else
				{
					stack.Peek().z0eek(z0ZzZzvjh2);
				}
				stack.Push(z0ZzZzvjh2);
			}
			else
			{
				num2++;
			}
		}
	}

	public string z0tek()
	{
		StringBuilder stringBuilder = new StringBuilder();
		z0eek(z0iek(), null, stringBuilder);
		return stringBuilder.ToString();
	}

	private z0ZzZzvjh z0eek(z0ZzZzcjh p0, string p1)
	{
		if (p0 == null)
		{
			return null;
		}
		foreach (z0ZzZzvjh item in p0)
		{
			if (item.z0eek() == p1)
			{
				return item;
			}
			z0ZzZzvjh z0ZzZzvjh2 = z0eek(item.z0mek(), p1);
			if (z0ZzZzvjh2 != null)
			{
				return z0ZzZzvjh2;
			}
		}
		return null;
	}

	public XTextDocument z0yek()
	{
		if (z0pek == null)
		{
			return z0mek;
		}
		return z0pek.z0ruk();
	}

	public void Dispose()
	{
		z0pek = null;
		z0mek = null;
		if (z0oek == null)
		{
			return;
		}
		foreach (z0ZzZzvjh item in z0oek)
		{
			item.Dispose();
		}
		z0oek.Clear();
		z0oek = null;
	}

	public z0ZzZzvjh z0uek()
	{
		if (z0iek().Count > 0)
		{
			int num = z0yek().z0cuk().z0nek();
			z0xck z0xck = new z0xck(z0iek());
			z0ZzZzvjh z0ZzZzvjh2 = null;
			foreach (z0ZzZzvjh item in z0xck)
			{
				if (item.z0tek() > num)
				{
					break;
				}
				z0ZzZzvjh2 = item;
			}
			if (z0ZzZzvjh2 == null && z0iek().Count > 0)
			{
				z0ZzZzvjh2 = z0iek()[0];
			}
			return z0ZzZzvjh2;
		}
		return null;
	}

	public z0ZzZzcjh z0iek()
	{
		return z0oek;
	}

	public void z0eek(XTextDocument p0)
	{
		z0mek = p0;
	}

	public z0ZzZzvjh z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		return z0eek(z0iek(), p0);
	}

	private void z0eek(z0ZzZzcjh p0, string p1, StringBuilder p2)
	{
		foreach (z0ZzZzvjh item in p0)
		{
			if (p2.Length > 0)
			{
				p2.Append('&');
			}
			p2.Append(item.z0eek());
			p2.Append('=');
			if (p1 == null)
			{
				p2.Append(z0ZzZztwh.z0eek(item.z0iek()));
				if (item.z0mek().Count > 0)
				{
					z0eek(item.z0mek(), item.z0iek(), p2);
				}
			}
			else
			{
				p2.Append(z0ZzZztwh.z0eek(p1 + "." + item.z0iek()));
				if (item.z0mek().Count > 0)
				{
					z0eek(item.z0mek(), p1 + "." + item.z0iek(), p2);
				}
			}
		}
	}

	public void z0eek(z0ZzZzdbj p0)
	{
		z0pek = p0;
	}
}
