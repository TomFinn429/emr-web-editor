using System.Collections.Generic;

namespace zzz;

public class z0ZzZzauk : zzz.z0ZzZzbyk<char>
{
	private new string z0rek;

	private string z0tek;

	public string Text2 => z0rek;

	public string Text1 => z0tek;

	public override bool EqualValues(char v1, int oldIndex, char v2, int newIndex)
	{
		return v1 == v2;
	}

	public float z0eek()
	{
		int num = 0;
		if (z0tek != null)
		{
			num = z0tek.Length;
		}
		if (z0rek != null)
		{
			num += z0rek.Length;
		}
		if (num == 0)
		{
			return 0f;
		}
		int num2 = 0;
		using (List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZznyk current = enumerator.Current;
				if (current.z0rek())
				{
					num2 += current.z0iek;
				}
			}
		}
		return (float)num2 * 2f / (float)num;
	}

	public void z0eek(string p0, string p1)
	{
		z0tek = p0;
		z0rek = p1;
		char[] oldList = (string.IsNullOrEmpty(p0) ? null : p0.ToCharArray());
		char[] newList = (string.IsNullOrEmpty(p1) ? null : p1.ToCharArray());
		base.Compare(oldList, newList);
	}
}
