using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.JSInterop.WebAssembly;
using zzz;

namespace DCSoft;

public sealed class WASMJSRuntime : WebAssemblyJSRuntime
{
	[CompilerGenerated]
	private sealed class z0byk
	{
		public static Action<(DotNetInvocationInfo callInfo, string argsJson)> z0tek;

		public static readonly z0byk z0yek = new z0byk();

		public static Action<string> z0uek;

		internal void z0eek((DotNetInvocationInfo callInfo, string argsJson) p0)
		{
			DotNetDispatcher.BeginInvokeDotNet(WASMJSRuntime.z0rek, p0.callInfo, p0.argsJson);
		}

		internal void z0rek(string p0)
		{
			DotNetDispatcher.EndInvokeJS(WASMJSRuntime.z0rek, p0);
		}
	}

	internal static readonly WASMJSRuntime z0rek = new WASMJSRuntime();

	public static void NotifyByteArrayAvailable(int id)
	{
		byte[] array = z0rek.InvokeUnmarshalled<byte[]>("Blazor._internal.retrieveByteArray");
		DotNetDispatcher.ReceiveByteArray(z0rek, id, array);
	}

	private WASMJSRuntime()
	{
	}

	public static void EndInvokeJS(string argsJson)
	{
		z0ZzZzlpj.z0eek(argsJson, delegate(string p0)
		{
			DotNetDispatcher.EndInvokeJS(z0rek, p0);
		});
	}

	public static void BeginInvokeDotNet(string callId, string assemblyNameOrDotNetObjectId, string methodIdentifier, string argsJson)
	{
		long num;
		string text;
		if (char.IsDigit(assemblyNameOrDotNetObjectId[0]))
		{
			num = long.Parse(assemblyNameOrDotNetObjectId, CultureInfo.InvariantCulture);
			text = null;
		}
		else
		{
			num = 0L;
			text = assemblyNameOrDotNetObjectId;
		}
		z0ZzZzlpj.z0eek((new DotNetInvocationInfo(text, methodIdentifier, num, callId), argsJson), delegate((DotNetInvocationInfo callInfo, string argsJson) p0)
		{
			DotNetDispatcher.BeginInvokeDotNet(z0rek, p0.callInfo, p0.argsJson);
		});
	}

	public static string? InvokeDotNet(string assemblyName, string methodIdentifier, string dotNetObjectId, string argsJson)
	{
		DotNetInvocationInfo dotNetInvocationInfo = new DotNetInvocationInfo(assemblyName, methodIdentifier, (dotNetObjectId == null) ? 0 : long.Parse(dotNetObjectId, CultureInfo.InvariantCulture), null);
		return DotNetDispatcher.Invoke(z0rek, in dotNetInvocationInfo, argsJson);
	}

	public JsonSerializerOptions z0eek()
	{
		return base.JsonSerializerOptions;
	}
}
