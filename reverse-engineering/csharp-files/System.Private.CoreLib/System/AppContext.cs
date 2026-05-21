using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace System;

public static class AppContext
{
	private static Dictionary<string, object> s_dataStore;

	private static Dictionary<string, bool> s_switches;

	private static string s_defaultBaseDirectory;

	[CompilerGenerated]
	private static EventHandler ProcessExit;

	public static string BaseDirectory => (GetData("APP_CONTEXT_BASE_DIRECTORY") as string) ?? s_defaultBaseDirectory ?? (s_defaultBaseDirectory = "/");

	public static object? GetData(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "name");
		if (s_dataStore == null)
		{
			return null;
		}
		lock (s_dataStore)
		{
			s_dataStore.TryGetValue(P_0, out var result);
			return result;
		}
	}

	internal static void OnProcessExit()
	{
		AssemblyLoadContext.OnProcessExit();
		if (false)
		{
		}
		ProcessExit?.Invoke(AppDomain.CurrentDomain, EventArgs.Empty);
	}

	public static bool TryGetSwitch(string P_0, out bool P_1)
	{
		ArgumentException.ThrowIfNullOrEmpty(P_0, "switchName");
		if (s_switches != null)
		{
			lock (s_switches)
			{
				if (s_switches.TryGetValue(P_0, out P_1))
				{
					return true;
				}
			}
		}
		if (GetData(P_0) is string text && bool.TryParse(text, out P_1))
		{
			return true;
		}
		P_1 = false;
		return false;
	}

	internal unsafe static void Setup(char** P_0, char** P_1, int P_2)
	{
		s_dataStore = new Dictionary<string, object>(P_2);
		for (int i = 0; i < P_2; i++)
		{
			s_dataStore.Add(new string(P_0[i]), new string(P_1[i]));
		}
	}
}
