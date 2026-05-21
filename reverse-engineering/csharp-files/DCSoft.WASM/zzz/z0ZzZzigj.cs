using System;
using System.Globalization;

namespace zzz;

internal class z0ZzZzigj : z0ZzZzfsj
{
	private string z0xek;

	private z0ZzZzyej z0lrk = (z0ZzZzyej)2;

	private string z0frk;

	private string z0drk_jiejie20260327142557;

	private string z0qrk;

	private DateTimeOffset? z0wrk;

	private string z0erk;

	private string z0rrk;

	private DateTimeOffset? z0trk;

	private string z0irk;

	internal void z0tek(string p0)
	{
		z0erk = p0;
	}

	internal string z0tek()
	{
		return z0rrk;
	}

	internal void z0yek(string p0)
	{
		z0rrk = p0;
	}

	internal z0ZzZzjwj z0tek(z0ZzZzbaj p0)
	{
		z0ZzZztaj z0ZzZztaj2 = new z0ZzZztaj();
		switch (p0)
		{
		case (z0ZzZzbaj)1:
			z0ZzZztaj2.z0eek(1);
			break;
		case (z0ZzZzbaj)2:
			z0ZzZztaj2.z0eek(2);
			break;
		case (z0ZzZzbaj)3:
			z0ZzZztaj2.z0eek(3);
			break;
		}
		z0ZzZztaj2.z0eek("Producer", z0xek);
		z0ZzZztaj2.z0eek("Keywords", z0rrk);
		if (z0wrk.HasValue)
		{
			z0ZzZztaj2.z0rek("CreateDate", z0wrk.Value.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture));
		}
		if (z0trk.HasValue)
		{
			string p1 = z0trk.Value.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
			z0ZzZztaj2.z0rek("ModifyDate", p1);
			z0ZzZztaj2.z0rek("MetadataDate", p1);
		}
		z0ZzZztaj2.z0rek("CreatorTool", z0drk_jiejie20260327142557);
		z0ZzZztaj2.z0eek("creator", "Seq", p2: false, z0erk);
		z0ZzZztaj2.z0eek("title", "Alt", p2: true, z0qrk);
		z0ZzZztaj2.z0eek("description", "Alt", p2: true, z0irk);
		if (z0rrk != null)
		{
			z0ZzZztaj2.z0rek("subject");
			z0ZzZztaj2.z0eek("Bag");
			string[] array = z0rrk.Split(';', ',');
			foreach (string text in array)
			{
				z0ZzZztaj2.z0tek("li", text.Trim());
			}
			z0ZzZztaj2.z0eek();
			z0ZzZztaj2.z0eek();
		}
		return new z0ZzZzjwj(z0ZzZztaj2.z0tek(z0frk));
	}

	internal string z0yek()
	{
		return z0irk;
	}

	internal void z0eek(DateTimeOffset? p0)
	{
		z0wrk = p0;
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Title", z0qrk, null);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Author", z0erk, null);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Subject", z0irk, null);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Keywords", z0rrk, null);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Creator", z0drk_jiejie20260327142557, null);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Producer", z0xek, null);
		z0ZzZzeaj2.z0eek("CreationDate", z0wrk);
		z0ZzZzeaj2.z0eek("ModDate", z0trk);
		switch (z0lrk)
		{
		case (z0ZzZzyej)0:
			z0ZzZzeaj2.Add("Trapped", new z0ZzZzhwj("True"));
			break;
		case (z0ZzZzyej)1:
			z0ZzZzeaj2.Add("Trapped", new z0ZzZzhwj("False"));
			break;
		}
		if (z0ZzZzeaj2.Count <= 0)
		{
			return null;
		}
		return z0ZzZzeaj2;
	}

	internal string z0uek()
	{
		return z0erk;
	}

	internal string z0iek()
	{
		return z0drk_jiejie20260327142557;
	}

	internal void z0uek(string p0)
	{
		z0irk = p0;
	}

	internal void z0iek(string p0)
	{
		z0drk_jiejie20260327142557 = p0;
	}

	internal DateTimeOffset? z0oek()
	{
		return z0wrk;
	}

	internal z0ZzZzigj()
	{
	}

	internal DateTimeOffset? z0pek()
	{
		return z0trk;
	}

	internal void z0oek(string p0)
	{
		z0xek = p0;
	}

	internal string z0mek()
	{
		return z0qrk;
	}

	internal void z0pek(string p0)
	{
		z0qrk = p0;
	}

	internal void z0rek(DateTimeOffset? p0)
	{
		z0trk = p0;
	}

	internal string z0nek()
	{
		return z0xek;
	}
}
