using System;
using System.Text.Json;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzyoj
{
	public static T z0eek<T>(this JsonElement p0, T p1) where T : struct
	{
		if (p0.ValueKind == JsonValueKind.String)
		{
			string text = p0.GetString();
			if (text == null || text.Length == 0)
			{
				return p1;
			}
			T result = default(T);
			if (Enum.TryParse<T>(text, true, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.ValueKind == JsonValueKind.Number)
		{
			int @int = p0.GetInt32();
			return (T)Enum.ToObject(typeof(T), @int);
		}
		return p1;
	}

	public static float z0yek(this ref Utf8JsonReader p0, float p1)
	{
		if (p0.TokenType == JsonTokenType.Number)
		{
			return p0.GetSingle();
		}
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			float result = 0f;
			if (float.TryParse(text, out result))
			{
				return result;
			}
		}
		return p1;
	}

	public static bool z0yek(this ref Utf8JsonReader p0, bool p1)
	{
		if (p0.TokenType == JsonTokenType.True)
		{
			return true;
		}
		if (p0.TokenType == JsonTokenType.False)
		{
			return false;
		}
		if (p0.TokenType == JsonTokenType.Null)
		{
			return p1;
		}
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			text = text.Trim().ToLower();
			if (text == "true")
			{
				return true;
			}
			if (text == "false")
			{
				return false;
			}
		}
		return p1;
	}

	public static bool z0yek(this JsonElement p0, bool p1)
	{
		if (p0.ValueKind == JsonValueKind.True)
		{
			return true;
		}
		if (p0.ValueKind == JsonValueKind.False)
		{
			return false;
		}
		if (p0.ValueKind == JsonValueKind.String)
		{
			string text = p0.GetString();
			if (text != null)
			{
				text = text.Trim();
				if (string.Equals(text, "true", StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				if (string.Equals(text, "false", StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
		}
		return p1;
	}

	public static void z0yek(this Utf8JsonWriter p0, string p1, Color p2)
	{
		p0.WriteString(p1, z0ZzZzlok.z0eek(p2));
	}

	public static T z0rek<T>(this JsonProperty p0, T p1) where T : struct
	{
		if (p0.Value.ValueKind == JsonValueKind.String)
		{
			string text = p0.Value.GetString();
			if (text == null || text.Length == 0)
			{
				return p1;
			}
			T result = default(T);
			if (Enum.TryParse<T>(text, true, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.Value.ValueKind == JsonValueKind.Number)
		{
			int @int = p0.Value.GetInt32();
			return (T)Enum.ToObject(typeof(T), @int);
		}
		return p1;
	}

	public static int z0yek(this JsonProperty p0, int p1)
	{
		return p0.Value.z0yek(p1);
	}

	public static string z0yek(this JsonElement p0)
	{
		return p0.ValueKind switch
		{
			JsonValueKind.String => p0.GetString(), 
			JsonValueKind.Null => null, 
			JsonValueKind.False => "false", 
			JsonValueKind.True => "true", 
			JsonValueKind.Number => p0.GetSingle().ToString(), 
			JsonValueKind.Undefined => null, 
			JsonValueKind.Object => p0.GetString(), 
			JsonValueKind.Array => null, 
			_ => null, 
		};
	}

	public static Color z0yek(this ref Utf8JsonReader p0, Color p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			return z0ZzZzlok.z0eek(p0.GetString().Trim(), p1);
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return Color.FromArgb(p0.GetInt32());
		}
		return p1;
	}

	public static bool z0yek(this JsonProperty p0, bool p1)
	{
		return p0.Value.z0yek(p1);
	}

	public static float z0yek(this JsonElement p0, float p1)
	{
		float result = 0f;
		if (p0.ValueKind == JsonValueKind.Number)
		{
			if (p0.TryGetSingle(out result))
			{
				return result;
			}
		}
		else if (p0.ValueKind == JsonValueKind.String && float.TryParse(p0.GetString(), out result))
		{
			return result;
		}
		return p1;
	}

	public static double z0yek(this ref Utf8JsonReader p0, double p1)
	{
		if (p0.TokenType == JsonTokenType.Number)
		{
			return p0.GetDouble();
		}
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			double result = 0.0;
			if (double.TryParse(text, out result))
			{
				return result;
			}
		}
		return p1;
	}

	public static DateTime z0yek(this ref Utf8JsonReader p0, long p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? s = p0.GetString();
			DateTime result = DateTime.MinValue;
			if (DateTime.TryParse(s, out result))
			{
				return result;
			}
		}
		return new DateTime(p1);
	}

	public static int z0yek(this JsonElement p0, int p1)
	{
		int result = 0;
		if (p0.ValueKind == JsonValueKind.Number)
		{
			if (p0.TryGetInt32(out result))
			{
				return result;
			}
		}
		else if (p0.ValueKind == JsonValueKind.String && int.TryParse(p0.GetString(), out result))
		{
			return result;
		}
		return p1;
	}

	public static string z0yek(this JsonProperty p0)
	{
		string text = p0.Value.z0yek();
		if (text == null || text.Length == 0)
		{
			return null;
		}
		return text;
	}

	public static Color z0yek(this JsonProperty p0, Color p1)
	{
		if (p0.Value.ValueKind == JsonValueKind.String)
		{
			return z0ZzZzlok.z0eek(p0.Value.GetString(), p1);
		}
		return p1;
	}

	public static DateTime z0yek(this JsonElement p0, long p1)
	{
		DateTime result = DateTime.MinValue;
		if (p0.ValueKind == JsonValueKind.String && DateTime.TryParse(p0.GetString(), out result))
		{
			return result;
		}
		return new DateTime(p1);
	}

	public static T z0tek<T>(JsonElement p0, string[] p1, T[] p2, T p3) where T : Enum
	{
		if (p0.ValueKind == JsonValueKind.String)
		{
			string text = p0.GetString();
			if (text != null)
			{
				text = text.Trim();
				for (int num = p1.Length - 1; num >= 0; num--)
				{
					if (string.Equals(p1[num], text, StringComparison.OrdinalIgnoreCase))
					{
						return p2[num];
					}
				}
			}
		}
		return p3;
	}

	public static string z0uek(this JsonProperty p0)
	{
		return p0.Value.z0yek();
	}

	public static Color z0iek(this JsonProperty p0)
	{
		if (p0.Value.ValueKind == JsonValueKind.String)
		{
			return z0ZzZzlok.z0eek(p0.Value.GetString(), Color.Empty);
		}
		return Color.Empty;
	}

	public static float z0yek(this JsonProperty p0, float p1)
	{
		return p0.Value.z0yek(p1);
	}

	public static DateTime z0yek(this JsonProperty p0, long p1)
	{
		return p0.Value.z0yek(p1);
	}

	public static int z0yek(this ref Utf8JsonReader p0, int p1)
	{
		if (p0.TokenType == JsonTokenType.Number)
		{
			return p0.GetInt32();
		}
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			int result = 0;
			if (int.TryParse(text, out result))
			{
				return result;
			}
		}
		return p1;
	}
}
