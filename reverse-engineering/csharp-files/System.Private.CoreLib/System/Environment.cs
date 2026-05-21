using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System;

public static class Environment
{
	private static Dictionary<string, string> s_environment;

	[CompilerGenerated]
	private static readonly int _003CProcessorCount_003Ek__BackingField;

	public static int CurrentManagedThreadId => Thread.CurrentThread.ManagedThreadId;

	public static extern int TickCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public static extern long TickCount64
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		get;
	}

	public static int ProcessorCount
	{
		[CompilerGenerated]
		get
		{
			return 1;
		}
	} = GetProcessorCount();

	public static string NewLine => "\n";

	public static string StackTrace
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return new StackTrace(true).ToString(System.Diagnostics.StackTrace.TraceFormat.Normal);
		}
	}

	public static string UserName => "Browser";

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int GetProcessorCount();

	[DoesNotReturn]
	public static void FailFast(string? P_0)
	{
		FailFast(P_0, null, null);
	}

	[DoesNotReturn]
	public static void FailFast(string? P_0, Exception? P_1)
	{
		FailFast(P_0, P_1, null);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[DoesNotReturn]
	public static extern void FailFast(string? P_0, Exception? P_1, string? P_2);

	private static string GetEnvironmentVariableCore(string P_0)
	{
		if (s_environment == null)
		{
			return Marshal.PtrToStringUTF8(Interop.Sys.GetEnv(P_0));
		}
		P_0 = TrimStringOnFirstZero(P_0);
		lock (s_environment)
		{
			s_environment.TryGetValue(P_0, out var result);
			return result;
		}
	}

	private static string TrimStringOnFirstZero(string P_0)
	{
		int num = P_0.IndexOf('\0');
		if (num >= 0)
		{
			return P_0.Substring(0, num);
		}
		return P_0;
	}

	public static string? GetEnvironmentVariable(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "variable");
		return GetEnvironmentVariableCore(P_0);
	}
}
