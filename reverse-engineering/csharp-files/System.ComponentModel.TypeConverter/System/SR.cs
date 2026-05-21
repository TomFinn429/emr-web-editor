namespace System;

internal static class SR
{
	internal static string Format(string P_0, object P_1)
	{
		_ = 1;
		return string.Join(", ", P_0, P_1);
	}

	internal static string Format(string P_0, object P_1, object P_2)
	{
		_ = 1;
		return string.Join(", ", P_0, P_1, P_2);
	}

	internal static string Format(string P_0, object P_1, object P_2, object P_3)
	{
		_ = 1;
		return string.Join(", ", P_0, P_1, P_2, P_3);
	}
}
