using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzzbk : z0ZzZzhbk
{
	public override string z0cak()
	{
		return "meta";
	}

	internal override bool z0rqk(z0ZzZznvk p0)
	{
		string p1 = null;
		if (base.z0rqk(p0))
		{
			if (z0eek("charset", out p1) && !string.IsNullOrEmpty(p0.z0yek().z0eek()) && string.Compare(p1, p0.z0yek().z0eek(), true) != 0)
			{
				p0.z0yek().z0eek(p1);
				if (p0.z0bek_jiejie20260327142557())
				{
					throw new z0ZzZzbnk(p1);
				}
			}
			if (z0eek("content", out p1))
			{
				Dictionary<string, string> dictionary = z0ZzZznvk.z0eek(p1);
				if (dictionary != null && dictionary.Count > 0)
				{
					foreach (string key in dictionary.Keys)
					{
						if (string.Compare(key, "charset", true) != 0)
						{
							continue;
						}
						string text = dictionary[key];
						if (text == null)
						{
							continue;
						}
						text = text.Trim();
						if (z0lrk.z0eek() != null && string.Compare(text, z0lrk.z0eek(), true) != 0)
						{
							z0lrk.z0eek(text);
							if (p0.z0bek_jiejie20260327142557())
							{
								throw new z0ZzZzbnk(text);
							}
						}
					}
				}
			}
			return true;
		}
		return false;
	}

	public override string z0vak()
	{
		return "meta";
	}
}
