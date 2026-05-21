namespace System.Text.Json;

internal sealed class JsonCamelCaseNamingPolicy : JsonNamingPolicy
{
	public override string ConvertName(string P_0)
	{
		if (string.IsNullOrEmpty(P_0) || !char.IsUpper(P_0[0]))
		{
			return P_0;
		}
		return string.Create(P_0.Length, P_0, delegate(Span<char> span, string text)
		{
			text.CopyTo(span);
			FixCasing(span);
		});
	}

	private static void FixCasing(Span<char> P_0)
	{
		for (int i = 0; i < P_0.Length && (i != 1 || char.IsUpper(P_0[i])); i++)
		{
			bool flag = i + 1 < P_0.Length;
			if (i > 0 && flag && !char.IsUpper(P_0[i + 1]))
			{
				if (P_0[i + 1] == ' ')
				{
					P_0[i] = char.ToLowerInvariant(P_0[i]);
				}
				break;
			}
			P_0[i] = char.ToLowerInvariant(P_0[i]);
		}
	}
}
