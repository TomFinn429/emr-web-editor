namespace System;

internal static class AppContextConfigHelper
{
	internal static bool GetBooleanConfig(string P_0, bool P_1)
	{
		if (!AppContext.TryGetSwitch(P_0, out var result))
		{
			return P_1;
		}
		return result;
	}

	internal static bool GetBooleanConfig(string P_0, string P_1, bool P_2 = false)
	{
		if (!AppContext.TryGetSwitch(P_0, out var result))
		{
			string environmentVariable = Environment.GetEnvironmentVariable(P_1);
			return (environmentVariable == null) ? P_2 : (bool.IsTrueStringIgnoreCase(environmentVariable) || environmentVariable.Equals("1"));
		}
		return result;
	}
}
