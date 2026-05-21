using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.Controls;

public class CommandErrorEventArgs
{
	private XTextDocument z0eek;

	private z0ZzZzdbj z0rek;

	private object z0tek;

	private string z0yek;

	private string z0uek;

	private bool z0iek;

	private Exception z0oek;

	[JsonIgnore]
	public Exception Exception
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[JsonIgnore]
	public z0ZzZzdbj WriterControl
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[JsonIgnore]
	public object CommmandParameter
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public string ExceptionMessage => z0oek?.Message;

	[JsonIgnore]
	public XTextDocument Document
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	[JsonIgnore]
	public bool Handled
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public string CommandName
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public string Message
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}
}
