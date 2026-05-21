using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzomj
{
	private XTextDocument z0yek;

	private bool z0uek;

	private bool z0iek;

	private z0ZzZzymj z0oek;

	private z0ZzZzmmj z0pek = (z0ZzZzmmj)2;

	[NonSerialized]
	private z0ZzZzdbj z0mek;

	private object z0nek;

	private bool z0bek = true;

	private bool z0vek;

	private Keys z0cek;

	private string z0xek;

	private bool z0zek;

	private bool z0lrk;

	private object z0krk;

	private bool z0jrk = true;

	private bool z0hrk;

	private z0ZzZzlfh z0grk;

	private z0ZzZzwmj z0frk = (z0ZzZzwmj)1;

	private XTextElement z0drk;

	private bool z0srk;

	private bool z0ark;

	private object z0qrk;

	private object z0wrk;

	private bool z0erk = true;

	internal char z0rrk;

	private bool z0trk;

	[JsonIgnore]
	public z0ZzZzdbj EditorControl => z0mek;

	public bool AltKey
	{
		get
		{
			return z0trk;
		}
		set
		{
			z0trk = value;
		}
	}

	public Keys KeyCode
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public int KeyCodeValue
	{
		get
		{
			return (int)z0cek;
		}
		set
		{
			z0cek = (Keys)value;
		}
	}

	[JsonIgnore]
	public z0ZzZzlfh Host
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	public z0ZzZzmmj Mode
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

	public bool ShiftKey
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	public char KeyChar => z0rrk;

	public bool CtlKey
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

	[JsonIgnore]
	public object UIElement
	{
		get
		{
			return z0wrk;
		}
		set
		{
			z0wrk = value;
		}
	}

	public bool Cancel
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

	public bool Visible
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	[JsonIgnore]
	public object Parameter
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[JsonIgnore]
	public XTextElement SourceElement
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[JsonIgnore]
	public object UIEventArgs
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
		}
	}

	[JsonIgnore]
	public Dictionary<string, object> Session
	{
		get
		{
			if (z0mek == null)
			{
				return null;
			}
			return z0mek.z0mek(Name);
		}
	}

	public bool SetParameterToUIText
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

	public bool Actived
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

	[JsonIgnore]
	public z0ZzZzpxj DocumentControler
	{
		get
		{
			if (z0mek != null)
			{
				return z0mek.z0erk();
			}
			if (z0yek != null)
			{
				return z0yek.z0xek();
			}
			return null;
		}
	}

	public bool EnableSetUITextAsParamter
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

	public bool Checked
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

	[JsonIgnore]
	public object Result
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public z0ZzZzwmj RefreshLevel
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	public string Name
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

	public bool ShowUI
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public bool RaiseFromUI
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

	[JsonIgnore]
	public XTextDocument Document => z0yek;

	public bool Enabled
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	public z0ZzZzqbj z0eek()
	{
		return z0mek.z0ypk();
	}

	public z0ZzZzqbj z0rek()
	{
		if (z0mek == null)
		{
			return null;
		}
		return z0mek.z0ypk();
	}

	public z0ZzZzomj(z0ZzZzdbj p0, XTextDocument p1, z0ZzZzmmj p2, z0ZzZzymj p3)
	{
		z0oek = p3;
		z0mek = p0;
		if (z0mek != null)
		{
			z0oek = z0mek.z0muk();
			z0grk = z0mek.z0pek();
		}
		z0yek = p1;
		z0pek = p2;
	}

	public z0ZzZzymj z0tek()
	{
		return z0oek;
	}
}
