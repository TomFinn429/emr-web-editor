using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[DefaultMember("Item")]
[CLSCompliant(false)]
[SupportedOSPlatform("browser")]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class JSFunctionBinding
{
	[StructLayout((LayoutKind)0, Pack = 4)]
	internal struct JSBindingHeader
	{
		public int Version;

		public int ArgumentCount;

		public JSBindingType Exception;

		public JSBindingType Result;
	}

	[StructLayout((LayoutKind)0, Pack = 4, Size = 32)]
	internal struct JSBindingType
	{
		internal MarshalerType Type;

		internal nint __Reserved;

		internal nint JSCustomMarshallerCode;

		internal int JSCustomMarshallerCodeLength;

		internal MarshalerType ResultMarshalerType;

		internal MarshalerType Arg1MarshalerType;

		internal MarshalerType Arg2MarshalerType;

		internal MarshalerType Arg3MarshalerType;
	}

	internal unsafe JSBindingHeader* Header;

	internal unsafe JSBindingType* Sigs;

	internal JSObject JSFunction;

	internal unsafe int ArgumentCount
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Header->ArgumentCount = argumentCount;
		}
	}

	internal unsafe int Version
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Header->Version = version;
		}
	}

	internal unsafe JSBindingType Result
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Header->Result = result;
		}
	}

	internal unsafe JSBindingType Exception
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Header->Exception = exception;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void InvokeJS(JSFunctionBinding signature, Span<JSMarshalerArgument> arguments)
	{
		InvokeJSImpl(signature.JSFunction, arguments);
	}

	public static JSFunctionBinding BindJSFunction(string functionName, string moduleName, ReadOnlySpan<JSMarshalerType> signatures)
	{
		if (4 != 4)
		{
		}
		return BindJSFunctionImpl(functionName, moduleName, signatures);
	}

	public static JSFunctionBinding BindManagedFunction(string fullyQualifiedName, int signatureHash, ReadOnlySpan<JSMarshalerType> signatures)
	{
		if (4 != 4)
		{
		}
		return BindManagedFunctionImpl(fullyQualifiedName, signatureHash, signatures);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal unsafe static void InvokeJSImpl(JSObject P_0, Span<JSMarshalerArgument> P_1)
	{
		nint jSHandle = P_0.JSHandle;
		fixed (JSMarshalerArgument* ptr = P_1)
		{
			global::Interop.Runtime.InvokeJSFunction(jSHandle, ptr);
			ref JSMarshalerArgument reference = ref P_1[0];
			if (reference.slot.Type != MarshalerType.None)
			{
				JSHostImplementation.ThrowException(ref reference);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal unsafe static JSFunctionBinding BindJSFunctionImpl(string P_0, string P_1, ReadOnlySpan<JSMarshalerType> P_2)
	{
		JSFunctionBinding methodSignature = JSHostImplementation.GetMethodSignature(P_2);
		global::Interop.Runtime.BindJSFunction(in P_0, in P_1, methodSignature.Header, out var num, out var num2, out var obj);
		if (num2 != 0)
		{
			throw new JSException((string)obj);
		}
		methodSignature.JSFunction = JSHostImplementation.CreateCSOwnedProxy(num);
		return methodSignature;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal unsafe static JSFunctionBinding BindManagedFunctionImpl(string P_0, int P_1, ReadOnlySpan<JSMarshalerType> P_2)
	{
		JSFunctionBinding methodSignature = JSHostImplementation.GetMethodSignature(P_2);
		global::Interop.Runtime.BindCSFunction(in P_0, P_1, methodSignature.Header, out var num, out var obj);
		if (num != 0)
		{
			throw new JSException((string)obj);
		}
		return methodSignature;
	}
}
