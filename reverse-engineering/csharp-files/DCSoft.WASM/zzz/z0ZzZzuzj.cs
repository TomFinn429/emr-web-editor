using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzuzj : z0ZzZziyk
{
	public enum z0yhj
	{
		z0eek
	}

	public new bool z0rek;

	public new readonly z0yhj z0tek;

	public new void z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			base.z0eek((string)null);
		}
		else
		{
			base.z0eek(p0);
		}
	}

	public void z0eek(XAttributeList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			z0eek(0);
			return;
		}
		z0eek((byte)p0.Count);
		using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XAttribute current = z0bpk.Current;
			z0eek(current.Name);
			z0eek(current.Value);
		}
	}

	public z0ZzZzuzj(z0yhj p0)
	{
		z0tek = p0;
	}
}
