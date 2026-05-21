using System;

namespace DCSoft.Writer.Dom;

public class BeforeLoadDocumentEventArgs
{
	private string z0oek;

	private XTextDocument z0pek;

	private bool z0mek;

	private string z0nek;

	private string z0bek;

	private object z0vek;

	public string z0eek()
	{
		return z0nek;
	}

	public object z0rek()
	{
		return z0vek;
	}

	public string z0tek()
	{
		return z0oek;
	}

	internal BeforeLoadDocumentEventArgs(string fileSystemName, object obj, string format, XTextDocument instance)
	{
		z0oek = fileSystemName;
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		z0vek = obj;
		if (obj is string)
		{
			z0bek = (string)obj;
		}
		z0nek = format;
		z0pek = instance;
	}

	public void z0eek(bool p0)
	{
		z0mek = p0;
	}

	public bool z0yek()
	{
		return z0mek;
	}

	public XTextDocument z0uek()
	{
		return z0pek;
	}

	public string z0iek()
	{
		return z0bek;
	}
}
