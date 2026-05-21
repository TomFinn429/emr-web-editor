using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
public class JSObject : IDisposable
{
	internal nint JSHandle;

	internal GCHandle? InFlight;

	internal int InFlightCounter;

	private bool _isDisposed;

	public bool IsDisposed => _isDisposed;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int GetPropertyAsInt32(string P_0)
	{
		ObjectDisposedException.ThrowIf(IsDisposed, this);
		return JavaScriptImports.GetPropertyAsInt32(this, P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public string? GetPropertyAsString(string P_0)
	{
		ObjectDisposedException.ThrowIf(IsDisposed, this);
		return JavaScriptImports.GetPropertyAsString(this, P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public JSObject? GetPropertyAsJSObject(string P_0)
	{
		ObjectDisposedException.ThrowIf(IsDisposed, this);
		return JavaScriptImports.GetPropertyAsJSObject(this, P_0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetProperty(string P_0, byte[]? P_1)
	{
		ObjectDisposedException.ThrowIf(IsDisposed, this);
		JavaScriptImports.SetPropertyBytes(this, P_0, P_1);
	}

	internal JSObject(nint P_0)
	{
		JSHandle = P_0;
		InFlight = null;
		InFlightCounter = 0;
	}

	internal void AddInFlight()
	{
		ObjectDisposedException.ThrowIf(IsDisposed, this);
		lock (this)
		{
			InFlightCounter++;
			if (InFlightCounter == 1)
			{
				InFlight = GCHandle.Alloc(this, GCHandleType.Normal);
			}
		}
	}

	internal void ReleaseInFlight()
	{
		lock (this)
		{
			InFlightCounter--;
			if (InFlightCounter == 0)
			{
				InFlight.Value.Free();
				InFlight = null;
			}
		}
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 is JSObject jSObject)
		{
			return JSHandle == jSObject.JSHandle;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)JSHandle;
	}

	public override string ToString()
	{
		return $"(js-obj js '{JSHandle}')";
	}

	private void Dispose(bool P_0)
	{
		if (!_isDisposed)
		{
			JSHostImplementation.ReleaseCSOwnedObject(JSHandle);
			_isDisposed = true;
			JSHandle = IntPtr.Zero;
		}
	}

	~JSObject()
	{
		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}
