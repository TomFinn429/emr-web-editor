using System;
using System.Text;
using DCSoft.Common;

namespace zzz;

public class z0ZzZzoyk
{
	private string z0cek;

	private int z0xek;

	private string z0zek;

	private bool z0lrk;

	private string z0krk;

	private string z0jrk;

	private string z0hrk;

	private readonly byte[] z0grk;

	private string z0frk;

	private byte[] z0drk;

	private DCCASignMode z0srk = DCCASignMode.Normal;

	private z0ZzZzhuk z0ark;

	private string z0qrk;

	private object z0wrk;

	private byte[] z0erk;

	private DateTime z0rrk = DateTime.MinValue;

	[NonSerialized]
	private readonly z0ZzZzmwh z0trk;

	public z0ZzZzmwh Parent => z0trk;

	public int ServerPort
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

	public byte[] InputContent => z0grk;

	public byte[] ResultImageData
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

	public string ServerIP
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

	public string z0eek()
	{
		return z0qrk;
	}

	public object z0rek()
	{
		return z0wrk;
	}

	public string z0tek()
	{
		return z0krk;
	}

	public void z0eek(string p0)
	{
		z0frk = p0;
	}

	public void z0eek(DCCASignMode p0)
	{
		z0srk = p0;
	}

	public string z0yek()
	{
		return z0frk;
	}

	public DateTime z0uek()
	{
		return z0rrk;
	}

	public byte[] TryFromBase64String(string base64)
	{
		if (string.IsNullOrEmpty(base64))
		{
			return null;
		}
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in base64)
			{
				if (!char.IsWhiteSpace(c))
				{
					stringBuilder.Append(c);
				}
			}
			return Convert.FromBase64String(stringBuilder.ToString());
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
			return null;
		}
	}

	public string GetAttribute(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		if (z0ark == null)
		{
			return null;
		}
		return z0ark.z0eek(name);
	}

	public void z0rek(string p0)
	{
		z0hrk = p0;
	}

	public DCCASignMode z0iek()
	{
		return z0srk;
	}

	public byte[] z0oek()
	{
		if (z0grk != null && z0grk.Length != 0)
		{
			byte[] array = new byte[z0grk.Length];
			Array.Copy(z0grk, array, array.Length);
			return array;
		}
		return null;
	}

	public void z0tek(string p0)
	{
		z0krk = p0;
	}

	public void z0yek(string p0)
	{
		z0cek = p0;
	}

	public void z0eek(bool p0)
	{
		z0lrk = p0;
	}

	public void z0eek(DateTime p0)
	{
		z0rrk = p0;
	}

	public z0ZzZzoyk(byte[] p0, z0ZzZzmwh p1, z0ZzZzhuk p2)
	{
		z0grk = p0;
		z0trk = p1;
		z0ark = p2;
		if (z0ark == null)
		{
			z0ark = new z0ZzZzhuk();
		}
	}

	public string z0pek()
	{
		return z0cek;
	}

	public void z0uek(string p0)
	{
		z0qrk = p0;
	}

	public bool z0mek()
	{
		return z0lrk;
	}

	public void z0iek(string p0)
	{
		z0zek = p0;
	}

	public void SetAttribute(string name, string Value)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		if (z0ark == null)
		{
			z0ark = new z0ZzZzhuk();
		}
		z0ark.z0eek(name, Value);
	}

	public void z0eek(byte[] p0)
	{
		z0erk = p0;
	}

	public byte[] z0nek()
	{
		return z0erk;
	}

	public string z0bek()
	{
		return z0zek;
	}

	public string z0vek()
	{
		return z0hrk;
	}

	public void z0eek(object p0)
	{
		z0wrk = p0;
	}
}
