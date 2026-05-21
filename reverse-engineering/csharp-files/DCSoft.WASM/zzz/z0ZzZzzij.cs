using System;
using System.Text;
using System.Text.Json;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzzij
{
	internal static bool z0eek(object p0, bool p1 = false)
	{
		if (p0 == null)
		{
			return p1;
		}
		string text = null;
		if (p0 is JsonElement jsonElement)
		{
			if (jsonElement.ValueKind == JsonValueKind.True)
			{
				return true;
			}
			if (jsonElement.ValueKind == JsonValueKind.False)
			{
				return false;
			}
			if (jsonElement.ValueKind == JsonValueKind.Null || jsonElement.ValueKind == JsonValueKind.Undefined)
			{
				return p1;
			}
			text = jsonElement.GetString();
		}
		else
		{
			text = Convert.ToString(p0).ToLower();
		}
		return z0eek(text, p1);
	}

	internal static bool z0eek(string p0, out Color p1)
	{
		return z0ZzZzifh.z0eek(p0, out p1);
	}

	internal static float z0eek(string p0, float p1 = 0f)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return p1;
	}

	internal static float z0rek(string p0, float p1 = 0f)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return p1;
	}

	internal static bool z0eek(string p0, bool p1 = false)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		p0 = p0.Trim().ToLower();
		switch (p0)
		{
		case "true":
		case "yes":
		case "on":
			return true;
		case "false":
		case "no":
		case "off":
			return false;
		default:
			return p1;
		}
	}

	internal static int z0eek(object p0, int p1 = 0)
	{
		if (p0 == null)
		{
			return p1;
		}
		int result = 0;
		if (p0 is JsonElement jsonElement && jsonElement.TryGetInt32(out result))
		{
			return result;
		}
		if (int.TryParse(p0.ToString(), out result))
		{
			return result;
		}
		return p1;
	}

	internal static Color z0eek(string p0, Color p1)
	{
		if (z0ZzZzifh.z0eek(p0, out var p2))
		{
			return p2;
		}
		return p1;
	}

	internal static string z0eek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is JsonElement jsonElement)
		{
			if (jsonElement.ValueKind == JsonValueKind.String)
			{
				return jsonElement.GetString();
			}
			if (jsonElement.ValueKind == JsonValueKind.Null || jsonElement.ValueKind == JsonValueKind.Undefined)
			{
				return null;
			}
			if (jsonElement.ValueKind == JsonValueKind.True)
			{
				return "true";
			}
			if (jsonElement.ValueKind == JsonValueKind.False)
			{
				return "false";
			}
			if (jsonElement.ValueKind == JsonValueKind.Number)
			{
				return jsonElement.GetDouble().ToString();
			}
			if (jsonElement.ValueKind == JsonValueKind.Null)
			{
				return null;
			}
			return jsonElement.GetString();
		}
		return Convert.ToString(p0);
	}

	public static string z0eek(string p0)
	{
		if (p0 == null)
		{
			return "null";
		}
		StringBuilder stringBuilder = new StringBuilder(p0.Length + 2);
		stringBuilder.Append('"');
		foreach (char c in p0)
		{
			switch (c)
			{
			case '"':
				stringBuilder.Append("\\\"");
				continue;
			case '\\':
				stringBuilder.Append("\\\\");
				continue;
			case '\b':
				stringBuilder.Append("\\b");
				continue;
			case '\f':
				stringBuilder.Append("\\f");
				continue;
			case '\n':
				stringBuilder.Append("\\n");
				continue;
			case '\r':
				stringBuilder.Append("\\r");
				continue;
			case '\t':
				stringBuilder.Append("\\t");
				continue;
			}
			if (c < ' ')
			{
				stringBuilder.Append("\\u");
				int num = c;
				stringBuilder.Append(num.ToString("x4"));
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		stringBuilder.Append('"');
		return stringBuilder.ToString();
	}

	internal static int z0eek(string p0, int p1 = 0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		int result = 0;
		if (int.TryParse(p0, out result))
		{
			return result;
		}
		return p1;
	}
}
