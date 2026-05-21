using System;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZznpj
{
	private readonly XTextElement z0uek;

	private readonly string z0iek;

	[NonSerialized]
	private readonly Exception z0oek;

	private readonly string z0pek;

	public string z0eek()
	{
		return z0iek;
	}

	public Exception z0rek()
	{
		return z0oek;
	}

	public z0ZzZznpj(XTextElement p0, Exception p1, string p2)
	{
		if (p0 != null)
		{
			z0uek = p0;
		}
		if (p1 != null)
		{
			z0oek = p1;
			z0iek = p1.Message;
		}
		z0pek = p2;
	}

	public string z0tek()
	{
		return z0pek;
	}

	public XTextElement z0yek()
	{
		return z0uek;
	}
}
