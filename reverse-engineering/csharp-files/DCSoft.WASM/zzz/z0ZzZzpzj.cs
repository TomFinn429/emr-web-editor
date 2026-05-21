using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzpzj : IDisposable
{
	private readonly float z0uek;

	private XTextTableRowElement z0iek;

	internal z0ZzZzizj[] z0oek;

	private readonly float z0pek;

	private readonly float z0mek;

	public z0ZzZzpzj(XTextTableRowElement p0)
	{
		z0iek = p0;
		z0pek = p0.SpecifyHeight;
		z0uek = p0.z0yt();
		z0mek = p0.Height;
	}

	public float z0eek()
	{
		return z0uek;
	}

	public float z0rek()
	{
		return z0mek;
	}

	public float z0tek()
	{
		return z0pek;
	}

	public XTextTableRowElement z0yek_jiejie20260327142557()
	{
		return z0iek;
	}

	public void Dispose()
	{
		z0iek = null;
		if (z0oek != null)
		{
			z0ZzZzizj[] array = z0oek;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Dispose();
			}
			Array.Clear(z0oek);
			z0oek = null;
		}
	}
}
