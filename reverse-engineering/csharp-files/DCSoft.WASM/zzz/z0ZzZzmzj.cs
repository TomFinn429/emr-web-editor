using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzmzj : IDisposable
{
	private float z0pek;

	private z0ZzZzpzj[] z0mek;

	private float z0nek;

	private int z0bek = -1;

	private float z0vek;

	private z0ZzZzozj[] z0cek;

	private XTextTableElement z0xek;

	public void z0eek(int p0)
	{
		z0bek = p0;
	}

	public float z0eek()
	{
		return z0nek;
	}

	public void Dispose()
	{
		z0xek = null;
		if (z0mek != null)
		{
			z0ZzZzpzj[] array = z0mek;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
			Array.Clear(z0mek);
			z0mek = null;
		}
		if (z0cek != null)
		{
			z0ZzZzozj[] array2 = z0cek;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Dispose();
			}
			Array.Clear(z0cek);
			z0cek = null;
		}
	}

	public void z0eek(XTextTableElement p0)
	{
		z0xek = p0;
	}

	public void z0eek(float p0)
	{
		z0pek = p0;
	}

	public void z0eek(XTextTableElement p0, bool p1)
	{
		z0eek(p0.z0jr().z0cuk().z0nek());
		z0eek(p0);
		z0tek(p0.Width);
		z0rek(p0.Height);
		z0eek(p0.z0qtk());
		z0cek = new z0ZzZzozj[p0.z0srk().Count];
		int num = 0;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement p2 = (XTextTableColumnElement)z0bpk.Current;
				z0cek[num++] = new z0ZzZzozj(p2);
			}
		}
		z0mek = new z0ZzZzpzj[p0.z0stk().Count];
		num = 0;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
			z0ZzZzpzj z0ZzZzpzj2 = new z0ZzZzpzj(xTextTableRowElement);
			z0mek[num++] = z0ZzZzpzj2;
			z0ZzZzpzj2.z0oek = new z0ZzZzizj[xTextTableRowElement.z0rek().Count];
			int num2 = 0;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement.z0rek().z0ltk();
			while (z0bpk2.MoveNext())
			{
				XTextTableCellElement p3 = (XTextTableCellElement)z0bpk2.Current;
				z0ZzZzpzj2.z0oek[num2++] = new z0ZzZzizj(p3, p1);
			}
		}
	}

	public int z0rek()
	{
		return z0bek;
	}

	public z0ZzZzmzj(XTextTableElement p0, bool p1)
	{
		z0eek(p0, p1);
	}

	public void z0rek(float p0)
	{
		z0vek = p0;
	}

	public float z0tek()
	{
		return z0vek;
	}

	public z0ZzZzmzj(XTextTableElement p0)
	{
		z0eek(p0, p1: false);
	}

	public void z0tek(float p0)
	{
		z0nek = p0;
	}

	public XTextTableElement z0yek()
	{
		return z0xek;
	}

	public float z0uek()
	{
		return z0pek;
	}

	internal z0ZzZzozj[] z0iek()
	{
		return z0cek;
	}

	public void z0rek(XTextTableElement p0, bool p1)
	{
		p0.Width = z0eek();
		p0.Height = z0tek();
		p0.z0mek(z0uek());
		p0.z0srk().Clear();
		z0ZzZzozj[] array = z0iek();
		foreach (z0ZzZzozj z0ZzZzozj2 in array)
		{
			XTextTableColumnElement xTextTableColumnElement = z0ZzZzozj2.z0rek();
			xTextTableColumnElement.Width = z0ZzZzozj2.z0tek();
			xTextTableColumnElement.z0ot(z0ZzZzozj2.z0eek());
			xTextTableColumnElement.z0yek(p0);
			p0.z0srk().Add(xTextTableColumnElement);
		}
		p0.z0stk().Clear();
		z0ZzZzpzj[] array2 = z0oek();
		foreach (z0ZzZzpzj z0ZzZzpzj2 in array2)
		{
			XTextTableRowElement xTextTableRowElement = z0ZzZzpzj2.z0yek_jiejie20260327142557();
			p0.z0stk().Add(xTextTableRowElement);
			xTextTableRowElement.SpecifyHeight = z0ZzZzpzj2.z0tek();
			xTextTableRowElement.z0nt(z0ZzZzpzj2.z0eek());
			xTextTableRowElement.Height = z0ZzZzpzj2.z0rek();
			xTextTableRowElement.z0nu(p0);
			xTextTableRowElement.z0rek().Clear();
			z0ZzZzizj[] array3 = z0ZzZzpzj2.z0oek;
			foreach (z0ZzZzizj z0ZzZzizj2 in array3)
			{
				XTextTableCellElement xTextTableCellElement = z0ZzZzizj2.z0yek();
				xTextTableCellElement.z0yek(z0ZzZzizj2.z0iek());
				xTextTableCellElement.z0tek(z0ZzZzizj2.z0oek());
				xTextTableCellElement.z0rek(z0ZzZzizj2.z0tek());
				xTextTableCellElement.z0ot(z0ZzZzizj2.z0eek());
				xTextTableCellElement.z0nt(z0ZzZzizj2.z0rek());
				xTextTableCellElement.Width = z0ZzZzizj2.z0mek();
				xTextTableCellElement.Height = z0ZzZzizj2.z0nek();
				xTextTableCellElement.ValueExpression = z0ZzZzizj2.z0uek();
				xTextTableCellElement.z0nu(xTextTableRowElement);
				xTextTableRowElement.z0rek().Add(xTextTableCellElement);
				if (z0ZzZzizj2.z0pek() != null)
				{
					xTextTableCellElement.z0be().Clear();
					xTextTableCellElement.z0be().z0oek(z0ZzZzizj2.z0pek());
					xTextTableCellElement.z0bek(p0: true);
				}
				if (p1 && xTextTableCellElement.z0hrk() == null)
				{
					xTextTableCellElement.z0ct();
					((XTextContentElement)xTextTableCellElement).z0rrk();
				}
			}
		}
		p0.z0pek(p0: false, p1: true);
	}

	internal z0ZzZzpzj[] z0oek()
	{
		return z0mek;
	}
}
