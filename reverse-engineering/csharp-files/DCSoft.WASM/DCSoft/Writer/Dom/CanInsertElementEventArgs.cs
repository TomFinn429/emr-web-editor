using System;
using zzz;

namespace DCSoft.Writer.Dom;

public class CanInsertElementEventArgs
{
	private XTextElement z0eek;

	private int z0rek;

	private bool z0tek = true;

	private z0ZzZzbcj z0yek = (z0ZzZzbcj)255;

	private Type z0uek;

	private XTextContainerElement z0iek;

	private string z0oek;

	private bool z0pek;

	public int Index => z0rek;

	public Type ElementType => z0uek;

	public XTextContainerElement Container => z0iek;

	public bool SetMessage
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public string Message
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

	public bool Result
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

	public XTextElement Element => z0eek;

	public z0ZzZzbcj Flags
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

	public CanInsertElementEventArgs(XTextContainerElement container, int index, Type elementType, z0ZzZzbcj flags)
	{
		z0iek = container;
		z0rek = index;
		z0uek = elementType;
		z0yek = flags;
	}

	public CanInsertElementEventArgs(XTextContainerElement container, int index, XTextElement element, z0ZzZzbcj flags)
	{
		z0iek = container;
		z0rek = index;
		z0eek = element;
		z0yek = flags;
	}
}
