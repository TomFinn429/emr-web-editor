using System;
using System.Threading.Tasks;
using DCSoft;

namespace zzz;

public sealed class z0ZzZzkpj : IAsyncDisposable
{
	private readonly string? z0rek;

	public async ValueTask DisposeAsync()
	{
		WASMJSRuntime.z0rek.Dispose();
	}

	public async Task z0eek()
	{
	}

	internal z0ZzZzkpj(z0ZzZzjpj p0, string? p1)
	{
		GC.KeepAlive(typeof(JSInteropMethods));
		z0rek = p1;
	}
}
