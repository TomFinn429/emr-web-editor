using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzozj : IDisposable
{
	private readonly float z0yek;

	private readonly float z0uek;

	private XTextTableColumnElement z0iek;

	public float z0eek()
	{
		return z0uek;
	}

	public XTextTableColumnElement z0rek()
	{
		return z0iek;
	}

	public float z0tek()
	{
		return z0yek;
	}

	public void Dispose()
	{
		z0iek = null;
	}

	public z0ZzZzozj(XTextTableColumnElement p0)
	{
		z0iek = p0;
		z0uek = p0.z0it();
		z0yek = p0.Width;
	}
}
