using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZzhjh
{
	public static readonly string z0krk = "DCLogicDeletedCurrent";

	public static string z0eek()
	{
		return z0ZzZziok.z0eek("NotSupportWriteHtml");
	}

	internal static string z0eek(XAttributeList p0, bool p1)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		bool flag = false;
		if (p1)
		{
			string p2 = "\r\n:;[";
			string p3 = "\r\n;";
			using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0ltk();
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				if (z0ZzZzqik.z0eek(current.Name, p2) || z0ZzZzqik.z0eek(current.Value, p3))
				{
					flag = true;
					break;
				}
			}
		}
		if (!p1 || flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('[');
			object obj = p0[p0.Count - 1];
			using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XAttribute current2 = z0bpk.Current;
					stringBuilder.Append('{');
					stringBuilder.Append("\"Name\":");
					z0ZzZzeok.z0eek(current2.Name, stringBuilder);
					stringBuilder.Append(',');
					stringBuilder.Append("\"Value\":");
					z0ZzZzeok.z0eek(current2.Value, stringBuilder);
					stringBuilder.Append('}');
					if (current2 != obj)
					{
						stringBuilder.Append(',');
					}
				}
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
		StringBuilder stringBuilder2 = new StringBuilder();
		using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XAttribute current3 = z0bpk.Current;
				if (stringBuilder2.Length > 0)
				{
					stringBuilder2.Append(';');
				}
				stringBuilder2.Append(current3.Name);
				stringBuilder2.Append(':');
				stringBuilder2.Append(current3.Value);
			}
		}
		return stringBuilder2.ToString();
	}
}
