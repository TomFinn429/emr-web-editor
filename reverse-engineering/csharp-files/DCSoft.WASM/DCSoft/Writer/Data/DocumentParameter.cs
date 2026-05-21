using System;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.Data;

public class DocumentParameter
{
	private string z0vek;

	private z0ZzZzjvj z0cek = (z0ZzZzjvj)7;

	[NonSerialized]
	private XTextDocument z0xek;

	private string z0zek_jiejie20260327142557;

	private string z0lrk;

	private string z0krk;

	private object z0jrk;

	private string z0hrk;

	private string z0grk;

	public string z0eek()
	{
		return z0krk;
	}

	public void z0eek(XTextDocument p0)
	{
		z0xek = p0;
	}

	public Type z0rek()
	{
		return z0cek switch
		{
			(z0ZzZzjvj)0 => typeof(string), 
			(z0ZzZzjvj)1 => typeof(bool), 
			(z0ZzZzjvj)3 => typeof(DateTime), 
			(z0ZzZzjvj)4 => typeof(TimeSpan), 
			(z0ZzZzjvj)5 => typeof(DateTime), 
			(z0ZzZzjvj)2 => typeof(double), 
			(z0ZzZzjvj)6 => typeof(byte[]), 
			(z0ZzZzjvj)7 => typeof(object), 
			_ => typeof(string), 
		};
	}

	public void z0eek(string p0)
	{
		z0grk = p0;
	}

	public DocumentParameter()
	{
	}

	public void z0rek(string p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzjvj z0tek()
	{
		return z0cek;
	}

	public void z0tek(string p0)
	{
		z0vek = p0;
	}

	public void z0eek(object p0)
	{
		if (z0jrk == p0)
		{
			return;
		}
		z0hrk = null;
		try
		{
			if (p0 == null || DBNull.Value.Equals(p0))
			{
				z0jrk = z0ZzZzmik.z0eek(z0rek());
				if (z0jrk == null)
				{
					z0jrk = DBNull.Value;
				}
			}
			else
			{
				z0jrk = z0ZzZzmik.z0eek(p0, z0rek());
				if (z0cek == (z0ZzZzjvj)3)
				{
					z0jrk = Convert.ToDateTime(z0jrk).Date;
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception(string.Format(z0ZzZziok.z0syk(), z0krk, z0cek, z0bek()), ex);
		}
	}

	public XTextDocument z0yek()
	{
		return z0xek;
	}

	public string z0uek()
	{
		return z0hrk;
	}

	public void z0yek(string p0)
	{
		z0hrk = p0;
	}

	public void z0uek(string p0)
	{
		z0zek_jiejie20260327142557 = p0;
	}

	public void z0eek(z0ZzZzjvj p0)
	{
		z0cek = p0;
	}

	public string z0iek()
	{
		return z0vek;
	}

	public DocumentParameter z0oek()
	{
		return (DocumentParameter)MemberwiseClone();
	}

	public void z0iek(string p0)
	{
		z0krk = p0;
	}

	public DocumentParameter(string name)
	{
		z0krk = name;
	}

	public string z0pek()
	{
		return z0lrk;
	}

	public string z0mek()
	{
		return z0zek_jiejie20260327142557;
	}

	public string z0nek()
	{
		return z0grk;
	}

	public object z0bek()
	{
		if (z0tek() == (z0ZzZzjvj)7)
		{
			return z0jrk;
		}
		if (z0jrk == null && z0grk != null)
		{
			object p = z0ZzZzmik.z0eek(z0rek());
			z0ZzZzmik.z0eek(z0grk, z0rek(), ref p);
			return p;
		}
		return z0jrk;
	}
}
