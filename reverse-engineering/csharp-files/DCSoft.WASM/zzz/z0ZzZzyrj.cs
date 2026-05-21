using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Printing;

namespace zzz;

public class z0ZzZzyrj
{
	private string z0nek;

	private string z0bek;

	internal List<int> z0vek = new List<int>();

	private DateTime z0cek = DateTime.MinValue;

	private string z0xek_jiejie20260327142557;

	private DateTime z0zek = DateTime.MinValue;

	private int z0lrk;

	private bool z0krk = true;

	private string z0jrk;

	private PrintResultStates z0hrk;

	private int z0grk;

	private bool z0frk;

	private z0ZzZztrj z0drk = new z0ZzZztrj();

	private string z0srk;

	private int z0ark = 1;

	private int z0qrk;

	public z0ZzZztrj PageInfos => z0drk;

	[DefaultValue(0)]
	public int Position
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

	[DefaultValue(false)]
	public bool JumpPrintMode
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

	public PrintResultStates State
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

	public bool CompleteSuccessed => State == PrintResultStates.CompletePrinted;

	public int NumOfPages => z0vek.Count;

	public bool UserCancel
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
			if (value)
			{
				State = PrintResultStates.UserCancel;
			}
		}
	}

	[DefaultValue(null)]
	public string Message
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

	[z0ZzZzuqh]
	public int[] SuccessedPageIndexs => z0vek.ToArray();

	public void z0eek(int p0)
	{
		z0ark = p0;
	}

	public int z0eek()
	{
		return z0ark;
	}

	public void z0eek(DateTime p0)
	{
		z0cek = p0;
	}

	public void z0rek(int p0)
	{
		z0grk = p0;
	}

	public void z0eek(string p0)
	{
		z0bek = p0;
	}

	public void z0tek(int p0)
	{
		z0qrk = p0;
	}

	public void z0rek(DateTime p0)
	{
		z0zek = p0;
	}

	public int z0rek()
	{
		return z0grk;
	}

	public void z0rek(string p0)
	{
		z0srk = p0;
	}

	public void z0tek(string p0)
	{
		z0nek = p0;
	}

	public DateTime z0tek()
	{
		return z0cek;
	}

	public string z0yek()
	{
		return z0xek_jiejie20260327142557;
	}

	public string z0uek()
	{
		return z0srk;
	}

	public DateTime z0iek()
	{
		return z0zek;
	}

	public int z0oek()
	{
		return z0qrk;
	}

	public string z0pek()
	{
		return z0nek;
	}

	public string z0mek()
	{
		return z0bek;
	}

	public void z0yek(string p0)
	{
		z0xek_jiejie20260327142557 = p0;
	}
}
