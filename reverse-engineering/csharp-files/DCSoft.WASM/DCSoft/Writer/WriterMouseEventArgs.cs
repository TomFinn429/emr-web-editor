using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterMouseEventArgs
{
	private int z0rek;

	private int z0tek;

	private int z0yek;

	private int z0uek;

	private int z0iek;

	private z0ZzZzdbj z0oek;

	private bool z0pek;

	private XTextElement z0mek;

	private XTextDocument z0nek;

	private int z0bek;

	private z0ZzZzqeh z0vek;

	public int ScreenY => z0yek;

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0pek;
		}
		[JSInvokable]
		set
		{
			z0pek = value;
		}
	}

	public bool HasLeftButton
	{
		[JSInvokable]
		get
		{
			return (z0vek & (z0ZzZzqeh)1) == (z0ZzZzqeh)1;
		}
	}

	public int Y
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
	}

	public int Delta
	{
		[JSInvokable]
		get
		{
			return z0bek;
		}
	}

	[JsonIgnore]
	public XTextElement HoverElement => z0mek;

	[JsonIgnore]
	public XTextDocument Document => z0nek;

	public z0ZzZzqeh Button
	{
		[JSInvokable]
		get
		{
			return z0vek;
		}
	}

	public int Clicks
	{
		[JSInvokable]
		get
		{
			return z0iek;
		}
	}

	public int X
	{
		[JSInvokable]
		get
		{
			return z0uek;
		}
	}

	public int ButtonValue => (int)z0vek;

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0oek;

	public bool HasRightButton
	{
		[JSInvokable]
		get
		{
			return (z0vek & (z0ZzZzqeh)2) == (z0ZzZzqeh)2;
		}
	}

	public WriterMouseEventArgs(z0ZzZzdbj ctl, z0ZzZzweh args)
	{
		z0oek = ctl;
		z0nek = ctl.z0ruk();
		z0uek = args.z0rek();
		z0rek = args.z0tek();
		z0iek = args.z0uek();
		z0vek = args.z0yek();
		z0bek = args.z0eek();
		z0mek = ctl.z0eik();
		if (ctl != null)
		{
			z0ZzZzodh z0ZzZzodh = new z0ZzZzodh(args.z0rek(), args.z0tek());
			z0tek = z0ZzZzodh.z0rek();
			z0yek = z0ZzZzodh.z0tek();
		}
	}

	public int z0eek()
	{
		return z0tek;
	}

	public WriterMouseEventArgs(z0ZzZzdbj ctl, int x, int y, int clicks, z0ZzZzqeh button, int delta)
	{
		z0oek = ctl;
		z0nek = ctl.z0ruk();
		z0uek = x;
		z0rek = y;
		z0iek = clicks;
		z0vek = button;
		z0bek = delta;
		z0mek = ctl.z0eik();
		if (ctl != null)
		{
			z0ZzZzodh z0ZzZzodh = new z0ZzZzodh(x, y);
			z0tek = z0ZzZzodh.z0rek();
			z0yek = z0ZzZzodh.z0tek();
		}
	}
}
