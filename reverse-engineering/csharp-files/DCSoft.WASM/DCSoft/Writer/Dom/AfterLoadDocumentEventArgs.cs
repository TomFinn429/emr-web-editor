using System;

namespace DCSoft.Writer.Dom;

public class AfterLoadDocumentEventArgs
{
	private string z0iek;

	private object z0oek;

	private XTextDocument z0pek;

	private string z0mek;

	private string z0nek_jiejie20260327142557;

	public XTextDocument z0eek()
	{
		return z0pek;
	}

	public object z0rek()
	{
		return z0oek;
	}

	public string z0tek()
	{
		return z0iek;
	}

	public string z0yek()
	{
		return z0mek;
	}

	public string z0uek()
	{
		return z0nek_jiejie20260327142557;
	}

	internal AfterLoadDocumentEventArgs(string fileSystemName, object obj, string format, XTextDocument instance)
	{
		z0mek = fileSystemName;
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		z0oek = obj;
		if (obj is string)
		{
			z0iek = (string)obj;
		}
		z0nek_jiejie20260327142557 = format;
		z0pek = instance;
	}
}
