using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzgcj : List<z0ZzZzhcj>
{
	public string z0eek()
	{
		StringBuilder stringBuilder = new StringBuilder();
		z0ZzZzhcj z0ZzZzhcj2 = null;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzhcj current = enumerator.Current;
				bool flag = false;
				if (z0ZzZzhcj2 == null)
				{
					flag = true;
				}
				else if (!current.z0eek().GetType().Equals(z0ZzZzhcj2.z0eek().GetType()))
				{
					stringBuilder.AppendLine();
					flag = true;
				}
				if (flag)
				{
					stringBuilder.Append(current.z0eek().z0hyk());
					stringBuilder.Append(":");
				}
				z0ZzZzhcj2 = current;
				if (current.z0eek() is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)current.z0eek();
					stringBuilder.Append(xTextCharElement.z0bek.ToString());
				}
				else
				{
					if (z0ZzZzhcj2 != null && z0ZzZzhcj2.z0eek() is XTextCharElement)
					{
						stringBuilder.Append("#" + z0ZzZzhcj2.z0tek());
					}
					if (current.z0eek() is XTextInputFieldElementBase)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)current.z0eek();
						if (!string.IsNullOrEmpty(xTextInputFieldElementBase.Name))
						{
							stringBuilder.Append(xTextInputFieldElementBase.Name);
						}
						else
						{
							stringBuilder.Append(xTextInputFieldElementBase.z0vek());
						}
						stringBuilder.Append(":");
						stringBuilder.Append(z0ZzZzafh.z0yek(xTextInputFieldElementBase.Text, 50));
						stringBuilder.Append("#");
						stringBuilder.Append(current.z0tek());
					}
					else
					{
						stringBuilder.Append(current.z0eek()?.ToString() + "#" + current.z0tek());
					}
				}
				if (stringBuilder.Length > 1000)
				{
					break;
				}
			}
		}
		if (z0ZzZzhcj2 != null && z0ZzZzhcj2.z0eek() is XTextCharElement)
		{
			stringBuilder.Append("#" + z0ZzZzhcj2.z0tek());
		}
		return stringBuilder.ToString();
	}

	public void z0eek(XTextElement p0, string p1, ContentProtectedReason p2)
	{
		Add(new z0ZzZzhcj(p0, p1, p2));
	}

	public z0ZzZzhcj z0eek(XTextElement p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzhcj current = enumerator.Current;
				if (current.z0eek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
