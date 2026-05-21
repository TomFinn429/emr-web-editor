using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzizj : IDisposable
{
	private XTextTableCellElement z0bek;

	private readonly int z0vek = 1;

	private XTextElement[] z0cek;

	private readonly float z0xek;

	private XTextTableCellElement z0zek;

	private readonly float z0lrk;

	private string z0krk;

	private readonly int z0jrk = 1;

	private readonly float z0hrk;

	private readonly float z0grk;

	public z0ZzZzizj(XTextTableCellElement p0, bool p1)
	{
		z0bek = p0;
		z0zek = p0.z0hrk();
		z0jrk = p0.RowSpan;
		z0vek = p0.ColSpan;
		z0hrk = p0.z0it();
		z0xek = p0.z0yt();
		z0lrk = p0.Width;
		z0grk = p0.Height;
		z0krk = p0.ValueExpression;
		if (p1 && p0.z0be() != null)
		{
			z0cek = p0.z0be().ToArray();
		}
	}

	public float z0eek()
	{
		return z0hrk;
	}

	public float z0rek()
	{
		return z0xek;
	}

	public XTextTableCellElement z0tek()
	{
		return z0zek;
	}

	public void z0eek(XTextElement[] p0)
	{
		z0cek = p0;
	}

	public XTextTableCellElement z0yek()
	{
		return z0bek;
	}

	public string z0uek()
	{
		return z0krk;
	}

	public int z0iek()
	{
		return z0jrk;
	}

	public int z0oek()
	{
		return z0vek;
	}

	public void Dispose()
	{
		z0bek = null;
		z0zek = null;
		z0krk = null;
	}

	public XTextElement[] z0pek()
	{
		return z0cek;
	}

	public float z0mek()
	{
		return z0lrk;
	}

	public float z0nek()
	{
		return z0grk;
	}
}
