using System;
using System.Collections;
using System.IO;
using System.Text;

namespace zzz;

public class z0ZzZzfah : z0ZzZzoah
{
	private new static readonly (string key, int hash)[] z0oek = new(string, int)[15]
	{
		("#document", z0ZzZzysh.z0eek("#document")),
		("#document-fragment", z0ZzZzysh.z0eek("#document-fragment")),
		("#comment", z0ZzZzysh.z0eek("#comment")),
		("#text", z0ZzZzysh.z0eek("#text")),
		("#cdata-section", z0ZzZzysh.z0eek("#cdata-section")),
		("#entity", z0ZzZzysh.z0eek("#entity")),
		("id", z0ZzZzysh.z0eek("id")),
		("xmlns", z0ZzZzysh.z0eek("xmlns")),
		("xml", z0ZzZzysh.z0eek("xml")),
		("space", z0ZzZzysh.z0eek("space")),
		("lang", z0ZzZzysh.z0eek("lang")),
		("#whitespace", z0ZzZzysh.z0eek("#whitespace")),
		("#significant-whitespace", z0ZzZzysh.z0eek("#significant-whitespace")),
		("http://www.w3.org/2000/xmlns/", z0ZzZzysh.z0eek("http://www.w3.org/2000/xmlns/")),
		("http://www.w3.org/XML/1998/namespace", z0ZzZzysh.z0eek("http://www.w3.org/XML/1998/namespace"))
	};

	internal string z0mek;

	internal string z0bek;

	internal string z0vek;

	internal static z0ZzZzaqh z0cek = new z0ZzZzqqh((z0ZzZzwqh)1);

	internal string z0zek;

	internal string z0lrk;

	internal string z0jrk;

	internal static z0ZzZzaqh z0hrk = new z0ZzZzqqh((z0ZzZzwqh)0);

	internal string z0grk;

	internal string z0drk;

	internal string z0srk;

	internal string z0ark;

	internal string z0qrk;

	private bool z0wrk;

	private readonly z0ZzZzash z0trk;

	internal string z0ork;

	private bool z0nrk;

	internal static z0ZzZzaqh z0vrk = new z0ZzZzqqh((z0ZzZzwqh)2);

	internal string z0xrk;

	private Hashtable z0ltk;

	private z0ZzZztah z0gtk;

	internal bool z0stk;

	internal string z0atk;

	private readonly z0ZzZzrah z0etk;

	internal string z0ytk;

	internal string z0otk;

	internal bool z0mtk;

	internal static z0ZzZzqsh z0btk = new z0ZzZzqsh();

	internal void z0eek(string p0, z0ZzZzsah p1)
	{
		if (z0ltk == null || !z0ltk.Contains(p0))
		{
			return;
		}
		ArrayList arrayList = (ArrayList)z0ltk[p0];
		WeakReference<z0ZzZzsah> weakReference = z0eek(arrayList, p1);
		if (weakReference != null)
		{
			arrayList.Remove(weakReference);
			if (arrayList.Count == 0)
			{
				z0ltk.Remove(p0);
			}
		}
	}

	public void z0eek(Stream p0)
	{
		StreamReader streamReader = new StreamReader(p0, Encoding.UTF8, true);
		string p1 = streamReader.ReadToEnd();
		streamReader.Close();
		z0eek(p1);
	}

	public override string z0ph()
	{
		return z0jrk;
	}

	internal override bool z0hg(z0ZzZzbah p0)
	{
		switch (p0)
		{
		case (z0ZzZzbah)7:
		case (z0ZzZzbah)8:
		case (z0ZzZzbah)13:
		case (z0ZzZzbah)14:
			return true;
		case (z0ZzZzbah)1:
			if (z0uek() != null)
			{
				throw new InvalidOperationException();
			}
			return true;
		case (z0ZzZzbah)17:
			if (z0iek() != null)
			{
				throw new InvalidOperationException();
			}
			return true;
		default:
			return false;
		}
	}

