using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using DCSoft;
using Microsoft.JSInterop;

namespace zzz;

public sealed class z0ZzZzjpj
{
	private readonly JsonSerializerOptions z0yek;

	[CompilerGenerated]
	private readonly z0ZzZzack z0uek;

	private static string z0iek;

	private string? z0oek;

	private static Uri z0pek;

	internal z0ZzZzjpj(IJSUnmarshalledRuntime p0, JsonSerializerOptions p1)
	{
		z0yek = p1;
		z0eek(p0);
		z0tek(p0);
		z0eek();
		z0ZzZzhpj z0ZzZzhpj2 = z0rek(p0);
		z0uek = z0ZzZzhpj2;
	}

	internal static string z0eek(string p0)
	{
		int num = p0.LastIndexOf('/');
		if (num >= 0)
		{
			p0 = p0.Substring(0, num + 1);
		}
		return p0;
	}

	private static void z0eek(IJSUnmarshalledRuntime p0)
	{
		string text = p0.InvokeUnmarshalled<string>("Blazor._internal.navigationManager.getUnmarshalledBaseURI");
		p0.InvokeUnmarshalled<string>("Blazor._internal.navigationManager.getUnmarshalledLocationHref");
		if (text != null)
		{
			z0pek = new Uri(z0eek(text), UriKind.Absolute);
		}
	}

	internal void z0eek()
	{
	}

	public z0ZzZzkpj z0rek()
	{
		return new z0ZzZzkpj(this, z0oek);
	}

	private z0ZzZzhpj z0rek(IJSUnmarshalledRuntime p0)
	{
		return new z0ZzZzhpj(p0.InvokeUnmarshalled<string>("Blazor._internal.getApplicationEnvironment"), z0pek.OriginalString);
	}

	[CompilerGenerated]
	public z0ZzZzack z0tek()
	{
		return z0uek;
	}

	public static z0ZzZzjpj z0eek(string[] p0 = null)
	{
		WASMJSRuntime wASMJSRuntime = WASMJSRuntime.z0rek;
		return new z0ZzZzjpj(wASMJSRuntime, wASMJSRuntime.z0eek());
	}

	private void z0tek(IJSUnmarshalledRuntime p0)
	{
		z0oek = p0.InvokeUnmarshalled<string>("Blazor._internal.getPersistedState");
	}
}
