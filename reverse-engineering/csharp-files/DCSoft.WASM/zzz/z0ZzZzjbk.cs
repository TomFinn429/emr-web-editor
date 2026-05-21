using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

internal static class z0ZzZzjbk
{
	public static string z0eek(string p0)
	{
		if (p0 == null || p0.Trim().Length == 0)
		{
			return p0;
		}
		Uri uri = null;
		try
		{
			uri = new Uri(p0);
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.Message);
			return null;
		}
		string empty = string.Empty;
		int num = 0;
		if (uri.Scheme == Uri.UriSchemeFile)
		{
			return p0;
		}
		num = p0.IndexOf("://");
		empty = p0.Substring(0, num + 3);
		p0 = p0.Substring(num + 3);
		string text = string.Empty;
		num = p0.LastIndexOfAny("/\\".ToCharArray());
		if (num > 0)
		{
			text = p0.Substring(num + 1);
			p0 = p0.Substring(0, num);
		}
		List<string> list = new List<string>();
		string[] array = p0.Split('/', '\\');
		foreach (string text2 in array)
		{
			list.Add(text2.Trim());
		}
		for (int j = 1; j < list.Count; j++)
		{
			if (list[j] == "..")
			{
				list.RemoveAt(j);
				list.RemoveAt(j - 1);
				j -= 2;
			}
			else if (list[j] == ".")
			{
				list.RemoveAt(j);
				j--;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(empty);
		char c = '/';
		for (int k = 0; k < list.Count; k++)
		{
			stringBuilder.Append(list[k]);
			stringBuilder.Append(c);
		}
		stringBuilder.Append(text);
		return stringBuilder.ToString();
	}
}
