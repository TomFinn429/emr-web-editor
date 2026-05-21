using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class ElementMouseEventArgs : ElementEventArgs
{
	private float z0eek;

	private int z0rek_jiejie20260327142557;

	private float z0tek;

	private float z0yek;

	private float z0uek;

	private int z0iek;

	private z0ZzZzqeh z0oek;

	public float ElementClientY
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

	public bool HasRightButton
	{
		[JSInvokable]
		get
		{
			return (z0oek & (z0ZzZzqeh)2) == (z0ZzZzqeh)2;
		}
	}

	public int Delta
	{
		[JSInvokable]
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public z0ZzZzqeh Button
	{
		[JSInvokable]
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public float DocumentX
	{
		[JSInvokable]
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public float DocumentY
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

	public int Clicks
	{
		[JSInvokable]
		get
		{
			return z0rek_jiejie20260327142557;
		}
		set
		{
			z0rek_jiejie20260327142557 = value;
		}
	}

	public int ButtonValue => (int)Button;

	public bool HasLeftButton
	{
		[JSInvokable]
		get
		{
			return (z0oek & (z0ZzZzqeh)1) == (z0ZzZzqeh)1;
		}
	}

	public float ElementClientX
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

	public ElementMouseEventArgs(DocumentEventArgs args, XTextElement element)
		: base(element)
	{
		if (args != null)
		{
			z0oek = args.Button;
			z0rek_jiejie20260327142557 = args.MouseClicks;
			z0iek = args.WheelDelta;
			z0yek = args.X;
			z0tek = args.Y;
		}
		if (element != null)
		{
			z0ZzZzrzj z0ZzZzrzj = element.z0aek();
			z0ZzZzbdh z0ZzZzbdh = element.z0qyk();
			z0uek = z0yek - z0ZzZzbdh.z0tek() - z0ZzZzrzj.z0ryk;
			z0eek = z0tek - z0ZzZzbdh.z0yek() - z0ZzZzrzj.z0quk;
		}
	}
}