	private static WeakReference<z0ZzZzsah> z0eek(ArrayList p0, z0ZzZzsah p1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (WeakReference<z0ZzZzsah> item in p0)
		{
			if (!item.TryGetTarget(out var z0ZzZzsah2))
			{
				arrayList.Add(item);
			}
			else if (z0ZzZzsah2 == p1)
			{
				return item;
			}
		}
		foreach (WeakReference<z0ZzZzsah> item2 in arrayList)
		{
			p0.Remove(item2);
		}
		return null;
	}

	internal z0ZzZzyah z0eek(string p0, string p1, string p2, z0ZzZzaqh p3)
	{
		z0ZzZzyah z0ZzZzyah2 = z0rek(p0, p1, p2, p3);
		if (!z0yek())
		{
			object obj = z0ZzZzyah2.z0oek();
			object obj2 = z0ZzZzyah2.z0rek();
			object obj3 = z0ZzZzyah2.z0yek();
			if ((obj == z0ark || (z0ZzZzyah2.z0oek().Length == 0 && obj3 == z0ark)) ^ (obj2 == z0grk))
			{
				throw new ArgumentException("Attr_Reserved_XmlNS:" + p2);
			}
		}
		return z0ZzZzyah2;
	}

	public new bool z0eek()
	{
		return z0wrk;
	}

	internal z0ZzZzyah z0eek(z0ZzZzyah p0)
	{
		return null;
	}

	internal override bool z0ff(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		if (p1 == null)
		{
			p1 = ((z0ZzZzoah)this).z0iek();
		}
		if (p1 == null)
		{
			return true;
		}
		switch (p0.z0mh())
		{
		case (z0ZzZzbah)17:
			return p1 == ((z0ZzZzoah)this).z0iek();
		case (z0ZzZzbah)7:
		case (z0ZzZzbah)8:
			return p1.z0mh() != (z0ZzZzbah)17;
		case (z0ZzZzbah)10:
			if (p1.z0mh() != (z0ZzZzbah)17)
			{
				return !z0rek((z0ZzZzbah)1, p1.z0af());
			}
			break;
		case (z0ZzZzbah)1:
			if (p1.z0mh() != (z0ZzZzbah)17)
			{
				return !z0eek((z0ZzZzbah)10, p1);
			}
			break;
		}
		return false;
	}

	internal new string z0rek()
	{
		return z0iek()?.z0eek();
	}

	public virtual void z0eek(string p0)
	{
		if (z0ZzZzhbj.JSProvider != null)
		{
			z0ZzZzihh z0ZzZzihh2 = z0ZzZzhbj.JSProvider.z0wlk(p0);
			if (z0ZzZzihh2 != null)
			{
				z0qg_jiejie20260327142557();
				z0ZzZzihh2.z0eek(this);
				z0ZzZzihh2.z0ha();
			}
		}
	}

	private static bool z0eek(z0ZzZzbah p0, z0ZzZzoah p1)
	{
		for (z0ZzZzoah z0ZzZzoah2 = p1; z0ZzZzoah2 != null; z0ZzZzoah2 = z0ZzZzoah2.z0qf())
		{
			if (z0ZzZzoah2.z0mh() == p0)
			{
				return true;
			}
		}
		return false;
	}

	public override z0ZzZzfah z0wg()
	{
		return null;
	}

	public virtual z0ZzZzsah z0eek(string p0, string p1, string p2)
	{
		return new z0ZzZzsah(z0rek(p0, p1, p2, null), p1: true, this);
	}

	internal void z0rek(string p0, z0ZzZzsah p1)
	{
		if (z0ltk == null || !z0ltk.Contains(p0))
		{
			if (z0ltk == null)
			{
				z0ltk = new Hashtable();
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new WeakReference<z0ZzZzsah>(p1));
			z0ltk.Add(p0, arrayList);
		}
		else
		{
			ArrayList arrayList2 = (ArrayList)z0ltk[p0];
			if (z0eek(arrayList2, p1) == null)
			{
				arrayList2.Add(new WeakReference<z0ZzZzsah>(p1));
			}
		}
	}

