using System.Windows.Forms;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;

namespace DCSoft.Writer;

public class ElementKeyEventArgs : ElementEventArgs
{
	private bool z0eek;

	private Keys z0rek;

	private bool z0tek;

	private char z0yek_jiejie20260327142557;

	private bool z0uek;

	public int KeyCharValue
	{
		[JSInvokable]
		get
		{
			return z0yek_jiejie20260327142557;
		}
	}

	public bool Control
	{
		[JSInvokable]
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public int KeyCodeValue
	{
		[JSInvokable]
		get
		{
			return (int)z0rek;
		}
	}

	public bool Alt
	{
		[JSInvokable]
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public char KeyChar
	{
		[JSInvokable]
		get
		{
			return z0yek_jiejie20260327142557;
		}
	}

	public Keys KeyCode
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public bool Shift
	{
		[JSInvokable]
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public ElementKeyEventArgs(DocumentEventArgs args, XTextElement element)
		: base(element)
	{
		z0uek = args.AltKey;
		z0tek = args.ShiftKey;
		z0eek = args.CtlKey;
		z0rek = args.KeyCode;
		z0yek_jiejie20260327142557 = args.KeyChar;
	}
}
