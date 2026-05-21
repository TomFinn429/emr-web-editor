using System.Windows.Forms;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentEventArgs
{
	internal float z0yek;

	private bool z0uek;

	private bool z0iek;

	internal int z0oek;

	private bool z0pek;

	internal string z0mek;

	internal bool z0nek = true;

	private XTextDocument z0bek;

	private bool z0vek;

	internal int z0cek;

	private int z0xek;

	private object z0zek;

	private XTextElement z0lrk;

	private Keys z0krk;

	private z0ZzZzqeh z0jrk;

	internal static z0ZzZznwh z0hrk = null;

	internal int z0grk;

	internal float z0frk;

	internal char z0drk;

	private bool z0srk;

	internal static string z0ark = null;

	internal DocumentEventStyles z0qrk;

	internal int z0wrk;

	public static z0ZzZznwh z0erk = z0ZzZzbwh.z0qrk;

	internal int z0rrk;

	private bool z0trk;

	public string Name => z0mek;

	public bool ShiftKey => z0trk;

	public bool Handled
	{
		get
		{
			return z0srk;
		}
		set
		{
			z0srk = value;
		}
	}

	public bool AlreadSetSelection
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

	public float ViewX => z0frk;

	public int WheelDelta => z0cek;

	public int MouseClicks
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public int ClientY => z0rrk;

	public z0ZzZznwh Cursor
	{
		get
		{
			return z0hrk;
		}
		set
		{
			z0hrk = value;
		}
	}

	public bool CancelBubble
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

	public int ClientX => z0wrk;

	public int KeyCharValue => z0drk;

	public bool AltKey => z0uek;

	public int ButtonValue => (int)Button;

	public z0ZzZzqeh Button => z0jrk;

	public XTextDocument Document => z0bek;

	public int KeyCodeValue => (int)z0krk;

	public DocumentEventStyles Style => z0qrk;

	public bool StrictMatch => z0nek;

	public char KeyChar => z0drk;

	public XTextElement Element
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	public string Tooltip
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	public int Y => z0oek;

	public object ReturnValue
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	public Keys KeyCode => z0krk;

	public int X => z0grk;

	public bool CtlKey => z0vek;

	public float ViewY => z0yek;

	public static DocumentEventArgs z0eek(XTextDocument p0, z0ZzZzheh p1)
	{
		return new DocumentEventArgs
		{
			z0bek = p0,
			z0uek = p1.z0oek(),
			z0vek = p1.z0iek(),
			z0trk = p1.z0yek(),
			z0krk = p1.z0uek(),
			z0drk = (char)p1.z0uek(),
			z0qrk = DocumentEventStyles.KeyUp
		};
	}

	public DocumentEventArgs z0eek()
	{
		return (DocumentEventArgs)MemberwiseClone();
	}

	private static DocumentEventArgs z0eek(XTextDocument p0, z0ZzZzweh p1, DocumentEventStyles p2)
	{
		DocumentEventArgs e = new DocumentEventArgs();
		e.z0xek = p1.z0uek();
		e.z0bek = p0;
		e.z0grk = p1.z0rek();
		e.z0oek = p1.z0tek();
		e.z0frk = p1.z0rek();
		e.z0yek = p1.z0tek();
		e.z0jrk = p1.z0yek();
		e.z0cek = p1.z0eek();
		e.z0rek();
		e.z0qrk = p2;
		return e;
	}

	public static DocumentEventArgs z0eek(XTextDocument p0, z0ZzZzweh p1)
	{
		return z0eek(p0, p1, DocumentEventStyles.MouseDown);
	}

	public static DocumentEventArgs z0eek(XTextDocument p0, char p1)
	{
		DocumentEventArgs e = new DocumentEventArgs();
		e.z0bek = p0;
		e.z0rek();
		e.z0drk = p1;
		e.z0qrk = DocumentEventStyles.KeyPress;
		return e;
	}

	private void z0rek()
	{
		Keys keys = z0ZzZzmwh.z0oek();
		z0uek = (keys & Keys.Shift) != 0;
		z0vek = (keys & Keys.Control) != 0;
		z0trk = (keys & Keys.Shift) != 0;
	}

	public static DocumentEventArgs z0rek(XTextDocument p0, z0ZzZzheh p1)
	{
		return new DocumentEventArgs
		{
			z0bek = p0,
			z0uek = p1.z0oek(),
			z0vek = p1.z0iek(),
			z0trk = p1.z0yek(),
			z0krk = p1.z0uek(),
			z0drk = (char)p1.z0uek(),
			z0qrk = DocumentEventStyles.KeyDown
		};
	}

	public DocumentEventArgs(XTextDocument document, XTextElement element, DocumentEventStyles style)
	{
		z0bek = document;
		z0lrk = element;
		z0qrk = style;
		z0rek();
	}

	internal z0ZzZznwh z0tek()
	{
		if (z0hrk != null)
		{
			return z0hrk;
		}
		if (z0erk != null)
		{
			return z0erk;
		}
		return z0ZzZzbwh.z0qrk;
	}

	public static DocumentEventArgs z0eek(XTextDocument p0, z0ZzZzgeh p1)
	{
		DocumentEventArgs e = new DocumentEventArgs();
		e.z0bek = p0;
		e.z0rek();
		e.z0drk = p1.z0eek();
		e.z0qrk = DocumentEventStyles.KeyPress;
		return e;
	}

	internal DocumentEventArgs()
	{
		z0hrk = z0erk;
		z0ark = null;
	}
}
