using System;

namespace zzz;

public class z0ZzZzyhh : z0ZzZzlik, ICloneable, IDisposable
{
	private bool z0krk;

	internal DateTime z0jrk = z0ZzZzkfh.z0wrk;

	private string z0hrk;

	private string z0grk;

	private int z0frk;

	private string z0drk;

	private DateTime z0srk = z0ZzZzkfh.z0wrk;

	private DateTime z0ark = z0ZzZzkfh.z0wrk;

	private string z0qrk;

	[NonSerialized]
	internal object z0wrk;

	private int z0erk;

	private string z0rrk;

	private string z0trk;

	public bool z0eek()
	{
		if (!(z0srk == z0ZzZzkfh.z0wrk))
		{
			return z0srk == z0ZzZzkfh.z0zrk;
		}
		return true;
	}

	public int z0rek()
	{
		return z0erk;
	}

	public string z0tek()
	{
		return z0rrk;
	}

	public string z0yek()
	{
		return z0grk;
	}

	public void z0eek(string p0)
	{
		z0hrk = p0;
	}

	public void z0eek(DateTime p0)
	{
		z0ark = p0;
	}

	public string z0uek()
	{
		return z0drk;
	}

	public object z0ca(string p0)
	{
		return p0 switch
		{
			"Index" => z0frk, 
			"Name" => z0grk, 
			"Description" => z0drk, 
			"SavedTime" => z0srk, 
			"DisplaySavedTime" => z0ark, 
			"LoginTime" => z0jrk, 
			"CheckedValue" => z0krk, 
			"ClientName" => z0hrk, 
			"ID" => z0qrk, 
			"PermissionLevel" => z0erk, 
			"Tag" => z0trk, 
			"Name2" => z0rrk, 
			_ => null, 
		};
	}

	private object z0iek()
	{
		z0ZzZzyhh obj = (z0ZzZzyhh)MemberwiseClone();
		obj.z0wrk = null;
		return obj;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0iek
		return this.z0iek();
	}

	public static z0ZzZzyhh z0oek()
	{
		return new z0ZzZzyhh();
	}

	public void z0eek(int p0)
	{
		z0erk = p0;
	}

	public void z0rek(string p0)
	{
		z0rrk = p0;
	}

	public int z0pek()
	{
		return z0frk;
	}

	public void Dispose()
	{
		z0hrk = null;
		z0drk = null;
		z0qrk = null;
		z0grk = null;
		z0rrk = null;
		z0wrk = null;
		z0trk = null;
	}

	public void z0tek(string p0)
	{
		z0qrk = p0;
	}

	public string z0mek()
	{
		return z0hrk;
	}

	public DateTime z0nek()
	{
		return z0ark;
	}

	public string z0bek()
	{
		return z0trk;
	}

	public void z0eek(bool p0)
	{
		z0krk = p0;
	}

	internal void z0rek(DateTime p0)
	{
		if (z0eek())
		{
			if (z0jrk == z0ZzZzkfh.z0wrk)
			{
				z0ark = p0;
			}
			else
			{
				z0ark = z0jrk;
			}
		}
		else
		{
			z0ark = z0srk;
		}
	}

	public bool z0vek()
	{
		return z0krk;
	}

	public void z0yek(string p0)
	{
		z0trk = p0;
	}

	public override string ToString()
	{
		return z0pek() + ":" + z0zek() + " " + z0yek() + " " + z0cek();
	}

	public string z0cek()
	{
		if (z0srk == z0ZzZzkfh.z0wrk || z0srk == z0ZzZzkfh.z0zrk)
		{
			return string.Empty;
		}
		return z0srk.ToString(z0ZzZzkfh.z0qrk);
	}

	public void z0uek(string p0)
	{
		z0grk = p0;
	}

	public DateTime z0xek()
	{
		return z0srk;
	}

	public void z0rek(int p0)
	{
		z0frk = p0;
	}

	public string z0zek()
	{
		return z0qrk;
	}

	public z0ZzZzyhh z0lrk()
	{
		z0ZzZzyhh obj = (z0ZzZzyhh)MemberwiseClone();
		obj.z0wrk = null;
		return obj;
	}

	public void z0tek(DateTime p0)
	{
		z0srk = p0;
	}

	public void z0iek(string p0)
	{
		z0drk = p0;
	}
}