	internal z0ZzZzyah z0rek(string p0, string p1, string p2, z0ZzZzaqh p3)
	{
		return z0trk.z0rek(p0, p1, p2, p3);
	}

	public override z0ZzZzbah z0mh()
	{
		return (z0ZzZzbah)9;
	}

	public z0ZzZzsah z0rek(string p0)
	{
		z0ZzZzoah.z0eek(p0, out var p1, out var p2);
		return z0eek(p1, p2, string.Empty);
	}

	internal void z0eek(string p0, string p1, ref string p2)
	{
		if (p0 == z0ark || (p0.Length == 0 && p1 == z0ark))
		{
			p2 = z0grk;
		}
		else if (p0 == z0ytk)
		{
			p2 = z0ork;
		}
	}

	internal static void z0tek(string p0)
	{
		if (z0ZzZzmsh.z0rek(p0, 0) < p0.Length)
		{
			throw new z0ZzZzeah("BadNameChar:" + p0);
		}
	}

	public override void z0uh(z0ZzZzdqh p0)
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((z0ZzZzoah)enumerator.Current).z0eh(p0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public virtual z0ZzZzkqh z0yek(string p0)
	{
		return new z0ZzZzkqh(p0, this);
	}

	internal override void z0lg(z0ZzZztah p0)
	{
		z0gtk = p0;
	}

	internal override bool z0fg()
	{
		return true;
	}

	internal override bool z0gf(z0ZzZzoah p0, z0ZzZzoah p1)
	{
		if (p1 == null)
		{
			p1 = ((z0ZzZzoah)this).z0eek();
		}
		if (p1 == null)
		{
			return true;
		}
		switch (p0.z0mh())
		{
		case (z0ZzZzbah)7:
		case (z0ZzZzbah)8:
		case (z0ZzZzbah)13:
		case (z0ZzZzbah)14:
			return true;
		case (z0ZzZzbah)10:
			return !z0rek((z0ZzZzbah)1, p1);
		case (z0ZzZzbah)1:
			return !z0eek((z0ZzZzbah)10, p1.z0qf());
		default:
			return false;
		}
	}

	public new z0ZzZziah z0tek()
	{
		return z0etk.z0eek();
	}

	public z0ZzZzfah()
		: this(new z0ZzZzrah())
	{
	}

	public override void z0eh(z0ZzZzdqh p0)
	{
		z0uh(p0);
	}

	public override string z0th()
	{
		return z0jrk;
	}

	public override void z0rg(string p0)
	{
		throw new InvalidOperationException();
	}

	internal override z0ZzZztah z0jg()
	{
		return z0gtk;
	}

	internal bool z0yek()
	{
		return z0nrk;
	}

	public z0ZzZzbsh z0uek(string p0)
	{
		string p1 = string.Empty;
		z0ZzZzoah.z0eek(p0, out var p2, out var p3);
		z0eek(p2, p3, ref p1);
		return z0rek(p2, p3, p1);
	}

	protected internal z0ZzZzfah(z0ZzZzrah p0)
	{
		z0etk = p0;
		z0trk = new z0ZzZzash(this);
		z0ark = "xmlns";
		z0ytk = "xml";
		z0grk = "http://www.w3.org/2000/xmlns/";
		z0ork = "http://www.w3.org/XML/1998/namespace";
		z0otk = string.Empty;
		if (p0.z0eek().GetType() == typeof(z0ZzZzysh))
		{
			z0ZzZzysh z0ZzZzysh2 = (z0ZzZzysh)p0.z0eek();
			z0jrk = z0ZzZzysh2.z0eek(z0oek[0].key, z0oek[0].hash);
			z0atk = z0ZzZzysh2.z0eek(z0oek[1].key, z0oek[1].hash);
			z0mek = z0ZzZzysh2.z0eek(z0oek[2].key, z0oek[2].hash);
			z0lrk = z0ZzZzysh2.z0eek(z0oek[3].key, z0oek[3].hash);
			z0bek = z0ZzZzysh2.z0eek(z0oek[4].key, z0oek[4].hash);
			z0srk = z0ZzZzysh2.z0eek(z0oek[5].key, z0oek[5].hash);
			z0vek = z0ZzZzysh2.z0eek(z0oek[6].key, z0oek[6].hash);
			z0zek = z0ZzZzysh2.z0eek(z0oek[11].key, z0oek[11].hash);
			z0qrk = z0ZzZzysh2.z0eek(z0oek[12].key, z0oek[12].hash);
			z0ark = z0ZzZzysh2.z0eek(z0oek[7].key, z0oek[7].hash);
			z0ytk = z0ZzZzysh2.z0eek(z0oek[8].key, z0oek[8].hash);
			z0drk = z0ZzZzysh2.z0eek(z0oek[9].key, z0oek[9].hash);
			z0xrk = z0ZzZzysh2.z0eek(z0oek[10].key, z0oek[10].hash);
			z0grk = z0ZzZzysh2.z0eek(z0oek[13].key, z0oek[13].hash);
			z0ork = z0ZzZzysh2.z0eek(z0oek[14].key, z0oek[14].hash);
		}
		else
		{
			z0ZzZziah z0ZzZziah2 = p0.z0eek();
			z0jrk = z0ZzZziah2.z0nf("#document");
			z0atk = z0ZzZziah2.z0nf("#document-fragment");
			z0mek = z0ZzZziah2.z0nf("#comment");
			z0lrk = z0ZzZziah2.z0nf("#text");
			z0bek = z0ZzZziah2.z0nf("#cdata-section");
			z0srk = z0ZzZziah2.z0nf("#entity");
			z0vek = z0ZzZziah2.z0nf("id");
			z0zek = z0ZzZziah2.z0nf("#whitespace");
			z0qrk = z0ZzZziah2.z0nf("#significant-whitespace");
			z0ark = z0ZzZziah2.z0nf("xmlns");
			z0ytk = z0ZzZziah2.z0nf("xml");
			z0drk = z0ZzZziah2.z0nf("space");
			z0xrk = z0ZzZziah2.z0nf("lang");
			z0grk = z0ZzZziah2.z0nf("http://www.w3.org/2000/xmlns/");
			z0ork = z0ZzZziah2.z0nf("http://www.w3.org/XML/1998/namespace");
		}
	}

	public void z0eek(bool p0)
	{
		z0wrk = p0;
	}

	public new z0ZzZzsah z0uek()
	{
		return (z0ZzZzsah)z0eek((z0ZzZzbah)1);
	}

	public override z0ZzZzoah z0ih()
	{
		return null;
	}

	internal void z0rek(bool p0)
	{
		z0nrk = p0;
	}

	public virtual z0ZzZzbsh z0rek(string p0, string p1, string p2)
	{
		return new z0ZzZzbsh(z0eek(p0, p1, p2, null), this);
	}

	private static bool z0rek(z0ZzZzbah p0, z0ZzZzoah p1)
	{
		if (p1 == null)
		{
			return false;
		}
		z0ZzZzoah z0ZzZzoah2 = null;
		if (p1.z0ih() != null)
		{
			z0ZzZzoah2 = p1.z0ih().z0iek();
		}
		while (z0ZzZzoah2 != null)
		{
			if (z0ZzZzoah2.z0mh() == p0)
			{
				return true;
			}
			if (z0ZzZzoah2 == p1)
			{
				break;
			}
			z0ZzZzoah2 = z0ZzZzoah2.z0qf();
		}
		return false;
	}

	internal new virtual z0ZzZzgah z0iek()
	{
		if (((z0ZzZzoah)this).z0rek())
		{
			return ((z0ZzZzoah)this).z0iek() as z0ZzZzgah;
		}
		return null;
	}
}
